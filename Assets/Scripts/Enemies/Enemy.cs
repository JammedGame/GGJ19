using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public float currentHealth = 100;
    public float speed, force;
    public float hitDamage = 10;
    float hitDamageToTake = 100;
    public float rotSpeed = 400f;
    public int SpawnCount = 1;

    public Transform target => Game.Player.transform;

    // Update is called once per frame
    public virtual void Update()
    {
        if (Game.Paused) { return; }
        MoveAndOrient();
    }

    public virtual void MoveAndOrient()
    {
        if(Game.Player.isDead == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.RotateTowards
            (
                transform.rotation,
                Quaternion.LookRotation(Vector3.forward, target.position - transform.position),
                rotSpeed * Time.deltaTime
            );
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && Game.Player.isDead == false) {
            Game.Player.TakeDamage(hitDamage);
            Game.Player.GetComponent<Rigidbody2D>().AddForce((Game.Player.transform.position - transform.position).normalized * force);
            TakeDamage(hitDamageToTake);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            var explosionDebris = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosionDebris, 1);
        }
    }
}