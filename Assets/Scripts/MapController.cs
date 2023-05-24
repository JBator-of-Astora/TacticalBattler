using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LevelControl;
using Characters;

public class MapController : MonoBehaviour
{

    [SerializeField] GameObject[] levels;
    [SerializeField] string map_name;
    [SerializeField] GameObject[] tiles;

    string dataPath;
    string mapPath;

    Character character;

    LevelInfo levelInfo;
    Map map;

    // Start is called before the first frame update
    void Start()
    {
        dataPath = Application.dataPath;
        mapPath = dataPath + "/Maps/" + map_name;

        string path = mapPath + "/Info.json";
        string info = System.IO.File.ReadAllText(path);
        levelInfo = JsonUtility.FromJson<LevelInfo>(info);

        path = mapPath + "/Map.csv";
        string [] lines = System.IO.File.ReadAllLines(path);

        map = new Map(lines, levelInfo.rows, levelInfo.columns);
        map.populate_world(ref tiles);

        character = new TestCharacter(5,5);
    }

}
