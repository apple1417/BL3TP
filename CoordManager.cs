using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BL3TP {
  class StationManager {
    private const string UNKNOWN_WORLD_NAME = "Unknown";

    private readonly Dictionary<string, Dictionary<string, Vect3F>> coordMap;
    private readonly Dictionary<string, List<string>> stationMap;
    private readonly List<string> worlds;

    private int currentWorldIdx;
    private int currentStationIdx;

    public StationManager() {
      coordMap = new Dictionary<string, Dictionary<string, Vect3F>>();
      stationMap = new Dictionary<string, List<string>>();
      worlds = new List<string>();

      currentWorldIdx = 0;
      currentStationIdx = 0;

      string currentWorld = UNKNOWN_WORLD_NAME;
      coordMap[UNKNOWN_WORLD_NAME] = new Dictionary<string, Vect3F>();
      stationMap[UNKNOWN_WORLD_NAME] = new List<string>();
      worlds.Add(UNKNOWN_WORLD_NAME);

      using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.coords ?? "")))
      using (TextFieldParser parser = new TextFieldParser(stream)) {
        parser.SetDelimiters(",");
        parser.ReadLine(); // Skip the header row

        while (!parser.EndOfData) {
          string[] row = parser.ReadFields();
          if (row[1] == "") {
            currentWorld = row[0];
            coordMap[currentWorld] = new Dictionary<string, Vect3F>();
            stationMap[currentWorld] = new List<string>();
            worlds.Add(currentWorld);
            continue;
          }

          coordMap[currentWorld][row[0]] = new Vect3F() {
            X = float.Parse(row[1]),
            Y = float.Parse(row[2]),
            Z = float.Parse(row[3])
          };
          stationMap[currentWorld].Add(row[0]);
        }
      }

      if (coordMap[UNKNOWN_WORLD_NAME].Count == 0) {
        coordMap.Remove(UNKNOWN_WORLD_NAME);
        stationMap.Remove(UNKNOWN_WORLD_NAME);
        worlds.Remove(UNKNOWN_WORLD_NAME);
      }
    }

    public string World { get => worlds[currentWorldIdx]; }
    public string Station { get => stationMap[World][currentStationIdx]; }
    public Vect3F Coords { get => coordMap[World][Station]; }

    public void NextMap() {
      currentWorldIdx = (currentWorldIdx + 1) % worlds.Count;
      currentStationIdx = 0;
    }

    public void PrevMap() {
      currentWorldIdx--;
      if (currentWorldIdx < 0) {
        currentWorldIdx = worlds.Count - 1;
      }
      currentStationIdx = 0;
    }

    public void NextStation() => currentStationIdx = (currentStationIdx + 1) % stationMap[World].Count;

    public void PrevStation() {
      currentStationIdx--;
      if (currentStationIdx < 0) {
        currentStationIdx = stationMap[World].Count - 1;
      }
    }
  }
}
