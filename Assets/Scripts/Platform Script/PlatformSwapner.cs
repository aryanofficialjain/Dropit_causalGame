using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject[] moving_Platforms;
    public GameObject breakablePlatform;

    public float platform_Spawn_Timer = 2f;
    private float current_Platform_Spawn_Timer;
    private int platform_Spawn_Count;

    // Define three possible X positions for platforms in a row
    public float[] platformPositionsX = new float[] { -2f, 0f, 2f };
    public float yOffsetRange = 0.5f; // Range for random y offset

    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    void Update()
    {
        SpawnPlatformRow();
    }

    void SpawnPlatformRow()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;

            // Create a temporary list of positions and pick two random positions from it
            List<float> availablePositions = new List<float>(platformPositionsX);
            for (int i = 0; i < 2; i++) // Spawn only two platforms
            {
                int randomIndex = Random.Range(0, availablePositions.Count);
                Vector3 temp = transform.position;
                temp.x = availablePositions[randomIndex];
                availablePositions.RemoveAt(randomIndex); // Remove chosen position to avoid duplication

                // Add a small random y-offset to create variety in height
                temp.y += Random.Range(-yOffsetRange, yOffsetRange);

                GameObject newPlatform = null;

                // Randomly select the type of platform to spawn
                if (platform_Spawn_Count == 4 && Random.Range(0, 2) == 0)
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                    platform_Spawn_Count = 0; // Reset count after breakable platform
                }
                else if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], temp, Quaternion.identity);
                }

                if (newPlatform)
                {
                    newPlatform.transform.parent = transform;
                }
            }

            current_Platform_Spawn_Timer = 0; // Reset timer after spawning row
        }
    }
}