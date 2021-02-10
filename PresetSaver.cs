using System.Collections.Generic;
using System.Xml.Serialization;

namespace BL3TP {
  public static class PresetSaver {
    public class Position {
      [XmlAttribute]
      public string Name;
      [XmlAttribute]
      public float X;
      [XmlAttribute]
      public float Y;
      [XmlAttribute]
      public float Z;

      public Position() { }
      public Position(string Name, Vect3F Pos) {
        this.Name = Name;
        X = Pos.X;
        Y = Pos.Y;
        Z = Pos.Z;
      }
    }

    [XmlType("World")]
    public class World {
      [XmlAttribute]
      public string Name;
      [XmlElement("Position")]
      public List<Position> Positions;

      public World() { }
      public World(string Name, Dictionary<string, Vect3F> PosDict) {
        this.Name = Name;

        Positions = new List<Position>();
        foreach (string name in PosDict.Keys) {
          Positions.Add(new Position(name, PosDict[name]));
        }
      }
    }

    public static void SavePresetDict(Dictionary<string, Dictionary<string, Vect3F>> presets) {
      List<World> convertedPresets = new List<World>();
      foreach (string name in presets.Keys) {
        convertedPresets.Add(new World(name, presets[name]));
      }
      Properties.Settings.Default.presets = convertedPresets.ToArray();
      Properties.Settings.Default.Save();
    }

    public static Dictionary<string, Dictionary<string, Vect3F>> LoadPresetDict() {
      Dictionary<string, Dictionary<string, Vect3F>> allPresets = new Dictionary<string, Dictionary<string, Vect3F>>();
      if (Properties.Settings.Default.presets is null) {
        return allPresets;
      }

      foreach (World curWorld in Properties.Settings.Default.presets) {
        Dictionary<string, Vect3F> worldPresets = new Dictionary<string, Vect3F>();
        foreach (Position curPos in curWorld.Positions) {
          worldPresets[curPos.Name] = new Vect3F() { X = curPos.X, Y = curPos.Y, Z = curPos.Z };
        }
        allPresets[curWorld.Name] = worldPresets;
      }
      return allPresets;
    }
  }
}
