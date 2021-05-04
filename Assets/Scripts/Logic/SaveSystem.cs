using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SaveProgress(GameState playerData)
    {
        string path = Application.persistentDataPath + "progress.hate";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(playerData);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static GameData LoadProgress()
    {
        string path = Application.persistentDataPath + "progress.hate";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("save file don't exist");
            return null;
        }
    }
}
    