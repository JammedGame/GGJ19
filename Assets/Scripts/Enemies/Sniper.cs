﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    public float approachLimit = 100;

    // Update is called once per frame
    public override void Update()
    {
        MoveAndOrient();
    }
    public override void MoveAndOrient()
    {
        if(Vector3.Distance(transform.position, target.position) > approachLimit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, transform.position - target.position),
            rotSpeed * Time.deltaTime
        );
    }
}
