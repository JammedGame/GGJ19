using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverScreen : MonoBehaviour
{
    public float cooldown;
    public Image CoverImage;

    public void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown > 2f)
        {
            CoverImage.color = new Color(1,1,1, cooldown - 2);

            if (cooldown > 3)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Home)
                    || Input.GetMouseButton(0))
                    {
                        Game.RestartGame();
                    }
            }
        }
        else
        {
            CoverImage.color = new Color(1,1,1,0);
        }
    }
}
