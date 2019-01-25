using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float Drag = 0.85f;

    [Header("Current State")]
    public Vector3 currentSpeed;

    public void Update()
    {
        currentSpeed.x += Speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        currentSpeed.y += Speed * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position += currentSpeed * Time.deltaTime;

        currentSpeed *= Drag;

        if (currentSpeed.magnitude > 0.01f)
            transform.up = currentSpeed;
    }
}
