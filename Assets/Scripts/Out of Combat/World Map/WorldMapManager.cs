using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

/*
This class controls the world map and which towns / dungeons are clickable
*/
public class WorldMapManager : MonoBehaviour
{
    public MapData mapData {get; set;}
    private void Awake()
    {
        LoadInMapData();


    }

    private void Start()
    {
        // TODO: Come up with and trigger all animations for the multiple Map Nodescwith artist
    }

    // This function loads in the data from the .dat file (/MapData.dat) into the scene in order to check which towns / dungeons appear
    private void LoadInMapData()
    {
        if (File.Exists(Application.persistentDataPath + "/MapData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/MapData.dat", FileMode.Open);
            MapData tempMapData = (MapData) bf.Deserialize(saveFile);
            mapData = tempMapData;
            saveFile.Close();
        }
        else
        {
            // TODO: Find out how to handle game files not being there (maybe have some fallback states or just reload entire game?)
            throw new Exception("MapData.dat not found!");
        }
    }
}
