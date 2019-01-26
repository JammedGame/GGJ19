using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject enemy;
    public float spawnRate;
    Transform moveToTarget;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
        moveToTarget = Game.Player.transform;
    }

    void LateUpdate() {
        transform.position = Game.Player.transform.position;
    }

    void Spawn()
    {
        var spawnPos = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position;
        Instantiate(enemy, spawnPos, Quaternion.LookRotation(Vector3.forward, spawnPos - Game.Player.transform.position));
    }
}
