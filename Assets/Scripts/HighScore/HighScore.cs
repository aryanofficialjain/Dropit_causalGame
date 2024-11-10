using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance; // Singleton instance

    public Text scoreText;        // Reference to the UI Text element for the current score
    public Text highScoreText;     // Reference to the UI Text element for the high score

    private int currentScore = 0;
    private int highScore = 0;
    private Coroutine scoreCoroutine;
    private bool isScoreMultiplierActive = false; // Track multiplier state

    void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Load the high score at the start of the game
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Start the score increase coroutine
        scoreCoroutine = StartCoroutine(IncreaseScoreOverTime());

        // Update the UI with the initial scores
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Save the new high score
            PlayerPrefs.Save(); // Write to disk
            UpdateHighScoreText(); // Update the high score UI when it changes
        }

        UpdateScoreText(); // Update the current score UI
    }

    public int GetHighScore()
    {
        return highScore;
    }

    // Coroutine to increase the score every second
    private IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            AddScore(isScoreMultiplierActive ? 2 : 1); // Add 2 points if multiplier is active, else 1 point
        }
    }

    // Stop the score coroutine when the game restarts
    public void StopScoreIncrease()
    {
        if (scoreCoroutine != null)
        {
            StopCoroutine(scoreCoroutine);
        }
    }

    // Method to activate a score multiplier
    public void StartScoreMultiplier(float duration)
    {
        if (!isScoreMultiplierActive) // Activate only if it's not already active
        {
            StartCoroutine(ScoreMultiplier(duration));
        }
    }

    private IEnumerator ScoreMultiplier(float duration)
    {
        isScoreMultiplierActive = true;
        yield return new WaitForSeconds(duration);
        isScoreMultiplierActive = false;
    }

    // Method to update the score text in the UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }

    // Method to update the high score text in the UI
    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text =  highScore.ToString();
        }
    }
}