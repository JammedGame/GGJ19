using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StargateText : MonoBehaviour
{
    Text[] texts;

    void Start()
    {
        texts = GetComponentsInChildren<Text>();

        foreach(var text in texts)
        {
            text.color = new Color(1, 1, 1, 0);
        }
    }

    void Update()
    {
        var playerNear = !Game.Paused && !Game.Player.isDead && Vector3.Distance(Game.PlayerPosition, Game.Stargate.transform.position) < 2f;
        if (playerNear)
        {
            if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Space))
            {
                LoadLevel();
            }
        }

        var targetAlpha = playerNear ? 1 : 0;
        foreach(var text in texts)
        {
            var currentColor = text.color;
            currentColor.a = Mathf.MoveTowards(currentColor.a, targetAlpha, Time.deltaTime * 2);
            text.color = currentColor;
        }
    }

    void LoadLevel()
    {
        // save player state before loading next level,
        SavedGameState.Save(Game.Player);

        switch(SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    SceneManager.LoadScene("Level2");
                    break;
                case "Level2":
                    SceneManager.LoadScene("Level3");
                    break;
                case "Level3":
                    Game.YouWon = true;
                    Game.Paused = true;
                    break;
            }
    }
}
