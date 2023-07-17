using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will hold onto the temporary in game data
/// </summary>
public class CurrentGameData : MonoBehaviour
{
    public static CurrentGameData Instance;
    public string PlayerName;
    public int Score;
    public string HighScorePlayerName;
    public int HighScoreAmount;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}