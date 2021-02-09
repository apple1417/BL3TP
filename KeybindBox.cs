using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BL3TP {
  public class KeybindBox : TextBox {
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool HideCaret(IntPtr hWnd);

    private static readonly KeysConverter conv = new KeysConverter();

    private const Keys CANCEL_KEY = Keys.Escape;
    private const string CONFIGURE_MESSAGE = "...";

    private Keys _keys;
    private bool _inConstructor = true;
    public Keys Keys {
      get => _keys;
      set {
        Keys old = _keys;
        _keys = value;
        Text = conv.ConvertToString(value);
        if (!_inConstructor) {
          KeysChanged?.Invoke(this, new KeysChangedEventArgs(old, _keys));
        }
      }
    }

    public bool BeingConfigured { get; private set; }

    public event EventHandler<KeysChangedEventArgs> KeysChanged;
    public event EventHandler<KeysChangeFilterEventArgs> KeysChangeFilter;

    public KeybindBox() : this(Keys.None) { }
    public KeybindBox(Keys k) : base() {
      Keys = k;
      BeingConfigured = false;

      Cursor = Cursors.Arrow;
      ReadOnly = true;

      Click += KeyBindBox_Click;
      GotFocus += KeybindBox_GotFocus;
      KeyUp += KeybindBox_KeyUp;
      LostFocus += KeyBindBox_LostFocus;

      _inConstructor = false;
    }

    public void KeyBindBox_Click(object sender, EventArgs e) {
      Text = CONFIGURE_MESSAGE;
      BeingConfigured = true;
    }

    public void KeybindBox_GotFocus(object sender, EventArgs e) {
      bool result = HideCaret(((TextBox) sender).Handle);
      if (!result) {
        throw new Win32Exception(Marshal.GetLastWin32Error());
      }
    }

    public void KeybindBox_KeyUp(object sender, KeyEventArgs e) {
      if (!BeingConfigured) {
        return;
      }

      BeingConfigured = false;
      if (e.KeyCode == CANCEL_KEY) {
        Text = conv.ConvertToString(Keys);
        return;
      }

      Keys newKeys = e.KeyCode == Keys ? Keys.None : e.KeyCode;
      KeysChangeFilterEventArgs args = new KeysChangeFilterEventArgs(Keys, newKeys);
      KeysChangeFilter?.Invoke(this, args);

      if (!args.Block) {
        Keys = newKeys;
      } else {
        Text = conv.ConvertToString(Keys);
      }
    }

    public void KeyBindBox_LostFocus(object sender, EventArgs e) {
      BeingConfigured = false;
      Text = conv.ConvertToString(Keys);
    }
  }
  public class KeysChangedEventArgs : EventArgs {
    public readonly Keys Old;
    public Keys New;

    public KeysChangedEventArgs(Keys oldKeys, Keys newKeys) {
      Old = oldKeys;
      New = newKeys;
    }
  }
  
  public class KeysChangeFilterEventArgs : KeysChangedEventArgs {
    public bool Block = false;

    public KeysChangeFilterEventArgs(Keys oldKeys, Keys newKeys) : base(oldKeys, newKeys) { }
  }
}
