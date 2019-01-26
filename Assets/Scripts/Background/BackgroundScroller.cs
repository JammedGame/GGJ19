using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float Scale = 1;

    void LateUpdate()
    {
        transform.position = Game.PlayerPosition + Vector3.forward;
        GetComponent<MeshRenderer>().material.mainTextureOffset = transform.position * Scale;
    }
}
