using UnityEngine;
using UnityEngine.UI;

public class PlayPauseScript : MonoBehaviour
{
    public Button playPauseButton;
    private bool isGamePaused = false;

    void Start()
    {
        // Attach the TogglePlayPause function to the button click event
        playPauseButton.onClick.AddListener(TogglePlayPause);
    }

    void TogglePlayPause()
    {
        if (isGamePaused)
        {
            // Resume the game
            Time.timeScale = 1;
            isGamePaused = false;
            playPauseButton.GetComponentInChildren<Text>().text = "Pause";

            // Resume background music
            SoundManager.instance.ToggleBackgroundMusic(false);
        }
        else
        {
            // Pause the game
            Time.timeScale = 0;
            isGamePaused = true;
            playPauseButton.GetComponentInChildren<Text>().text = "Play";

            // Pause background music
            SoundManager.instance.ToggleBackgroundMusic(true);
        }
    }
}