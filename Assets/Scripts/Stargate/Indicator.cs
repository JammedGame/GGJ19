using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    GameObject stargate;
    SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        stargate = Game.Stargate.gameObject;
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateToStargate();
        ShowGraphic();
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
        if(Input.GetKey(KeyCode.Space)) {

        }
    }
}
