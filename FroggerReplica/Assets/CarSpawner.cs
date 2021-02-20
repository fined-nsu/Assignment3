using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnDelay = .3f;

    public GameObject car;

    public Transform[] spawnPoints;

    float nexTimeToSpawn = 0f;

    void Update()
    {
        if (nexTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nexTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
