using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverScreen : MonoBehaviour
{
    public float cooldown;
    public void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > 3f)
        {
            Game.RestartGame();
        }
    }
}
