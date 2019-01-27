using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    GameObject stargate;
    public Animator animator;

	public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        stargate = GameObject.Find("StargateGraphic");
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.Paused) { return; }

        RotateToStargate();
        MoveWithPlayer();
        Cooldown();
        ShowGraphic();
    }

    void MoveWithPlayer()
    {
        transform.position = Game.Player.transform.position;
    }

    void RotateToStargate() {
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, stargate.transform.position - transform.position),
            999f
        );
    }

    void ShowGraphic()
    {
        if(cooldown == 0)
        {
            cooldown = 5f;
            animator.SetTrigger("Fade");
        }
    }

    void Cooldown()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0) { cooldown = 0; }
        }
    }
}
