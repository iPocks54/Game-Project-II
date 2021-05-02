using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Spell
{
    public float dashSpeed = 400;
    private GameObject player;
    Rigidbody rig;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Cast(KeyCode keyPressed)
    {
        if (!player)
            Initialize();
        player.GetComponent<Rigidbody>().AddForce(player.transform.forward * dashSpeed, ForceMode.Force);
    }
}
