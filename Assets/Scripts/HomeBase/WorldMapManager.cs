using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

/*
This class controls the world map and which towns / dungeons are clickable
*/
public class WorldMapManager : MonoBehaviour
{
    private void Start()
    {
        LoadInMapData();


    }

    // TODO: This function loads in the data from the .dat file (/MapData.dat) into the scene in order to check which towns / dungeons appear
    private void LoadInMapData()
    {
        if (!File.Exists(Application.persistentDataPath + "/MapData.dat"))
        {
            // Create a new file if it doesn't exist (aka first time loading in)
            BinaryFormatter bf = new BinaryFormatter();
            FileStream saveFile = File.Create(Application.persistentDataPath + "/MapData.dat");
            MapData mapData = new MapData();
            bf.Serialize(saveFile, mapData);
            saveFile.Close();
        }
    }
}
