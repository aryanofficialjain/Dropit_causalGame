using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreManager : MonoBehaviour
{
    public Text scoreText;        // Reference to the UI Text element for the current score
    public Text highScoreText;     // Reference to the UI Text element for the high score

    private int currentScore = 0;
    private int highScore = 0;
    private Coroutine scoreCoroutine;

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
            AddScore(1); // Add 1 point every second
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