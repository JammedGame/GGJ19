﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<Obstacle> Prefabs;
    public Obstacle GoldenMeteor;
    public float GoldenMeteorChance = 0.05f;
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
        var range = UnityEngine.Random.Range(3f, 20);
        var newObstacle = Instantiate(GetRandomMeteor(false), GetSpawnPosition(range), Quaternion.identity);
        SpawnedObstacles.Add(newObstacle);
        return newObstacle;
    }

	private void RepositionObstacles()
	{
        if (Game.Player == null)
        {
            return;
        }

		for (int i = 0; i < SpawnedObstacles.Count; i++)
        {
			Obstacle obstacle = SpawnedObstacles[i];
			if (obstacle == null || Vector3.Distance(obstacle.transform.position, Game.PlayerPosition) > 20f)
            {
                Destroy(obstacle);
                SpawnedObstacles[i] = Instantiate(GetRandomMeteor(true), GetSpawnPosition(20), Quaternion.identity);;
            }
        }
	}

    public Obstacle GetRandomMeteor(bool allowGOlden)
    {
        if (allowGOlden && UnityEngine.Random.Range(0f, 1f) <= GoldenMeteorChance)
        {
            return GoldenMeteor;
        }
        else
        {
            return Prefabs.GetRandom();
        }
    }

    public Vector3 GetSpawnPosition(float range)
    {
        return transform.position + Game.RandomDirection() * range;
    }
}

public static class ListExt
{
    public static T GetRandom<T>(this IList<T> list)
        => list[UnityEngine.Random.Range(0, list.Count)];
}
