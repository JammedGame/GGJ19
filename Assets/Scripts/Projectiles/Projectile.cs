using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Damage = 100;
    public float Force = 1f;
    public bool isEnemy;
    public GameObject Explosion;

    [Header("Game State")]
    public Vector3 StartPoint;
    public float TotalDistanceTraveled;

    public static Projectile Fire(Vector3 from, Vector3 dir, Projectile prefab)
    {
        var newProjectile = GameObject.Instantiate(prefab, from, Quaternion.LookRotation(Vector3.forward, dir));
        newProjectile.StartPoint = from;
        return newProjectile;
    }

    public void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
        TotalDistanceTraveled += Speed * Time.deltaTime;

        if (TotalDistanceTraveled > 50)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public static implicit operator Projectile(string name)
        => Resources.Load<Projectile>($"Projectiles/{name}");

    void OnCollisionEnter2D(Collision2D other) => OnHit(other.gameObject);
    void OnTriggerEnter2D(Collision2D other) => OnHit(other.gameObject);

    void OnHit(GameObject hitGO)
    {
        if(isEnemy)
        {
            if (hitGO.GetComponent<Player>() is Player player)
            {
                player.TakeDamage(Damage);
                Explode();
            }
        }
        else
        {
            if (hitGO.GetComponent<Enemy>() is Enemy enemy)
            {
                enemy.TakeDamage(Damage);
                Explode();
            }
        }

        if(hitGO.GetComponent<Obstacle>() is Obstacle obstacle)
        {
            Explode();
            hitGO.GetComponent<Rigidbody2D>()?.AddForce(transform.up * Speed*Speed * Force);
            obstacle.TakeDamage(Damage);
        }
    }

    void Explode()
    {
        if (Explosion != null)
        {
            var explostionInst = Instantiate(Explosion, transform.position, transform.rotation);
            GameObject.Destroy(explostionInst, 0.8f);
        }

        Destroy(gameObject);
    }
}