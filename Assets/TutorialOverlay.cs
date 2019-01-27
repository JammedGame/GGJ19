using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOverlay : MonoBehaviour
{
    public static bool TutorialFinished;

    // Start is called before the first frame update
    void Start()
    {
        if (TutorialFinished)
        {
            Destroy(gameObject);
        }
        else
        {
            Game.Paused = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!TutorialFinished)
        {
            Game.Paused = true;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Home)
                || (Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)
                || Input.GetMouseButton(0))
            {
                TutorialFinished = true;
                Game.Paused = false;
                Destroy(gameObject);
            }
        }
    }
}