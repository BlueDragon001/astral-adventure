using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataHandler
{
    public class VolumeData
    {
        public int masterVolume = 100;
        public int sfxVolume = 100;

        public int musicVolume = 100;
    }

    public class LevelData
    {
        public string currentLevel;

        public List<string> completedLevel;

        public List<string> allLevel;
    }

    public string GetPleyerRefFilePath()
    {
        // Get the persistent data path based on the platform
        string filePath = string.Empty;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        filePath = Path.Combine(Application.persistentDataPath, "playerPref.json");
#elif UNITY_ANDROID
        filePath = Path.Combine(Application.persistentDataPath, "playerPref.json");
#endif
        return filePath;
    }

    public string GetLevelFilepath()
    {
        string filePath = string.Empty;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        filePath = Path.Combine(Application.persistentDataPath, "level.json");
#elif UNITY_ANDROID
        filePath = Path.Combine(Application.persistentDataPath, "level.json");
#endif
        return filePath;
    }

    public void SavePlayerRefData(VolumeData data)
    {
        string filePath = GetPleyerRefFilePath();
        string json = JsonUtility.ToJson(data);

        // Write the JSON data to the file
        File.WriteAllText(filePath, json);
    }

    public void SaveLevelData(LevelData data)
    {
        string filePath = GetLevelFilepath();
        string json = JsonUtility.ToJson(data);

        // Write the JSON data to the file
        File.WriteAllText(filePath, json);
    }

    public VolumeData LoadRefData()
    {
        string filePath = GetPleyerRefFilePath();

        if (File.Exists(filePath))
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<VolumeData>(json);
        }
        else
        {
            // Return default settings if the file doesn't exist
            return new VolumeData();
        }
    }

    public LevelData LoadLevelData(){
        string filePath = GetLevelFilepath();

         if (File.Exists(filePath))
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<LevelData>(json);
        }
        else
        {
            // Return default settings if the file doesn't exist
            return new LevelData();
        }
    }

}
