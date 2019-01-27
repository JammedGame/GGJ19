using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouDiededPanel : MonoBehaviour
{
    Graphic[] images;
    float currentAlpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Graphic>();
        SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        var targetAlpha = Game.Player.isDead ? 1 : 0;
        SetAlpha(Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * 0.5f));

        if (Game.Player.isDead &&
            (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Space)))
        {
            Game.RestartGame();
        }
    }

    public void SetAlpha(float alpha)
    {
        currentAlpha = alpha;
        foreach(var image in images)
            image.color = new Color(1,1,1,alpha);
    }
}
