using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StargateText : MonoBehaviour
{
    void Update()
    {
        var playerNear = Vector3.Distance(Game.PlayerPosition, Game.Stargate.transform.position) < 2f;
        if (playerNear)
        {
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Space))
            {
                LoadLevel();
            }
        }

        var targetAlpha = playerNear ? 1 : 0;
        var text = GetComponent<Text>();
        var currentColor = text.color;
        currentColor.a = Mathf.MoveTowards(currentColor.a, targetAlpha, Time.deltaTime * 2);
        text.color = currentColor;
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
