using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    

    // Update is called once per frame
    public override void Update()
    {
        MoveAndOrient();
    }
    public override void MoveAndOrient()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, transform.position - target.position),
            rotSpeed * Time.deltaTime
        );
    }
}
