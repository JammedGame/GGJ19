using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Damage = 100;
    public float Force = 1f;
    public string targetName;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!string.IsNullOrEmpty(targetName) && other.gameObject.CompareTag(targetName))
        {
            other.GetComponent<Enemy>()?.TakeDamage(Damage);
            other.GetComponent<Player>()?.TakeDamage(Damage);
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed*Speed * Force);
        }
    }
}