using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject Reference;

    void LateUpdate()
    {
        var aspectRatio = Screen.width / (float)Screen.height;
        var scale = 2 * Game.Camera.orthographicSize * Mathf.Max(aspectRatio, 1);
        var position = Game.PlayerPosition + Vector3.forward;
        if(Game.Player != null)
        {
            position = Game.PlayerPosition + Vector3.forward;
        }
        else
        {
            position = Reference.transform.position;
        }
        var material = GetComponent<MeshRenderer>().material;
        var texture = material.mainTexture;

        transform.position = position;
        transform.localScale = Vector3.one * scale;
        material.mainTextureOffset = new Vector2()
        {
            x = position.x * scale / texture.width,
            y = position.y * scale / texture.height
        };
    }
}
