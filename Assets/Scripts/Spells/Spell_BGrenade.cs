using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_BGrenade : Spell
{
    public GameObject grenade;
    GameObject throwing_position;

    void Start()
    {
        grenade.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    public override void Cast()
    {
        base.Cast();
        throwing_position = GameObject.FindGameObjectWithTag("CastPosition");
        GameObject nGrenade = Instantiate(grenade, throwing_position.transform.position, Quaternion.identity);
        Destroy(nGrenade, 15);      
    }
}
