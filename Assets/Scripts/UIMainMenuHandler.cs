using System;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/// <summary>
/// Handle Main Menu UI interactions
/// </summary>
[DefaultExecutionOrder(1000)]
public class UIMainMenuHandler : MonoBehaviour
{
    public TMP_InputField PlayerNameInput;
    [Header("Level to load on Play")]
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
        // TODO: maybe work on this?
        
        Debug.Log(newPlayerName);
        // check if the new player name matches a high score?
        
        // if it does display their high score on tha main screen
    }

    /// <summary>
    /// Save the players entered name
    /// </summary>
    public void SavePlayerName()
    {
        HighScoreData data = new()
        {
            PlayerName = PlayerNameInput.text,
            Score = 0
        };
        
        CurrentGameData.Instance.PlayerName = data.PlayerName;
        CurrentGameData.Instance.Score = 0;
    }

    /// <summary>
    /// Get the save data for a given player?
    /// </summary>
    /// <returns></returns>
    public HighScoreData GetHighScoreData()
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