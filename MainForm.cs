using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BL3TP {

  public partial class MainForm : Form {
    #region Init

    private readonly List<NumericUpDown> allPosInputs;

    public MainForm() {
      InitializeComponent();

      allPosInputs = new List<NumericUpDown>() { xInput, yInput, zInput };
      foreach (NumericUpDown input in allPosInputs) {
        input.Minimum = decimal.MinValue;
        input.Maximum = decimal.MaxValue;
      }

      EnsureHooked();
      InitBinds();
      InitSaves();
      InitUpdateLoop();
    }
    #endregion Init

    #region Binds
    private struct BindingBoxInfo {
      public Action<Keys> setter;
      public Func<Keys> getter;
      public Action action;
    }
    private Dictionary<KeybindBox, BindingBoxInfo> bindInfoMap;
    private HashSet<Keys> allKeys;

    private void InitBinds() {
      bindInfoMap = new Dictionary<KeybindBox, BindingBoxInfo>() {
        { saveKeybind, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.saveBind = k; },
          getter = () => { return Properties.Settings.Default.saveBind; },
          action = () => { SaveButton_Click(saveButtton, null); }
        } },
        { loadKeybind, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.loadBind = k; },
          getter = () => { return Properties.Settings.Default.loadBind; },
          action = () => { LoadButton_Click(loadButton, null); }
        } },
        { deleteKeybind, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.deleteBind = k; },
          getter = () => { return Properties.Settings.Default.deleteBind; },
          action = () => { DeleteButton_Click(deleteButton, null); }
        } },
        { nextKeybind, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.nextBind = k; },
          getter = () => { return Properties.Settings.Default.nextBind; },
          action = () => { /* TODO */ }
        } },
        { prevKeybind, new BindingBoxInfo() {
          setter = k => { Properties.Settings.Default.prevBind = k; },
          getter = () => { return Properties.Settings.Default.prevBind; },
          action = () => { /* TODO */ }
        } }
      };

      allKeys = new HashSet<Keys>();
      foreach (KeybindBox box in bindInfoMap.Keys) {
        Keys k = bindInfoMap[box].getter.Invoke();

        if (k != Keys.None && allKeys.Contains(k)) {
          continue;
        }

        box.Keys = k;
        box.KeysChanged += InputBox_KeysChanged;
        box.KeysChangeFilter += InputBox_KeysChangeFilter;

        if (k != Keys.None) {
          AddHotkey(box.Keys, box, KeybindPressed);
          allKeys.Add(k);
        }
      }
    }

    private void InputBox_KeysChanged(object sender, KeysChangedEventArgs e) {
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

    private void InputBox_KeysChangeFilter(object sender, KeysChangeFilterEventArgs e) {
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

    #region Saves
    private Dictionary<string, Dictionary<string, Vect3F>> allPresets;

    private void InitSaves() {
      allPresets = new Dictionary<string, Dictionary<string, Vect3F>>();
    }

    private Vect3F? GetSavedPos() {
      string currentPreset = presetNameBox.Text;
      if (currentWorld is null || string.IsNullOrEmpty(currentPreset)) {
        return null;
      }
      if (allPresets.ContainsKey(currentWorld) && allPresets[currentWorld].ContainsKey(currentPreset)) {
        return allPresets[currentWorld][currentPreset];
      }
      return null;
    }

    private void SaveButton_Click(object sender, EventArgs e) {
      string currentPreset = presetNameBox.Text;
      if (!EnsureHooked() || currentWorld is null || string.IsNullOrWhiteSpace(currentPreset)) {
        return;
      }

      Vect3F pos;
      try {
        pos = GameHook.Position;
      } catch (Win32Exception) {
        UpdateButtonStates();
        return;
      }
      loadButton.Enabled = true;

      if (!allPresets.ContainsKey(currentWorld)) {
        allPresets[currentWorld] = new Dictionary<string, Vect3F>();
      }
      if (!allPresets[currentWorld].ContainsKey(currentPreset)) {
        ListViewItem item = new ListViewItem(currentPreset) { ToolTipText = currentPreset };
        presetList.Items.Add(item);
        emptyHeader.Width = Math.Max(emptyHeader.Width, TextRenderer.MeasureText(item.Text, item.Font).Width + 1);
      }
      allPresets[currentWorld][currentPreset] = pos;
      UpdateButtonStates();
    }

    private void LoadButton_Click(object sender, EventArgs e) {
      if (!EnsureHooked() || currentWorld is null) {
        UpdateButtonStates();
        return;
      }

      Vect3F? savedPos = GetSavedPos();
      if (!savedPos.HasValue) {
        UpdateButtonStates();
        return;
      }
      try {
        GameHook.Position = savedPos.Value;

        allPosInputs.ForEach(input => input.ValueChanged -= Position_ValueChanged);
        xInput.Value = Convert.ToDecimal(savedPos.Value.X);
        yInput.Value = Convert.ToDecimal(savedPos.Value.Y);
        zInput.Value = Convert.ToDecimal(savedPos.Value.Z);
        allPosInputs.ForEach(input => input.ValueChanged += Position_ValueChanged);
      } catch (Win32Exception) { }
      UpdateButtonStates();
    }

    private void DeleteButton_Click(object sender, EventArgs e) {
      // TODO
    }
    #endregion Saves

    #region Updates
    private static readonly int[] UPDATE_OPTIONS = new int[] {
      1, 5, 10, 17, 50, 100, 500, 1000
    };

    private int updateMS = UPDATE_OPTIONS[5];
    private Timer UpdateTimer;

    private string currentWorld;
    private bool pointersOk;

    private void InitUpdateLoop() {
      currentWorld = null;
      pointersOk = false;

      UpdateButtonStates();

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

      UpdateTimer = new Timer() {
        Interval = updateMS
      };
      UpdateTimer.Tick += new EventHandler(Update);
      UpdateTimer.Start();
    }

    private bool EnsureHooked() {
      if (!GameHook.IsHooked) {
        return GameHook.TryHook();
      }
      return true;
    }

    private void ChangeUpdateRate(object myObject, EventArgs myEventArgs) {
      ToolStripMenuItem dropDown = (ToolStripMenuItem) ContextMenuStrip.Items[0];
      for (int i = 0; i < dropDown.DropDownItems.Count; i++) {
        ToolStripMenuItem item = (ToolStripMenuItem) dropDown.DropDownItems[i];
        if (item == myObject) {
          updateMS = UPDATE_OPTIONS[i];
        } else {
          item.Checked = false;
        }
      }

      UpdateTimer.Stop();
      UpdateTimer.Interval = updateMS;
      UpdateTimer.Start();
    }

    private void UpdateButtonStates() {
      bool hasPos = GetSavedPos().HasValue;
      string currentPreset = presetNameBox.Text;
      allPosInputs.ForEach(input => input.Enabled = pointersOk);
      saveButtton.Enabled = pointersOk && !(currentWorld is null) && !string.IsNullOrWhiteSpace(currentPreset);
      loadButton.Enabled = pointersOk && hasPos;
      deleteButton.Enabled = hasPos;
    }

    private void Update(object myObject, EventArgs myEventArgs) {
      if (!EnsureHooked()) {
        pointersOk = false;
        UpdateButtonStates();
        return;
      }

      allPosInputs.ForEach(input => input.ValueChanged -= Position_ValueChanged);

      pointersOk = true;
      try {
        Vect3F pos = GameHook.Position;

        if (xLock.Checked) {
          pos.X = Convert.ToSingle(xInput.Value);
        } else {
          xInput.Value = Convert.ToDecimal(GameHook.Position.X);
        }

        if (yLock.Checked) {
          pos.Y = Convert.ToSingle(yInput.Value);
        } else {
          yInput.Value = Convert.ToDecimal(GameHook.Position.Y);
        }

        if (zLock.Checked) {
          pos.Z = Convert.ToSingle(zInput.Value);
        } else {
          zInput.Value = Convert.ToDecimal(GameHook.Position.Z);
        }

        if (xLock.Checked || yLock.Checked || zLock.Checked) {
          GameHook.Position = pos;
        }
      // Should be caused by invalid pointers - most likely you're on the main menu
      } catch (Win32Exception) {
        pointersOk = false;
      }

      allPosInputs.ForEach(input => input.ValueChanged += Position_ValueChanged);

      try {
        string world = GameHook.WorldName;
        if (string.IsNullOrWhiteSpace(world)) {
          worldNameLabel.Text = "Unknown World";
          pointersOk = false;
        } else {
          if (world != currentWorld) {
            presetNameBox.Text = "";
            presetList.Items.Clear();
            if (allPresets.ContainsKey(world)) {
              int maxWidth = 0;
              foreach (string preset in allPresets[world].Keys) {
                ListViewItem item = new ListViewItem(preset) { ToolTipText = preset };
                presetList.Items.Add(item);
                int width = TextRenderer.MeasureText(item.Text, item.Font).Width;
                if (width > maxWidth) {
                  maxWidth = width;
                }
              }
              emptyHeader.Width = maxWidth + 1;
            }
          }
          worldNameLabel.Text = world;
        }
        currentWorld = world;
      } catch (Win32Exception) {
        worldNameLabel.Text = "Unknown World";
        pointersOk = false;
      }

      UpdateButtonStates();
    }

    #endregion Updates

    #region Position

    private void Position_ValueChanged(object sender, EventArgs e) {
      if (!EnsureHooked()) {
        return;
      }

      try {
        Vect3F pos = GameHook.Position;
        pos.X = Convert.ToSingle(xInput.Value);
        pos.Y = Convert.ToSingle(yInput.Value);
        pos.Z = Convert.ToSingle(zInput.Value);
        GameHook.Position = pos;
      } catch (Win32Exception) { }
    }

    // This just prevents the error noise when you press enter
    private void Position_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        e.SuppressKeyPress = true;
      }
    }

    
    #endregion Position
  }
}
