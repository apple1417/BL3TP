using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BL3TP {
  class HintTextBox : TextBox {
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, UIntPtr wParam, IntPtr lParam);
    private const UInt32 EM_SETCUEBANNER = 0x1501;

    private string _hint = "";
    public string HintText {
      get { return _hint; }
      set {
        _hint = value;
        SendMessage(Handle, EM_SETCUEBANNER, UIntPtr.Zero, Marshal.StringToHGlobalAuto(_hint));
      }
    }
  }
}