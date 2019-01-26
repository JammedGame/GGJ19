﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth = 100;
    public float currentHealth = 100;

    [Header("Movement")]
    public float Speed;
    public float Drag = 0.85f;
    public float RotationSpeed = 700;

    [Header("Current State")]
    public Vector3 currentSpeed;

    public void Update()
    {
        HandleMovement();
        HandleGuns();
        HandleFire();
    }

    private void HandleGuns()
    {
        int GunSelected = this.GetGunSelected();
        if(GunSelected == -1) return;
        Component[] Turrets = GetComponentsInChildren<Turret>(true);

        for(int i = 0; i < Turrets.Length; i++)
        {
            ((Turret)Turrets[i]).Enabled = false;
        }
        ((Turret)Turrets[GunSelected]).Enabled = true;

        Debug.Log(Turrets[GunSelected].transform.gameObject.name + " Enabled");
    }

    private int GetGunSelected()
    {
        if(Input.GetKeyDown("1")) return 0;
        if(Input.GetKeyDown("2")) return 1;
        if(Input.GetKeyDown("3")) return 2;
        return -1;
    }

	private void HandleFire()
	{
        foreach(var turret in GetComponentsInChildren<Turret>(true))
        {
            if (!turret.Enabled) {continue; }

            // look at target
            turret.transform.up = Game.MousePosition - turret.transform.position;

            // fire on mouse down.
            if (Input.GetMouseButton(0))
            {
                turret.FireAt(Game.MousePosition);
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) {
            print("Die");
        }
    }
}
