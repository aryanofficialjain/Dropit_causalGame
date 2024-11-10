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

    public float[] platformPositionsX = new float[] { -2f, 0f, 2f };
    public float yOffsetRange = 0.5f;

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
            List<float> availablePositions = new List<float>(platformPositionsX);

            for (int i = 0; i < 2; i++) // Spawn two platforms in each row
            {
                int randomIndex = Random.Range(0, availablePositions.Count);
                Vector3 platformPosition = transform.position;
                platformPosition.x = availablePositions[randomIndex];
                availablePositions.RemoveAt(randomIndex);
                platformPosition.y += Random.Range(-yOffsetRange, yOffsetRange);

                GameObject newPlatform = InstantiateRandomPlatform(platformPosition);

                if (newPlatform)
                {
                    newPlatform.transform.parent = transform;
                }
            }

            current_Platform_Spawn_Timer = 0;
        }
    }

    GameObject InstantiateRandomPlatform(Vector3 position)
    {
        GameObject newPlatform = null;

        // Select the type of platform to spawn
        if (platform_Spawn_Count == 4 && Random.Range(0, 2) == 0)
        {
            newPlatform = Instantiate(breakablePlatform, position, Quaternion.identity);
            platform_Spawn_Count = 0;
        }
        else if (Random.Range(0, 2) > 0)
        {
            newPlatform = Instantiate(platformPrefab, position, Quaternion.identity);
        }
        else
        {
            newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], position, Quaternion.identity);
        }

        return newPlatform;
    }
}