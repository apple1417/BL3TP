using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BL3TP {
  class PositionHandler {
    #region Variables
    private static readonly object EditPosLock = new object();

    #region UpdateMs
    private static int WAITING_FOR_LAUNCH_UPDATE_MS = 5000;
    private bool waitingForLaunch = false;
    private int _updateMs = 17;
    public int UpdateMs {
      get {
        return _updateMs;
      }
      set {
        _updateMs = value;
        if (!(updateTimer is null) && !waitingForLaunch) {
          updateTimer.Stop();
          updateTimer.Interval = value;
          updateTimer.Start();
        }
      }
    }
    #endregion UpdateMs

    #region Current World
    private string _currentWorld = null;
    public string CurrentWorld {
      get {
        return _currentWorld;
      }
      private set {
        bool changed = value != _currentWorld;
        _currentWorld = value;
        if (changed) {
          CurrentWorldChanged.Invoke(this, null);
        }
      }
    }

    public event EventHandler<EventArgs> CurrentWorldChanged;
    #endregion Current World

    #region Preset Names
    private static readonly IEnumerable<string> emptyList = new List<string>().AsEnumerable();
    public IEnumerable<string> PresetNames {
      get {
        if (string.IsNullOrWhiteSpace(CurrentWorld) || !presets.ContainsKey(CurrentWorld)) {
          return emptyList;
        }
        return presets[CurrentWorld].Keys;
      }
    }
    #endregion Preset Names

    #region Pos Available
    private bool _posAvailable = false;

    public bool PosAvailable {
      get {
        return _posAvailable;
      }
      private set {
        bool changed = value != _posAvailable;
        _posAvailable = value;
        if (changed) {
          PosAvailableChanged.Invoke(this, null);
        }
      }
    }

    public event EventHandler<EventArgs> PosAvailableChanged;
    #endregion Pos Available

    public Func<Vect3F, (bool hasChanged, Vect3F pos)> ProcessLockedPos;

    private Timer updateTimer = null;

    private Dictionary<string, Dictionary<string, Vect3F>> presets = null;

    private bool HasWorld => !string.IsNullOrWhiteSpace(CurrentWorld) && presets.ContainsKey(CurrentWorld);

    #endregion Variables

    public PositionHandler(Func<Vect3F, (bool hasChanged, Vect3F pos)> ProcessLockedPos) {
      this.ProcessLockedPos = ProcessLockedPos;

      presets = PresetSaver.LoadPresetDict();

      updateTimer = new Timer() {
        Interval = UpdateMs
      };
      updateTimer.Tick += new EventHandler(Update);
      updateTimer.Start();
    }

    public void Save(string name) {
      if (!HasWorld) {
        presets[CurrentWorld] = new Dictionary<string, Vect3F>();
      }
      presets[CurrentWorld][name] = GameHook.Position;
      PresetSaver.SavePresetDict(presets);
    }

    public Vect3F? Load(string name) {
      if (HasWorld && presets[CurrentWorld].ContainsKey(name)) {
        lock (EditPosLock) {
          Vect3F pos = presets[CurrentWorld][name];
          GameHook.Position = pos;
          return pos;
        }
      } else {
        return null;
      }
    }

    public void Delete(string name) {
      if (HasWorld) {
        presets[CurrentWorld].Remove(name);
        if (presets[CurrentWorld].Count == 0) {
          presets.Remove(CurrentWorld);
        }
        PresetSaver.SavePresetDict(presets);
      }
    }

    private void Update(object sender, EventArgs e) {
      if (!GameHook.IsHooked) {
        if (!GameHook.TryHook()) {
          PosAvailable = false;
          // Lower the update interval while waiting to hook the game
          if (!waitingForLaunch) {
            waitingForLaunch = true;
            updateTimer.Stop();
            updateTimer.Interval = WAITING_FOR_LAUNCH_UPDATE_MS;
            updateTimer.Start();
          }
          return;
        }
      }
      if (waitingForLaunch) {
        waitingForLaunch = false;
        updateTimer.Stop();
        updateTimer.Interval = UpdateMs;
        updateTimer.Start();
      }

      // Dummy var to not cause spurious events
      bool newPosAvailable = true;
      try {
        // Lock before grabbing pos so it updates if you load
        lock (EditPosLock) {
          Vect3F pos = GameHook.Position;
          (bool hasChanged, Vect3F newPos) = ProcessLockedPos(pos);
          if (hasChanged) {
            GameHook.Position = newPos;
          }
        }
      } catch (Win32Exception) {
        newPosAvailable = false;
      }

      try {
        CurrentWorld = GameHook.WorldName;
      } catch (Win32Exception) {
        CurrentWorld = null;
        newPosAvailable = false;
      }

      PosAvailable = newPosAvailable;
    }
  }
}
