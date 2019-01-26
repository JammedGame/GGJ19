using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    GameObject stargate;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        stargate = Game.Stargate.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RotateToStargate();
        MoveWithPlayer();
        ShowGraphic();
    }

    void MoveWithPlayer() {
        transform.position = Game.Player.transform.position;
    }

    void RotateToStargate() {
        transform.rotation = Quaternion.RotateTowards
        (
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, transform.position - stargate.transform.position),
            999f
        );
    }

    void ShowGraphic() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Fade");
        }
    }
}
