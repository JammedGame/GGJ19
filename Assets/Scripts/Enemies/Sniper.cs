using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    public float approachLimit = 100;
    public Turret turret;

    // Update is called once per frame
    public override void Update()
    {
        if (Game.Paused) { return; }
        MoveAndOrient();
    }

    public override void MoveAndOrient()
    {
        if(Vector3.Distance(transform.position, target.position) > approachLimit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        else
        {
            turret.FireAt(target.position);
        }

        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, target.position - transform.position),
            rotSpeed * Time.deltaTime
        );
    }
}
