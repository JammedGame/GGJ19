using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public float currentHealth = 100;
    public float speed, force;
    public float hitDamage = 10;
    float hitDamageToTake = 100;
    public float rotSpeed = 400f;
    public int SpawnCount = 1;
    public int DebrisCount = 3;
    public int PowerUpSpawnChance;
    public List<GameObject> Debrees;

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
            Explode();
        }
    }

    public void Explode()
    {
        // spritesheet
        var explosionVFX = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionVFX, 0.8f);

        // debris
        foreach(var debree in Debrees.OrderBy(x => Random.Range(0, 100)).Take(DebrisCount))
        {
            var dir = Game.RandomDirection();
            var pos = transform.position + dir * 0.1f;
            var explosionDebris = Instantiate(debree, pos, transform.rotation);
            explosionDebris.GetComponent<Rigidbody2D>().AddForce(dir * 8);
        }

        int SpawnPowerUp = Random.Range(0, 100);
        if(SpawnPowerUp < this.PowerUpSpawnChance) PowerUp.Spawn(transform.position);

        // final destroy
        Destroy(gameObject);
    }
}