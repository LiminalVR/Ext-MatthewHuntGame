using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDiffiultyx2 : MonoBehaviour
{
    public float RingSpawnInterval;
    public float CurrentSpawnTime = 0;
    public float DecreaseSpawnInterval = 0;
    public float IncreaseSpawnTimer = 20;
    public GameManager GameManager;
    void Start()
    {
        RingManager.Instance.IncreaseRingLimit();
    }

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

        if (GameManager.Instance.RingsAlive >= 30)
        {
            RingSpawnInterval = 13;
        }
    }

    public void SpawnRings()
    {
        RingManager.Instance.SpawnRing();
    }

    public void IncreaseSpawnRate()
    {
        if (RingSpawnInterval > 4)
        {
            RingSpawnInterval -= 1;
        }
        else
        {
            RingSpawnInterval = 3;
        }
    }
}
