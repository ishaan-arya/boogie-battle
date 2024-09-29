using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField]
    private int initialScore = 0;

    private int player1Score;
    private int player2Score;

    // UI Elements for displaying scores
    [Header("UI Elements")]
    public Text player1ScoreText; // Assign via Inspector
    public Text player2ScoreText; // Assign via Inspector

    // Properties to access each player's score
    public int Player1Score
    {
        get { return player1Score; }
        private set
        {
            if (player1Score != value)
            {
                player1Score = value;
                // Update the UI and invoke event
                OnPlayer1ScoreChanged?.Invoke(player1Score);
                UpdatePlayer1ScoreUI();
            }
        }
    }

    public int Player2Score
    {
        get { return player2Score; }
        private set
        {
            if (player2Score != value)
            {
                player2Score = value;
                // Update the UI and invoke event
                OnPlayer2ScoreChanged?.Invoke(player2Score);
                UpdatePlayer2ScoreUI();
            }
        }
    }

    // Events triggered when the scores change
    public event Action<int> OnPlayer1ScoreChanged;
    public event Action<int> OnPlayer2ScoreChanged;

    void Awake()
    {
        // Implement Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Initializes game variables, including both players' scores.
    /// </summary>
    private void InitializeGame()
    {
        Player1Score = initialScore;
        Player2Score = initialScore;
        UpdatePlayer1ScoreUI();
        UpdatePlayer2ScoreUI();
        Debug.Log($"Game Initialized. Player 1 Score: {Player1Score}, Player 2 Score: {Player2Score}");
    }

    /// <summary>
    /// Adds a specified amount to Player 1's score.
    /// </summary>
    /// <param name="points">Points to add.</param>
    public void AddScorePlayer1(int points)
    {
        Player1Score += points;
        Debug.Log($"Player 1 Score Added: {points}. New Score: {Player1Score}");
    }

    /// <summary>
    /// Adds a specified amount to Player 2's score.
    /// </summary>
    /// <param name="points">Points to add.</param>
    public void AddScorePlayer2(int points)
    {
        Player2Score += points;
        Debug.Log($"Player 2 Score Added: {points}. New Score: {Player2Score}");
    }

    /// <summary>
    /// Resets both players' scores to the initial value.
    /// </summary>
    public void ResetScores()
    {
        Player1Score = initialScore;
        Player2Score = initialScore;
        UpdatePlayer1ScoreUI();
        UpdatePlayer2ScoreUI();
        Debug.Log($"Scores Reset. Player 1 Score: {Player1Score}, Player 2 Score: {Player2Score}");
    }

    /// <summary>
    /// Updates the UI element for Player 1's score.
    /// </summary>
    private void UpdatePlayer1ScoreUI()
    {
        if (player1ScoreText != null)
        {
            player1ScoreText.text = "Player 1 Score: " + player1Score;
        }
    }

    /// <summary>
    /// Updates the UI element for Player 2's score.
    /// </summary>
    private void UpdatePlayer2ScoreUI()
    {
        if (player2ScoreText != null)
        {
            player2ScoreText.text = "Player 2 Score: " + player2Score;
        }
    }
}
