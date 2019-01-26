using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    public Color activeColor;
    public Color inactiveColor;
    public Color countInactiveColor;
    // private Image[] powerUps;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = Game.Player.GetComponent<Player>();
        setActiveGun();
    }

    // Update is called once per frame
    void Update()
    {
        setActiveGun();
    }

    void setActiveGun() {
        int i = 0;
        foreach (Transform child in transform) {
            bool selected = playerScript.activeGun == i;
            child.GetChild(0).GetComponent<Image>().color = selected ? activeColor : countInactiveColor;
            child.GetChild(1).GetComponent<Image>().color = selected ? activeColor : inactiveColor;
            i++;
        }
    }
}
