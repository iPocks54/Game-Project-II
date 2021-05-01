using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Platform : Spell
{
    GameObject throwing_position;
    public GameObject grenade;

    private GameObject currentGrenade;
    private KeyCode keyRepressed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            print(" lala : " + keyRepressed);
        if (Input.GetKeyDown(keyRepressed))
        {
                Destroy(currentGrenade);
        }
    }

    public override void Cast(KeyCode keyPressed)
    {
        keyRepressed = keyPressed;
        throwing_position = GameObject.FindGameObjectWithTag("CastPosition");
        currentGrenade = Instantiate(grenade, throwing_position.transform.position, Quaternion.identity);
        currentGrenade.GetComponent<PlatformCreate>().setKeyPressed(keyPressed);
        Destroy(currentGrenade, 5);
    }
}
