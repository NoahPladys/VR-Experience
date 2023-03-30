using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Google.Protobuf.WellKnownTypes.Field;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public static int SpawnCount = 5;
    public float TimeBetweenSpawns = 2;
    public GameObject Obstacle;

    private float timeSinceLastSpawn = 0;

    public static void ResetInstance()
    {
        SpawnCount = 5;
    }

    void Update()
    {
        if(timeSinceLastSpawn >= TimeBetweenSpawns && SpawnCount > 0)
        {
            Instantiate(Obstacle, transform.position, transform.rotation);
            timeSinceLastSpawn -= TimeBetweenSpawns;
            SpawnCount--;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }
}
