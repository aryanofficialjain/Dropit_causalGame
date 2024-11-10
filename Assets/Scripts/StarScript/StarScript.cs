using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public float scoreMultiplierDuration = 5f; // Duration for 2x score
    public float minX = -2f;  // Minimum X position
    public float maxX = 2f;   // Maximum X position
    public float minY = -2f;  // Minimum Y position (downward)
    public float maxY = 0f;   // Maximum Y position (close to center)

    public AudioClip collectSound;  // Reference to the sound clip to play when collected
    private AudioSource audioSource;  // The AudioSource component

    void Start()
    {
        // Get the AudioSource component on the star
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            // Play the collection sound
            PlayCollectSound();

            // Trigger 2x score effect
            HighScoreManager.Instance.StartScoreMultiplier(scoreMultiplierDuration);

            // Move the collected star to a random position
            MoveStarToRandomPosition();
        }
    }

    private void PlayCollectSound()
    {
        // Ensure sound is played from SoundManager
        SoundManager.instance.StarCollectSound(); // Use the SoundManager to play the star collection sound
    }

    private void MoveStarToRandomPosition()
    {
        // Deactivate the star (makes it disappear)
        gameObject.SetActive(false);

        // Randomly choose a new position within the specified range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Move the star to the new random position
        transform.position = new Vector3(randomX, randomY, 0);

        // Reactivate the star at the new position
        gameObject.SetActive(true);
    }
}