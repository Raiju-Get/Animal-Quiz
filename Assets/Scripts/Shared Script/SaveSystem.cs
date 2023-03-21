using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static  class SaveSystem
{
   public static void SaveData(bool isActive)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "000_X8.cv";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, isActive);
        stream.Close();
    }

    public static bool LoadData()
    {
        string path = Application.persistentDataPath + "000_X8.cv";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        bool data = (bool)formatter.Deserialize(stream);
        stream.Close();
        return data;   
    }
}
