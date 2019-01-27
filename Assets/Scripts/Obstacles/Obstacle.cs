using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool CanBeDestroyed;
    public GameObject Explosion;
    public float Health = 300f;

    public float RotationSpeedMin;
    public float RotationSpeedMax;

    [Header("Game State")]
    public float RotationSpeed;

    public void Start()
    {
        SetVelocity();
        RotationSpeed = UnityEngine.Random.Range(RotationSpeedMin, RotationSpeedMax);
    }

    public void Update()
    {
        transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);

        // lock to z
        var position = transform.position;
        position.z = 0;
        transform.position = position;
    }

	public void SetVelocity()
	{
        GetComponent<Rigidbody2D>().velocity = Game.RandomDirection() * 0.5f;
	}

    public bool TakeDamage(float damage)
    {
        if (!CanBeDestroyed) { return false; }

        Health -= damage;
        if (Health < 0)
        {
            Explode();
        }

        return true;
    }

    void OnCollisionEnter2D(Collision2D other) => OnHit(other.gameObject);
    void OnTriggerEnter2D(Collider2D other) => OnHit(other.gameObject);

    void OnHit(GameObject hitGO)
    {
        if(hitGO.GetComponent<Projectile>() is Projectile projectile)
        {
            projectile.Explode();
            AudioManager.Instance.audioSrcExplosion.PlayOneShot(AudioManager.Instance.explosion);
            hitGO.GetComponent<Rigidbody2D>()?.AddForce(transform.up * projectile.Speed*projectile.Speed * projectile.Force);
            TakeDamage(projectile.Damage);
        }
    }

    public void Explode()
    {
        // explode!
        var explosionVFx = GameObject.Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(explosionVFx, 0.8f);

        PowerUp.Spawn(transform.position);

        Destroy(gameObject);
    }
}
