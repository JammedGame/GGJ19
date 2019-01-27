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
    public TMPro.TextMeshProUGUI HeavyAmmoText;
    public TMPro.TextMeshProUGUI RapidAmmoText;
    public TMPro.TextMeshProUGUI RailAmmoText;

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
        UpdateAmmoDisplay();
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

    void UpdateAmmoDisplay()
    {
        HeavyAmmoText.SetText(playerScript.GetAmmo(1).ToString());
        RapidAmmoText.SetText(playerScript.GetAmmo(2).ToString());
        RailAmmoText.SetText(playerScript.GetAmmo(3).ToString());
    }
}
