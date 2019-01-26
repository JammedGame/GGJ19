using System;
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
        SetVelocity();
        RotationSpeed = UnityEngine.Random.Range(RotationSpeedMin, RotationSpeedMax);
    }

    public void Update()
    {
        transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);
    }

	public void SetVelocity()
	{
        GetComponent<Rigidbody2D>().velocity = Game.RandomDirection() * 0.5f;
	}
}
