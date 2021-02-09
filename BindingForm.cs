using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BL3TP {
  public partial class BindingForm : Form {
    private struct BindingBoxInfo {
      public Action<Keys> setter;
      public Func<Keys> getter;
      public Action action;
    }

    private readonly MainForm main;
    private readonly Dictionary<KeybindBox, BindingBoxInfo> boxInfoMap;
    private readonly HashSet<Keys> allKeys;

    public BindingForm(MainForm form) {
      InitializeComponent();
      main = form;

      boxInfoMap = new Dictionary<KeybindBox, BindingBoxInfo>() {
        { savePosBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.savePosKey = k; },
          getter = () => { return Properties.Settings.Default.savePosKey; },
          action = () => { main.SavePosButtton_Click(savePosBox, null); }
        } },
        { loadPosBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.loadPosKey = k; },
          getter = () => { return Properties.Settings.Default.loadPosKey; },
          action = () => { main.LoadPosButton_Click(loadPosBox, null); }
        } },
        { lockBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.lockPosKey = k; },
          getter = () => { return Properties.Settings.Default.lockPosKey; },
          action = ToggleLockPos
        } },
        { prevMapBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.prevMapKey = k; },
          getter = () => { return Properties.Settings.Default.prevMapKey; },
          action = () => { main.PrevMapButton_Click(prevMapBox, null);  }
        } },
        { nextMapBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.nextMapKey = k; },
          getter = () => { return Properties.Settings.Default.nextMapKey; },
          action = () => { main.NextMapButton_Click(nextMapBox, null);  }
        } },
        { autoBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.autoKey = k; },
          getter = () => { return Properties.Settings.Default.autoKey; },
          action = () => { main.autoTeleportBox.Checked ^= true; }
        } },
        { prevStationBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.prevStationKey = k; },
          getter = () => { return Properties.Settings.Default.prevStationKey; },
          action = () => { main.PrevStationButton_Click(prevStationBox, null); }
        } },
        { nextStationBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.nextStationKey = k; },
          getter = () => { return Properties.Settings.Default.nextStationKey; },
          action = () => { main.NextStationButton_Click(nextStationBox, null); }
        } },
        { teleportBox, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.teleportKey = k; },
          getter = () => { return Properties.Settings.Default.teleportKey; },
          action = () => { main.TeleportButton_Click(teleportBox, null); }
        } },
      };

      allKeys = new HashSet<Keys>();
      foreach (KeybindBox box in boxInfoMap.Keys) {
        Keys k = boxInfoMap[box].getter.Invoke();

        if (k != Keys.None && allKeys.Contains(k)) {
          continue;
        }

        box.Keys = k;
        box.KeysChanged += InputBox_KeysChanged;
        box.KeysChangeFilter += InputBox_KeysChangeFilter;

        if (k != Keys.None) {
          main.AddHotkey(box.Keys, box, KeybindPressed);
          allKeys.Add(k);
        }
      }
    }

    private void BindingForm_FormClosing(object sender, FormClosingEventArgs e) {
      Hide();
      e.Cancel = true;
    }

    private void InputBox_KeysChanged(object sender, KeysChangedEventArgs e) {
      boxInfoMap[(KeybindBox) sender].setter.Invoke(e.New);
      Properties.Settings.Default.Save();

      // Really just checking for `Keys.None`
      if (allKeys.Contains(e.Old)) {
        main.RemoveHotkey(e.Old);
        allKeys.Remove(e.Old);
      }

      if (e.New != Keys.None) {
        main.AddHotkey(e.New, sender, KeybindPressed);
        allKeys.Add(e.New);
      }
    }

    private void InputBox_KeysChangeFilter(object sender, KeysChangeFilterEventArgs e) {
      if (e.New != Keys.None && allKeys.Contains(e.New)) {
        e.Block = true;
      }
    }

    private void KeybindPressed(object sender, EventArgs e) {
      foreach (KeybindBox box in boxInfoMap.Keys) {
        if (box.BeingConfigured) {
          return;
        }
      }

      boxInfoMap[(KeybindBox) sender].action.Invoke();
    }

    // Check which state the majority of boxes are in and invert based off of that
    private void ToggleLockPos() {
      int onCount = 0;
      if (main.xLock.Checked) {
        onCount++;
      }
      if (main.yLock.Checked) {
        onCount++;
      }
      if (main.zLock.Checked) {
        onCount++;
      }

      bool newState = onCount < 2;
      main.xLock.Checked = newState;
      main.yLock.Checked = newState;
      main.zLock.Checked = newState;
    }
  }
}
