using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRingSpawner : MonoBehaviour
{
    
    
    
    

    public float RingSpawnInterval = 4;
    public float CurrentSpawnTime = 0;
    public float DecreaseSpawnInterval = 0;
    public float IncreaseSpawnTimer = 20;
    //public Quaternion PlayerPos = GameManager.Instance.Player.transform.rotation; 
    
     

    // Use this for initialization
    void Start()
    {
        

    }

    // using gizmos to draw the cube in which it will be spawning to see the area in which it can spawn
    void OnDrawGizmos()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        CurrentSpawnTime += Time.deltaTime;

        DecreaseSpawnInterval += Time.deltaTime;


        // time checks in order to figure out if a ring should be spawning or not
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


        // simple key input to allow for testing the spawns
    
        if(GameManager.Instance.RingsAlive >= 30)
        {
            RingSpawnInterval = 4;  
        }
    }
    public void SpawnRings()
    {
        GameManager.Instance.SpawnRings1();
        //GameManager.Instance.SpawnRings2();
        //GameManager.Instance.SpawnRings3();
    }
    

    // using this to control how often the rings spawn
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
