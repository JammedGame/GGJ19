using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargateText : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowText()
    {
        if(Game.Stargate.playerNear)
        {
            GetComponent<Animator>().SetTrigger("ShowText");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("HideText");
        }
    }
}
