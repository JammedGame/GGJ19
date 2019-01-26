using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject[] enemies;
    public float spawnPeriod = 5;
    Transform moveToTarget;

    [Header("Game State")]
    public float spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnPeriod);
        moveToTarget = Game.Player.transform;
    }

    void LateUpdate()
    {
        transform.position = Game.Player.transform.position;
        Spawn();
    }

    void Spawn()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            var spawnPos = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position;
            Instantiate(enemies.GetRandom(), spawnPos, Quaternion.LookRotation(Vector3.forward, spawnPos - Game.Player.transform.position));

            spawnCooldown = spawnPeriod;
        }
    }
}
