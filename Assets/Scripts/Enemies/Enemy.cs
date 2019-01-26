﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float rotSpeed = 400f;

    public Transform target;

    // Start is called before the first frame update
    public virtual void Start()
    {
        target = Game.Player.transform;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        MoveAndOrient();
    }

    public virtual void MoveAndOrient()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, transform.position - target.position),
            rotSpeed * Time.deltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}