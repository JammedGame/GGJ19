using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; set;}

    public AudioSource audioSrcProjectile, audioSrcExplosion, audioSrcPortal;

    public AudioClip explosion, laserHeavy, laserHit, laserRapid, obstacleHit, portal, railGun, shipEngine;

    void Start() 
    {
        Instance = this;

        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
