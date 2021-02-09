using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BL3TP {
  class PositionHandler {
    #region Variables

    #region UpdateMs
    private int _updateMs = 100;
    public int UpdateMs {
      get {
        return _updateMs;
      }
      set {
        _updateMs = value;
        if (!(updateTimer is null)) {
          updateTimer.Stop();
          updateTimer.Interval = value;
          updateTimer.Start();
        }
      }
    }
    #endregion UpdateMs

    #region Current World/Preset
    private string _currentWorld = null;
    private string _currentPreset = null;
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
    public string CurrentPreset {
      get {
        return _currentPreset;
      }
      private set {
        bool changed = value != _currentPreset;
        _currentPreset = value;
        if (changed) {
          CurrentPresetChanged.Invoke(this, null);
        }
      }
    }

    public event EventHandler<EventArgs> CurrentWorldChanged;
    public event EventHandler<EventArgs> CurrentPresetChanged;
    #endregion Current World/Preset

    #region Buttons Available
    private bool _saveAvailable = false;
    private bool _loadAvailable = false;
    private bool _deleteAvailable = false;

    public bool SaveAvailable {
      get {
        return _saveAvailable;
      }
      private set {
        bool changed = value != _saveAvailable;
        _saveAvailable = value;
        if (changed) {
          SaveAvailableChanged.Invoke(this, null);
        }
      }
    }
    public bool LoadAvailable {
      get {
        return _loadAvailable;
      }
      private set {
        bool changed = value != _loadAvailable;
        _loadAvailable = value;
        if (changed) {
          LoadAvailableChanged.Invoke(this, null);
        }
      }
    }
    public bool DeleteAvailable {
      get {
        return _deleteAvailable;
      }
      private set {
        bool changed = value != _deleteAvailable;
        _deleteAvailable = value;
        if (changed) {
          DeleteAvailableChanged.Invoke(this, null);
        }
      }
    }

    public event EventHandler<EventArgs> SaveAvailableChanged;
    public event EventHandler<EventArgs> LoadAvailableChanged;
    public event EventHandler<EventArgs> DeleteAvailableChanged;
    #endregion Buttons Available

    public IEnumerable<string> PresetNames {
      get {
        if (presets is null || string.IsNullOrWhiteSpace(CurrentWorld)) {
          return new List<string>();
        }
        return presets[CurrentWorld].Keys;
      }
    }

    public Func<Vect3F, (bool hasChanged, Vect3F pos)> ProcessLockedPos;

    private Timer updateTimer = null;

    private Dictionary<string, Dictionary<string, Vect3F>> presets = null;

    #endregion Variables

    public PositionHandler(Func<Vect3F, (bool hasChanged, Vect3F pos)> ProcessLockedPos) {
      this.ProcessLockedPos = ProcessLockedPos;

      presets = new Dictionary<string, Dictionary<string, Vect3F>>(); // TODO: load from settings

      updateTimer = new Timer() {
        Interval = UpdateMs
      };
      updateTimer.Tick += new EventHandler(Update);
      updateTimer.Start();
    }

    public void Save(string name) {
      if (!string.IsNullOrWhiteSpace(CurrentWorld)) {
        // TODO: save settings
        presets[CurrentWorld][name] = GameHook.Position;
      }
    }

    public void Load(string name) {
      if (!string.IsNullOrWhiteSpace(CurrentWorld) && presets[CurrentWorld].ContainsKey(name)) {
        GameHook.Position = presets[CurrentWorld][name];
      }
    }

    public void Delete(string name) {
      if (!string.IsNullOrWhiteSpace(CurrentWorld)) {
        // TODO: save settings
        presets[CurrentWorld].Remove(name);
        if (CurrentPreset == name) {
          CurrentPreset = null;
        }
      }
    }
    
    public void Select(string name) {
      if (!string.IsNullOrWhiteSpace(CurrentWorld) && presets[CurrentWorld].ContainsKey(name)) {
        CurrentPreset = name;
      }
    }

    private void Update(object sender, EventArgs e) {
      if (!GameHook.IsHooked) {
        if (!GameHook.TryHook()) {
          SaveAvailable = false;
          LoadAvailable = false;
          return;
        }
      }

      try {
        Vect3F pos = GameHook.Position;
        (bool hasChanged, Vect3F newPos) = ProcessLockedPos(pos);
        if (hasChanged) {
          GameHook.Position = newPos;
        }
      } catch (Win32Exception) {
        SaveAvailable = false;
        LoadAvailable = false;
      }

      try {
        CurrentWorld = GameHook.WorldName;
      } catch (Win32Exception) {
        CurrentWorld = null;
      }
    }
  }
}
