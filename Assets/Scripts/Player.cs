using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float Speed;
    public float Drag = 0.85f;
    public float RotationSpeed = 700;

    [Header("Current State")]
    public Vector3 currentSpeed;

    public void Update()
    {
        HandleMovement();
        HandleFire();
    }

	private void HandleFire()
	{
        if (Input.GetMouseButton(0))
        {
            foreach(var turret in GetComponentsInChildren<Turret>(true))
            {
                if(turret.Enabled)
                {
                    turret.FireAt(Game.MousePosition);
                }
            }
        }
	}

	public void HandleMovement()
    {
        Time.timeScale = Input.GetKey(KeyCode.LeftShift) ? 0.1f : 1f;

        currentSpeed.x += Speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        currentSpeed.y += Speed * Input.GetAxis("Vertical") * Time.deltaTime;

        if (currentSpeed.magnitude > 0.001f)
        {
            transform.rotation = Quaternion.RotateTowards
            (
                transform.rotation,
                Quaternion.LookRotation(Vector3.forward, currentSpeed),
                RotationSpeed * Time.deltaTime
            );
        }

        transform.position += currentSpeed.magnitude * transform.up * Time.deltaTime;
        currentSpeed *= Drag;
    }
}
