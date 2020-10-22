using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRingSpawner : MonoBehaviour
{
    public float RingSpawnInterval = 4;
    public float CurrentSpawnTime = 0;
    public float DecreaseSpawnInterval = 0;
    public float IncreaseSpawnTimer = 20;
    public GameManager GameManager;

    void Update()
    {
        if (GameManager.IsGameOver)
            return;

        CurrentSpawnTime += Time.deltaTime;

        DecreaseSpawnInterval += Time.deltaTime;

        if (CurrentSpawnTime >= RingSpawnInterval)
        {
            SpawnRings();
            CurrentSpawnTime = 0;
        }
        if (DecreaseSpawnInterval >= IncreaseSpawnTimer)
        {
            IncreaseSpawnRate();
            DecreaseSpawnInterval = 0;
        }

        if(GameManager.Instance.RingsAlive >= 30)
        {
            RingSpawnInterval = 4;  
        }
    }

    public void SpawnRings()
    {
        RingManager.Instance.SpawnRing();
    }

    public void IncreaseSpawnRate()
    {
        if (RingSpawnInterval > 1)
        {
            RingSpawnInterval -= 1;
        }
        else
        {
            RingSpawnInterval = 1;
        }
    }
}
