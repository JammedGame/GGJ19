using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<Obstacle> Prefabs;
    public float SpawnRadius = 12;
    public int ObstacleCount;

    [Header("Game State")]
    public List<Obstacle> SpawnedObstacles;

    void Start()
    {
        Update();
    }

    void Update()
    {
        transform.position = Game.PlayerPosition;

        while(SpawnedObstacles.Count < ObstacleCount)
        {
            SpawnNewObstacle();
        }

        RepositionObstacles();
    }

	private Obstacle SpawnNewObstacle()
	{
        var range = UnityEngine.Random.Range(3f, SpawnRadius);
        var newObstacle = Instantiate(Prefabs.GetRandom(), GetSpawnPosition(range), Quaternion.identity);
        SpawnedObstacles.Add(newObstacle);
        return newObstacle;
    }

	private void RepositionObstacles()
	{
        if (Game.Player == null)
        {
            return;
        }

        foreach(var obstacle in SpawnedObstacles)
        {
            if (Vector3.Distance(obstacle.transform.position, Game.PlayerPosition) > 20f)
            {
                obstacle.transform.position = GetSpawnPosition(SpawnRadius);
                obstacle.SetVelocity();
            }
        }
	}

    public Vector3 GetSpawnPosition(float range)
    {
        return transform.position + Game.RandomDirection() * range;
    }
}

public static class ListExt
{
    public static T GetRandom<T>(this List<T> list)
        => list[UnityEngine.Random.Range(0, list.Count)];
}
