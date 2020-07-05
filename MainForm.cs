using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarWarpHelper {
  public partial class MainForm : Form {
    private static readonly int[] UPDATE_OPTIONS = new int[] {
      1, 5, 10, 17, 50, 100, 500, 1000
    };

    private int updateMS = UPDATE_OPTIONS[2];
    private readonly Timer UpdateTimer;

    private readonly List<NumericUpDown> allPosInputs;
    private readonly StationManager stationMgr;
    private readonly BindingForm binds;

    private Vect3F? savedPos = null;

    public MainForm() {
      InitializeComponent();

      EnsureHooked();

      // This is at the very back so that I can keep using the visual editor,
      //  but needs to be at the very front at runtime for actual use
      Controls.SetChildIndex(notHookedLabel, 0);

      allPosInputs = new List<NumericUpDown>() { xInput, yInput, zInput };
      foreach (NumericUpDown input in allPosInputs) {
        input.Minimum = decimal.MinValue;
        input.Maximum = decimal.MaxValue;
      }

      stationMgr = new StationManager();
      mapLabel.Text = stationMgr.World;
      stationLabel.Text = stationMgr.Station;

      binds = new BindingForm(this);

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

      ToolStripMenuItem keybinds = new ToolStripMenuItem("Configure Keybinds");
      keybinds.Click += KeybindMenuItem_Click;
      ContextMenuStrip.Items.Add(keybinds);

      UpdateTimer = new Timer() {
        Interval = updateMS
      };
      UpdateTimer.Tick += new EventHandler(Update);
      UpdateTimer.Start();
    }

    private bool EnsureHooked() {
      if (!GameHook.IsHooked) {
        if (GameHook.TryHook()) {
          notHookedLabel.Visible = false;
        } else {
          notHookedLabel.Visible = true;
          return false;
        }
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

    private void Update(object myObject, EventArgs myEventArgs) {
      if (!EnsureHooked()) {
        return;
      }

      allPosInputs.ForEach(input => input.ValueChanged -= Position_ValueChanged);

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

        allPosInputs.ForEach(input => input.Enabled = true);

      // Should be caused by invalid pointers - most likely you're on the main menu
      } catch (Win32Exception) {
        allPosInputs.ForEach(input => input.Enabled = false);
      }

      allPosInputs.ForEach(input => input.ValueChanged += Position_ValueChanged);
    }

    private void KeybindMenuItem_Click(object sender, EventArgs e) {
      if (binds.Visible) {
        binds.BringToFront();
      } else {
        binds.Show();
      }
    }

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

    internal void SavePosButtton_Click(object sender, EventArgs e) {
      if (!EnsureHooked()) {
        return;
      }


      try {
        savedPos = GameHook.Position;
        loadPosButton.Enabled = true;
      } catch (Win32Exception) { }
    }

    internal void LoadPosButton_Click(object sender, EventArgs e) {
      if (!EnsureHooked()) {
        return;
      }

      if (savedPos.HasValue) {
        try {
          GameHook.Position = savedPos.Value;

          allPosInputs.ForEach(input => input.ValueChanged -= Position_ValueChanged);
          xInput.Value = Convert.ToDecimal(savedPos.Value.X);
          yInput.Value = Convert.ToDecimal(savedPos.Value.Y);
          zInput.Value = Convert.ToDecimal(savedPos.Value.Z);
          allPosInputs.ForEach(input => input.ValueChanged += Position_ValueChanged);
        } catch (Win32Exception) { }
      }
    }

    internal void NextMapButton_Click(object sender, EventArgs e) {
      stationMgr.NextMap();

      mapLabel.Text = stationMgr.World;
      stationLabel.Text = stationMgr.Station;

      if (autoTeleportBox.Checked) {
        TeleportButton_Click(this, null);
      }
    }

    internal void PrevMapButton_Click(object sender, EventArgs e) {
      stationMgr.PrevMap();
      
      mapLabel.Text = stationMgr.World;
      stationLabel.Text = stationMgr.Station;

      if (autoTeleportBox.Checked) {
        TeleportButton_Click(this, null);
      }
    }

    internal void NextStationButton_Click(object sender, EventArgs e) {
      stationMgr.NextStation();

      mapLabel.Text = stationMgr.World;
      stationLabel.Text = stationMgr.Station;

      if (autoTeleportBox.Checked) {
        TeleportButton_Click(this, null);
      }
    }

    internal void PrevStationButton_Click(object sender, EventArgs e) {
      stationMgr.PrevStation();

      mapLabel.Text = stationMgr.World;
      stationLabel.Text = stationMgr.Station;

      if (autoTeleportBox.Checked) {
        TeleportButton_Click(this, null);
      }
    }

    internal void TeleportButton_Click(object sender, EventArgs e) {
      if (!EnsureHooked()) {
        return;
      }

      try {
        GameHook.Position = stationMgr.Coords;

        allPosInputs.ForEach(input => input.ValueChanged -= Position_ValueChanged);
        xInput.Value = Convert.ToDecimal(stationMgr.Coords.X);
        yInput.Value = Convert.ToDecimal(stationMgr.Coords.Y);
        zInput.Value = Convert.ToDecimal(stationMgr.Coords.Z);
        allPosInputs.ForEach(input => input.ValueChanged += Position_ValueChanged);
      } catch (Win32Exception) { }
    }
  }
}
