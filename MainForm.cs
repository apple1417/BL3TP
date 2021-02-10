using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BL3TP {

  public partial class MainForm : Form {
    private struct KeybindBoxInfo {
      public Action<Keys> setter;
      public Func<Keys> getter;
      public Action action;
    }

    private static readonly int[] UPDATE_OPTIONS = new int[] {
      1, 5, 10, 17, 50, 100, 500, 1000
    };

    private readonly Dictionary<KeybindBox, KeybindBoxInfo> bindInfoMap;
    private readonly HashSet<Keys> allKeys;

    private int updateMS = UPDATE_OPTIONS[5];

    private readonly List<NumericUpDown> allPosInputs;
    private readonly PositionHandler posHandler;

    public MainForm() {
      InitializeComponent();

      allPosInputs = new List<NumericUpDown>() { xInput, yInput, zInput };
      foreach (NumericUpDown input in allPosInputs) {
        input.Minimum = decimal.MinValue;
        input.Maximum = decimal.MaxValue;
      }

      #region Context Menu
      ContextMenuStrip = new ContextMenuStrip();

      ToolStripMenuItem dropDown = new ToolStripMenuItem("Polling Rate (ms)");
      foreach (int option in UPDATE_OPTIONS) {
        ToolStripMenuItem sub = new ToolStripMenuItem(option.ToString()) {
          CheckOnClick = true,
          Checked = option == updateMS
        };
        sub.Click += new EventHandler(ChangeUpdateRate);
        dropDown.DropDownItems.Add(sub);
      }
      ContextMenuStrip.Items.Add(dropDown);
      #endregion Context Menu

      #region PositionHandler
      posHandler = new PositionHandler(ProcessLockedPos) { UpdateMs = updateMS };

      posHandler.PosAvailableChanged += SaveButton_UpdateEnabled;
      posHandler.PosAvailableChanged += LoadButton_UpdateEnabled;

      presetNameBox.TextChanged += SaveButton_UpdateEnabled;
      presetNameBox.TextChanged += LoadButton_UpdateEnabled;
      presetNameBox.TextChanged += DeleteButton_UpdateEnabled;

      SaveButton_UpdateEnabled(null, null);
      LoadButton_UpdateEnabled(null, null);
      DeleteButton_UpdateEnabled(null, null);

      posHandler.CurrentWorldChanged += CurrentWorld_Changed;
      CurrentWorld_Changed(null, null);
      #endregion PositionHandler

      #region Binds
      bindInfoMap = new Dictionary<KeybindBox, KeybindBoxInfo>() {
        { saveKeybind, new KeybindBoxInfo() {
          setter = k => { Properties.Settings.Default.saveBind = k; },
          getter = () => { return Properties.Settings.Default.saveBind; },
          action = () => { SaveButton_Click(null, null); }
        } },
        { loadKeybind, new KeybindBoxInfo() {
          setter = k => { Properties.Settings.Default.loadBind = k; },
          getter = () => { return Properties.Settings.Default.loadBind; },
          action = () => { LoadButton_Click(null, null); }
        } },
        { deleteKeybind, new KeybindBoxInfo() {
          setter = k => { Properties.Settings.Default.deleteBind = k; },
          getter = () => { return Properties.Settings.Default.deleteBind; },
          action = () => { DeleteButton_Click(null, null); }
        } },
        { prevKeybind, new KeybindBoxInfo() {
          setter = k => { Properties.Settings.Default.prevBind = k; },
          getter = () => { return Properties.Settings.Default.prevBind; },
          action = () => { ScrollPresetList(false); }
        } },
        { nextKeybind, new KeybindBoxInfo() {
          setter = k => { Properties.Settings.Default.nextBind = k; },
          getter = () => { return Properties.Settings.Default.nextBind; },
          action = () => { ScrollPresetList(true); }
        } }
      };

      allKeys = new HashSet<Keys>();
      foreach (KeybindBox box in bindInfoMap.Keys) {
        Keys k = bindInfoMap[box].getter.Invoke();

        if (k != Keys.None && allKeys.Contains(k)) {
          continue;
        }

        box.Keys = k;
        box.KeysChanged += KeybindBox_KeysChanged;
        box.KeysChangeFilter += KeybindBox_KeysChangeFilter;

        if (k != Keys.None) {
          AddHotkey(box.Keys, box, KeybindPressed);
          allKeys.Add(k);
        }
      }
      #endregion Binds
    }

    private void ChangeUpdateRate(object sender, EventArgs e) {
      ToolStripMenuItem dropDown = (ToolStripMenuItem) ContextMenuStrip.Items[0];
      for (int i = 0; i < dropDown.DropDownItems.Count; i++) {
        ToolStripMenuItem item = (ToolStripMenuItem) dropDown.DropDownItems[i];
        if (item == sender) {
          updateMS = UPDATE_OPTIONS[i];
        } else {
          item.Checked = false;
        }
      }

      posHandler.UpdateMs = updateMS;
    }

    #region Binds
    private void KeybindBox_KeysChanged(object sender, KeysChangedEventArgs e) {
      bindInfoMap[(KeybindBox) sender].setter.Invoke(e.New);
      Properties.Settings.Default.Save();

      // Really just checking for `Keys.None`
      if (allKeys.Contains(e.Old)) {
        RemoveHotkey(e.Old);
        allKeys.Remove(e.Old);
      }

      if (e.New != Keys.None) {
        AddHotkey(e.New, sender, KeybindPressed);
        allKeys.Add(e.New);
      }
    }

    private void KeybindBox_KeysChangeFilter(object sender, KeysChangeFilterEventArgs e) {
      if (e.New != Keys.None && allKeys.Contains(e.New)) {
        e.Block = true;
      }
    }

    private void KeybindPressed(object sender, EventArgs e) {
      foreach (KeybindBox box in bindInfoMap.Keys) {
        if (box.BeingConfigured) {
          return;
        }
      }

      bindInfoMap[(KeybindBox) sender].action.Invoke();
    }
    #endregion

    #region Button Events
    private void SaveButton_Click(object sender, EventArgs e) {
      string currentPreset = presetNameBox.Text;
      if (!string.IsNullOrWhiteSpace(currentPreset)) {
        posHandler.Save(currentPreset.Trim());
        UpdatePresetList();
        LoadButton_UpdateEnabled(null, null);
      }
    }

    private void SaveButton_UpdateEnabled(object sender, EventArgs e) {
      saveButton.Enabled = posHandler.PosAvailable && !string.IsNullOrWhiteSpace(presetNameBox.Text);
    }

    private void LoadButton_Click(object sender, EventArgs e) {
      string currentPreset = presetNameBox.Text;
      if (!string.IsNullOrWhiteSpace(currentPreset)) {
        Vect3F? newPos = posHandler.Load(currentPreset.Trim());

        if (newPos.HasValue) {
          allPosInputs.ForEach(input => input.ValueChanged -= PosBox_ValueChanged);
          xInput.Value = Convert.ToDecimal(newPos.Value.X);
          yInput.Value = Convert.ToDecimal(newPos.Value.Y);
          zInput.Value = Convert.ToDecimal(newPos.Value.Z);
          allPosInputs.ForEach(input => input.ValueChanged += PosBox_ValueChanged);
        }
      }
    }

    private void LoadButton_UpdateEnabled(object sender, EventArgs e) {
      loadButton.Enabled = posHandler.PosAvailable && posHandler.PresetNames.Contains(presetNameBox.Text);
    }

    private void DeleteButton_Click(object sender, EventArgs e) {
      if (presetList.SelectedItems.Count <= 0) {
        return;
      }
      foreach (ListViewItem item in presetList.SelectedItems) {
        posHandler.Delete(item.Text.Trim());
      }
      UpdatePresetList();
    }

    private void DeleteButton_UpdateEnabled(object sender, EventArgs e) {
      deleteButton.Enabled = presetList.SelectedItems.Count > 0;
    }
    #endregion Button Events

    #region Pos Box Events
    private (bool hasChanged, Vect3F pos) ProcessLockedPos(Vect3F pos) {
      allPosInputs.ForEach(input => input.ValueChanged -= PosBox_ValueChanged);

      if (xLock.Checked) {
        pos.X = Convert.ToSingle(xInput.Value);
      } else {
        xInput.Value = Convert.ToDecimal(pos.X);
      }

      if (yLock.Checked) {
        pos.Y = Convert.ToSingle(yInput.Value);
      } else {
        yInput.Value = Convert.ToDecimal(pos.Y);
      }

      if (zLock.Checked) {
        pos.Z = Convert.ToSingle(zInput.Value);
      } else {
        zInput.Value = Convert.ToDecimal(pos.Z);
      }

      allPosInputs.ForEach(input => input.ValueChanged += PosBox_ValueChanged);

      return (xLock.Checked || yLock.Checked || zLock.Checked, pos);
    }


    private void PosBox_ValueChanged(object sender, EventArgs e) {
      try {
        Vect3F pos = GameHook.Position;
        pos.X = Convert.ToSingle(xInput.Value);
        pos.Y = Convert.ToSingle(yInput.Value);
        pos.Z = Convert.ToSingle(zInput.Value);
        GameHook.Position = pos;
      } catch (Win32Exception) { }
    }

    // This just prevents the error noise when you press enter
    private void PosBox_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        e.SuppressKeyPress = true;
      }
    }
    #endregion Pos Box Events

    private void CurrentWorld_Changed(object sender, EventArgs e) {
      worldNameLabel.Text = posHandler.CurrentWorld ?? "Unknown";
      UpdatePresetList();
    }

    private void UpdatePresetList() {
      // It might not be the most efficent to remake the whole list each time, but it sure makes for cleaner code
      presetList.Items.Clear();

      int maxWidth = 0;
      foreach (string preset in posHandler.PresetNames) {
        ListViewItem item = new ListViewItem(preset) { ToolTipText = preset };
        presetList.Items.Add(item);

        int width = TextRenderer.MeasureText(item.Text, item.Font).Width;
        if (width > maxWidth) {
          maxWidth = width;
        }
      }
      emptyHeader.Width = maxWidth + 1;

      DeleteButton_UpdateEnabled(null, null);
    }

    private void PresetList_MouseDoubleClick(object sender, MouseEventArgs e) {
      presetNameBox.Text = presetList.FocusedItem.Text;
    }

    private void ScrollPresetList(bool forwards) {
      if (presetList.Items.Count == 0) {
        return;
      }

      string currentPreset = presetNameBox.Text.Trim();
      int newIndex = 0;
      foreach (ListViewItem item in presetList.Items) {
        if (item.Text == currentPreset) {
          newIndex = presetList.Items.IndexOf(item) + (forwards ? 1 : -1);
          break;
        }
      }

      if (newIndex == -1) {
        newIndex = presetList.Items.Count - 1;
      } else if (newIndex == presetList.Items.Count) {
        newIndex = 0;
      }

      presetNameBox.Text = presetList.Items[newIndex].Text;
    }
  }
}
