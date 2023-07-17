using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    public Text ScoreText;
    public GameObject GameOverText;
    public static GameManager Instance;

    private bool _isGameStarted = false;
    private int _currentPoints;
    private string _currentPlayer;
    private bool _isGameOver = false;
    private HighScoreData _currentData = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaceBlocks();
    }
    
    private void Update()
    {
        if (!_isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                PlayerStartsGame();
        }
        else if (_isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Reload main game screen to try again any time
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Start the game for the player
    /// </summary>
    private void PlayerStartsGame()
    {
        _isGameStarted = true;
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();

        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
    }
    
    /// <summary>
    /// Builds out the blocks in the level
    /// </summary>
    private void PlaceBlocks()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }
    
    /// <summary>
    /// Add a points to the ui display 
    /// </summary>
    /// <param name="point"></param>
    public void AddPoint(int point)
    {
        _currentPoints += point;
        _currentData.Score = _currentPoints;
        ScoreText.text = $"Score : {_currentPoints}";
    }

    /// <summary>
    /// Game is over reset game
    /// </summary>
    public void GameOver()
    {
        // get high score for this player data
        // check for a high score
        HighScoreData highScore = SaveUtility.LoadData();
        
        // check if the number is > highscore
        // check for a high score
        if (_currentData.Score > highScore.Score)
        {
            // a new high score save it and display it
            SaveUtility.SaveData(_currentData);
        }
        
        _isGameOver = true;
        GameOverText.SetActive(true);
    }

    /// <summary>
    /// Resets the current player score to Zero
    /// </summary>
    public void ResetCurrentPlayerScore()
    {
        _currentData.Score = 0;
    }

    /// <summary>
    ///  Saves the player data into the current player
    /// </summary>
    /// <param name="playerData"></param>
    public void SetPlayerData(HighScoreData playerData)
    {
        _currentData.PlayerName = playerData.PlayerName;
        _currentData.Score = playerData.Score;
    }
}