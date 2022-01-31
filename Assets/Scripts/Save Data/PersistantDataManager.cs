using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/*
This class is a persistant class that saves any changes to the .dat files while playing the game.

It follows the Singleton Design Pattern where only one instance is active at a time, and is added to every scene.
*/
public class PersistantDataManager : MonoBehaviour
{
    public static PersistantDataManager instance;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Check to see if any files have not been initialised, this could be due to running the game for the first time, or due to corruption
        if (!File.Exists(Application.persistentDataPath + "/MapData.dat"))
        {
            // Create a new file if it doesn't exist (aka first time loading in)
            BinaryFormatter bf = new BinaryFormatter();
            FileStream saveFile = File.Create(Application.persistentDataPath + "/MapData.dat");
            MapData tempMapData = new MapData();
            bf.Serialize(saveFile, tempMapData);
            saveFile.Close();
        }
    }
}
