using System.IO;
using UnityEngine;

/// <summary>
/// Handles saving and loading game data.
/// This will save a single high score
/// </summary>
public static class SaveUtility
{
    public static readonly string filePath = "/breakoutGame_Data.json";

    /// <summary>
    /// Save 'HighScoreData' into our json file
    /// </summary>
    /// <param name="data"><c>HighScoreData</c> to be saved</param>
    public static void SaveData(HighScoreData data)
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log($"saving: {data}");
        File.WriteAllText(Application.persistentDataPath + filePath, json);
    }
    
    /// <summary>
    /// Saves the high score data
    /// </summary>
    /// <param name="playerName">a player's name</param>
    /// <param name="score">the score amount, defaults to Zero</param>
    public static void SaveData(string playerName, int score = 0)
    {
        HighScoreData data = new()
        {
            PlayerName = playerName,
            Score = score
        };
        
        string json = JsonUtility.ToJson(data);
        Debug.Log($"saving: {data}");
        File.WriteAllText(Application.persistentDataPath + filePath, json);
    }
    
    /// <summary>
    /// Load the json save file into our HighScoreData
    /// </summary>
    /// <returns>HighScoreData found</returns>
    public static HighScoreData LoadData()
    {
        HighScoreData data = new();
        string path = Application.persistentDataPath + filePath;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<HighScoreData>(json);
        }
        
        return data;
    }
}