using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float RotationSpeedMin;
    public float RotationSpeedMax;

    [Header("Game State")]
    public float RotationSpeed;

    public void Start()
    {
        var dir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * 0.5f;
        RotationSpeed = UnityEngine.Random.Range(RotationSpeedMin, RotationSpeedMax);
    }

    public void Update()
    {
        transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);
    }
}
