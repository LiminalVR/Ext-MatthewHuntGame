using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RingManager : MonoBehaviour
{
    public static RingManager Instance;

    public List<RingController> RingList = new List<RingController>();
    public List<Transform> SpawnPoints;

    public RingController RingPrefab;

    public Vector3 MinSpawnDivergence;
    public Vector3 MaxSpawnDivergence;

    public int MaxRings;

    private void Start()
    {
        Instance = this;
    }

    public void SpawnRing()
    {
        if (RingManager.Instance.RingList.Count > MaxRings)
        {
            return;
        }

        var targetPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];

        var spawnPos = GetSpawnPos(targetPoint);

        var ring = Instantiate(RingPrefab, spawnPos, Quaternion.identity);

        RingManager.Instance.RingList.Add(ring);
    }

    private Vector3 GetSpawnPos(Transform targetPoint)
    {
        var xPosDelta = Random.Range(MinSpawnDivergence.x, MaxSpawnDivergence.x);
        var yPosDelta = Random.Range(MinSpawnDivergence.y, MaxSpawnDivergence.y);
        var zPosDelta = Random.Range(MinSpawnDivergence.z, MaxSpawnDivergence.z);

        var position = targetPoint.transform.position + new Vector3(xPosDelta, yPosDelta, zPosDelta);

        return position;
    }

    public void IncreaseRingLimit()
    {
        MaxRings += 10;
    }
}
