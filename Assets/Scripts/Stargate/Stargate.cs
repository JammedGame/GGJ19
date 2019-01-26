using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stargate : MonoBehaviour
{
    public bool playerNear;
    public string levelName;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            playerNear = true;
            if(Input.GetKeyDown(KeyCode.Home))
            {
                LoadLevel();
            }
        }
    }

    void OnTriggerLeave2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            playerNear = false;
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
