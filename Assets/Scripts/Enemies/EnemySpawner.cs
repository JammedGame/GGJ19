using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject enemy;
    public float spawnRate;
    Transform moveToTarget;
    float str;

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
        Instantiate(enemy, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, SetRotation());
    }

    Quaternion SetRotation() {
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, transform.position - Game.Player.transform.position),
            999f
        );

        return transform.rotation;
    }
}
