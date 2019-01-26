using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;

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

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}