using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public Transform healthBarPanel;
    public GameObject healthBarPrefab;
    public float barPerHealth = 10f;

    public Color activeColor;
    public Color inactiveColor;

    private Player playerScript;
    private Image[] healthBars;
    private float maxHealthBarsCount;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = Game.Player.GetComponent<Player>();
        maxHealthBarsCount = playerScript.maxHealth / barPerHealth;

        for(int i = 0; i < maxHealthBarsCount ; i++) {
            Instantiate(healthBarPrefab, healthBarPanel);
        }

        healthBars = healthBarPanel.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {  
        float currentHealthIndex = playerScript.currentHealth / barPerHealth;
        for(int i = 0; i < maxHealthBarsCount; i++) {
            healthBars[i].color = i < currentHealthIndex ? activeColor : inactiveColor;
        }
    }
}
