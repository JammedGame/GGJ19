using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float rotSpeed = .5f;

    Transform target;
    float str;
    Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        target = Game.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndOrient();
    }

    void MoveAndOrient() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        str = Mathf.Min (rotSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation, 
            Quaternion.LookRotation(Vector3.forward, transform.position - target.position), 
            str
        );
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other == Game.Player.GetComponent<Collision2D>()) {
            Destroy(gameObject);
        }
    }
}
