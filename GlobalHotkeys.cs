using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CarWarpHelper {
  public partial class MainForm : Form {

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool RegisterHotKey(IntPtr hWnd, Int32 id, UInt32 fsModifiers, UInt32 vk);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool UnregisterHotKey(IntPtr hWnd, Int32 id);

    private const UInt32 MOD_NOREPEAT = 0x4000;
    private const UInt32 WM_HOTKEY = 0x0312;

    private Int32 minUnusedId = 1;
    private readonly Dictionary<int, Tuple<object, EventHandler>> idHandlerMap = new Dictionary<int, Tuple<object, EventHandler>>();
    private readonly Dictionary<Keys, int> keyIdMap = new Dictionary<Keys, int>();

    public void AddHotkey(Keys k, object identifier, EventHandler handler) {
      // Might want to be more explicit about this
      k &= ~Keys.Modifiers;

      if (keyIdMap.ContainsKey(k)) {
        throw new InvalidOperationException("Can't assign a hotkey to the same key twice.");
      }

      int id = minUnusedId;
      minUnusedId++;

      bool result = RegisterHotKey(Handle, id, MOD_NOREPEAT, (UInt32) k);
      if (!result) {
        throw new Win32Exception(Marshal.GetLastWin32Error());
      }

      idHandlerMap.Add(id, new Tuple<object, EventHandler>(identifier, handler));
      keyIdMap.Add(k, id);
    }

    public void RemoveHotkey(Keys k) {
      UnregisterHotKey(Handle, keyIdMap[k]);
      idHandlerMap.Remove(keyIdMap[k]);
      keyIdMap.Remove(k);
    }

    protected override void WndProc(ref Message m) {
      base.WndProc(ref m);

      if (m.Msg == WM_HOTKEY) {
        int id = m.WParam.ToInt32();

        if (idHandlerMap.ContainsKey(id)) {
          idHandlerMap[id].Item2.Invoke(
            idHandlerMap[id].Item1,
            new KeyEventArgs((Keys)m.WParam.ToInt32())
          );
        }
      }
    }
  }
}
