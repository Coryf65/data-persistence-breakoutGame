using System;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

// TODO: https://github.com/Zhangshuzz/Data-Persistence-Project/blob/main/Assets/Scripts/DeathZone.cs
// TODO: https://github.com/yuzu-tamaki/Unity-Learn-DataPersistance/blob/main/Assets/Scripts/UIBestScore.cs
// https://learn.unity.com/tutorial/submission-data-persistence-in-a-new-repo#60b7cfceedbc2a001fe28b61

/// <summary>
/// Handle UI interactions
/// </summary>
[DefaultExecutionOrder(1000)]
public class UIHandler : MonoBehaviour
{
    public TMP_InputField PlayerNameInput;
    public string LevelName;

    private void Start()
    {
        // Track when a player types in our input field
        PlayerNameInput.onValueChanged.AddListener(UpdatedPlayerNameInput);
    }

    /// <summary>
    /// Handles the action of when a player is typing into the input field
    /// </summary>
    /// <param name="newPlayerName">what was typed into the input field</param>
    private void UpdatedPlayerNameInput(string newPlayerName)
    {
        Debug.Log(newPlayerName);
        // check if the new player name matches a high score?
        
        // if it does display their high score on tha main screen
    }

    /// <summary>
    /// Save the players entered name
    /// </summary>
    public void SavePlayerName()
    {
        // if the player name is empty ? give a default ?
        HighScoreData data = new()
        {
            PlayerName = PlayerNameInput.text,
            Score = 0
        };

        Debug.Log(data);
        
        SaveUtility.SaveData(data);
        //GameManager.Instance.SetPlayerData(data);
    }

    /// <summary>
    /// Get the save data for a given player?
    /// </summary>
    /// <returns></returns>
    public HighScoreData GetPlayerName()
    {
        return SaveUtility.LoadData();
    }

    /// <summary>
    /// Load the scene from "levelName"
    /// </summary>
    public void LoadLevel()
    {
        SavePlayerName();
        SceneManager.LoadScene(LevelName);
    }

    /// <summary>
    /// Quit playing the game
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}