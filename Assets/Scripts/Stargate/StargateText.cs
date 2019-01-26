using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StargateText : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        ShowText();
    }

    void ShowText()
    {
        var playerNear = Vector3.Distance(Game.PlayerPosition, Game.Stargate.transform.position) < 1f;
        if(playerNear)
        {
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Space))
            {
                LoadLevel();
            }

            GetComponent<Animator>().SetTrigger("ShowText");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("HideText");
        }
    }

    void LoadLevel()
    {
        switch(SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    SceneManager.LoadScene("Level2");
                    break;
                case "Level2":
                    SceneManager.LoadScene("Level3");
                    break;
                case "Level3":
                    SceneManager.LoadScene("Level4");
                    break;
                case "Level4":
                    SceneManager.LoadScene("Level5");
                    break;
            }
    }
}
