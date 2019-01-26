using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    Transform target;
    float strength = .5f;
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
        targetRotation = Quaternion.LookRotation (target.position - transform.position);
        str = Mathf.Min (str * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other == Game.Player) {
            Destroy(gameObject);
        }
    }
}
