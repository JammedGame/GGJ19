using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int _Type;
    // Start is called before the first frame update
    void Start()
    {
        this._Type = Random.Range(0, 5);
        Debug.Log(this._Type);
        this.ActivateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && Game.Player.isDead == false)
        {
            if(this._Type < 3)
            {
                //Game.Player.AddAmmo(this._Type);
            }
            if(this._Type == 3)
            {
                Game.Player.Heal();
            }
            Destroy(gameObject);
        }
    }

    void ActivateIcon()
    {
        Component[] Icons = GetComponentsInChildren<PowerUpIcon>(true);
        Icons[this._Type].transform.gameObject.SetActive(true);
    }

    public static void Spawn(Vector3 Position)
    {   
        Instantiate(Resources.Load<PowerUp>("PowerUp/PowerUp"), Position, Quaternion.identity);
    }
}
