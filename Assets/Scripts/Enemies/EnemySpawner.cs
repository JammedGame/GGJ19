using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject[] enemies;
    Transform moveToTarget;

    [Header("Game State")]
    public float spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        moveToTarget = Game.Player.transform;
    }

    void LateUpdate()
    {
        if (Game.Paused) { return; }

        transform.position = Game.Player.transform.position;
        Spawn();
    }

    void Spawn()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            var spawnPos = Game.PlayerPosition + Game.RandomDirection() * 13;
            var enemy = enemies.GetRandom().GetComponent<Enemy>();

            for(int i = 0; i < enemy.SpawnCount; i++)
            {
                Instantiate(enemy, spawnPos, Quaternion.LookRotation(Vector3.forward, spawnPos - Game.Player.transform.position));
                spawnPos += Game.RandomDirection();
            }

            spawnCooldown = spawnPeriod;
        }
    }
}
