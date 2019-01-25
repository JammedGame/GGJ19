using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void LateUpdate()
    {
        var player = Game.Player;
        if (player == null) { return; }

        transform.position = player.transform.position - transform.forward * 5;
    }
}
