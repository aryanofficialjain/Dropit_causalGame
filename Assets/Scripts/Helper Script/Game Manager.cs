using UnityEngine;
using UnityEngine.UI; // Include this to access UI elements
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject restartWindow; // Reference to the Game Over panel
   // Reference to the Play button
    public Button restartButton; // Reference to the Restart button

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Call this method when the player loses
    public void ShowGameOver()
    {
        restartWindow.SetActive(true); // Show the Game Over panel
    }

    public void RestartGame()
    {
        HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();
        if (highScoreManager != null)
        {
            highScoreManager.StopScoreIncrease(); // Stop score increase
        }

        // Hide the Game Over panel when restarting the game
        restartWindow.SetActive(false);

        // Restart the game immediately
        RestartAfterTime();
    }

    public void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay"); // Load the gameplay scene again immediately
    }
}