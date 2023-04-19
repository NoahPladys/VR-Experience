using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Google.Protobuf.WellKnownTypes.Field;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public static int SpawnCount = 5;
    public float MinimumTimeBetweenSpawns = 2;
    public float MaximumTimeBetweenSpawns = 4;
    public GameObject Obstacle;

    private float timeSinceLastSpawn = 0;
    private float timeForNextSpawn = 0;

    public static void ResetInstance()
    {
        SpawnCount = 5;
    }

    void Update()
    {
        if (timeForNextSpawn == 0)
            calculateNextSpawn();

        if (timeSinceLastSpawn >= timeForNextSpawn && SpawnCount > 0)
        {
            Instantiate(Obstacle, transform.position, transform.rotation);
            timeSinceLastSpawn = 0;
            SpawnCount--;
            timeForNextSpawn = 0;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }

    private void calculateNextSpawn() {
        timeForNextSpawn = UnityEngine.Random.Range(MinimumTimeBetweenSpawns, MaximumTimeBetweenSpawns);
        Debug.Log(timeForNextSpawn);
    }
}
