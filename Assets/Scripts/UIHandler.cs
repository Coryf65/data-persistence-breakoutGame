using System;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle UI interactions
/// </summary>
public class UIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public string levelName;

    private void Start()
    {
        // Track when a player types in our input field
        playerNameInput.onValueChanged.AddListener(UpdatedPlayerNameInput);
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
            PlayerName = playerNameInput.text
        };
        
        SaveUtility.SaveData(data);
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
        SceneManager.LoadScene(levelName);
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