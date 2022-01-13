using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving
{
    public static void Save(SpawnFurniture spawnFurniture) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scene.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(spawnFurniture);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data Load() 
    {
        string path = Application.persistentDataPath + "/scene.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
        }
        else 
        {
            return null;
        }
    }
}
