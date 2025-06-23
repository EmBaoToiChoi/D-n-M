using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string savePath => Path.Combine(Application.persistentDataPath, "savegame.json");

    public void SaveGame(int level, int score,int hp, Vector3 position)
    {
        PlayerData data = new PlayerData
        {
            level = level,
            score = score,
               hp = hp, // 
            position = position
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved: " + savePath);
    }

    public PlayerData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game Loaded");
            return data;
        }
        Debug.LogWarning("No save file found.");
        return null;
    }
    [Serializable]
    public class PlayerData
    {
        public int level;
        public int score;
        public Vector3 position;
     public int hp; 
}
}
