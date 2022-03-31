using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using MemTools;

namespace BL3TP {
  [StructLayout(LayoutKind.Sequential)]
  public struct Vect3F {
    public Single X;
    public Single Y;
    public Single Z;
  }

  static class GameHook {
    private static readonly string[] GAME_NAMES = new string[] {
      "Borderlands3", "Wonderlands"
    };

    private static MemManager manager = null;
    private static Pointer posPtr = null;
    private static Pointer worldPtr = null;
    private static Pointer gNamesPtr = null;

    public static bool IsHooked => manager != null && manager.IsHooked && posPtr != null && worldPtr != null && gNamesPtr != null;

    public static Vect3F Position {
      get {
        if (!IsHooked && !TryHook()) {
          return default;
        }
        return manager.Read<Vect3F>(posPtr);
      }
      set {
        if (!IsHooked && !TryHook()) {
          return;
        }
        manager.Write<Vect3F>(posPtr, value);
      }
    }

    private static Int32 cachedWorldIndex = -1;
    private static string cachedWorldName = null;
    public static string WorldName {
      get {
        if (!IsHooked && ! TryHook()) {
          return default;
        }
        Int32 index = manager.Read<Int32>(worldPtr);
        if (index == cachedWorldIndex) {
          return cachedWorldName;
        }
        string worldName = ReadFromGNames(index);
        cachedWorldIndex = index;
        cachedWorldName = worldName;
        return worldName;
      }
    }

    public static bool TryHook() {
      foreach (string gameName in GAME_NAMES) {
        foreach (Process p in Process.GetProcessesByName(gameName)) {
          manager = new MemManager(p);

          try {
            if (!LoadPositionPointer(p.MainModule)) {
              continue;
            }
            if (!LoadWorldPointer(p.MainModule)) {
              continue;
            }
            if (!LoadGNamesPointer(p.MainModule)) {
              continue;
            }
            break;
          } catch (Win32Exception) {
            continue;
          }
        }
      }
      return IsHooked;
    }

    private static string ReadFromGNames(Int32 index) {
      if ((!IsHooked && !TryHook()) || index < 0) {
        return default;
      }
      Pointer chunk = gNamesPtr.AddOffsets((index / 0x4000) * 8, (index % 0x4000) * 8, 0x10);
      return manager.ReadString(chunk, Encoding.UTF8);
    }

    private static bool LoadPositionPointer(ProcessModule exe) {
      IntPtr ptr = manager.SigScan(
        exe.BaseAddress,
        exe.ModuleMemorySize,
        31,
        "88 1D ????????",     // mov [Borderlands3.exe + 6802764], bl
        "E8 ????????",        // call Borderlands3.exe + 3C8D4C0
        "48 8D 0D ????????",  // lea rcx,[Borderlands3.exe + 6802768]
        "E8 ????????",        // call Borderlands3.exe + 3C8D690
        "48 8B 5C 24 20",     // mov rbx,[rsp + 20]
        "48 8D 05 ????????",  // lea rax,[Borderlands3.exe + 6802670] <---
        "48 83 C4 28",        // add rsp, 28
        "C3"                  // ret
      );

      if (ptr == IntPtr.Zero) {
        return false;
      }

      /*
        These instructions are directly around the function sigscanned above:
          call <function>
          mov rsi,rax
          ...
          cmp rbp, [rsi+000000D0]

        This compare is what accesses the `OakLocalPlayer` object we want.
        Going to assume the 0xDO is constant to make dealing with all this easier.
      */

      Int64 baseAddr = ptr.ToInt64() + 4 + manager.Read<Int32>(ptr);
      baseAddr += 0xD0;

      /*
        Don't know exact field names but this is roughly what the pointer follows:
        OakLocalPlayer -> OakPlayerController.Pawn -> CapsuleComponent/CollisionCylinder -> Location
      */
      posPtr = new Pointer(new IntPtr(baseAddr), 0x0, 0x30, 0x488, 0x168, 0x220);
      return true;
    }

    private static bool LoadWorldPointer(ProcessModule exe) {
      IntPtr ptr = manager.SigScan(
        exe.BaseAddress,
        exe.ModuleMemorySize,
        7,
        "4C 8D 0C 40",        // lea r9,[rax + rax * 2]
        "48 8B 05 ????????",  // mov rax,[Borderlands3.exe + 601A430] <---
        "4A 8D 0C C8"         // lea rcx,[rax+r9 * 8]
      );

      if (ptr == IntPtr.Zero) {
        return false;
      }
      Int64 baseAddr = ptr.ToInt64() + 4 + manager.Read<Int32>(ptr);
      worldPtr = new Pointer(new IntPtr(baseAddr), 0x0, 0x0, 0x18);
      return true;
    }

    private static bool LoadGNamesPointer(ProcessModule exe) {
      IntPtr ptr = manager.SigScan(
        exe.BaseAddress,
        exe.ModuleMemorySize,
        11,
        "E8 ????????",        // call Borderlands3.exe+3CEF05C
        "48 ?? ??",           // mov rax,rbx
        "48 89 1D ????????",  // mov[Borderlands3.exe+67D4368],rbx <---
        "48 8B 5C 24 ??",     // mov rbx,[rsp+20]
        "48 83 C4 28",        // add rsp,28
        "C3",                 // ret
        "?? DB",              // xor ebx,ebx
        "48 89 1D ????????",  // mov[Borderlands3.exe+67D4368],rbx
        "?? ??",              // mov eax,ebx
        "48 8B 5C 24 ??",     // mov rbx,[rsp+20]
        "48 83 C4 ??",        // add rsp,28
        "C3"                  // ret
      );

      if (ptr == IntPtr.Zero) {
        return false;
      }
      Int64 baseAddr = ptr.ToInt64() + 4 + manager.Read<Int32>(ptr);
      gNamesPtr = new Pointer(new IntPtr(baseAddr), 0x0);
      return true;
    }
  }
}
