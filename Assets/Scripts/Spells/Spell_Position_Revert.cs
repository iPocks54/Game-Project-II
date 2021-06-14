using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Position_Revert : Spell
{
    private GameObject player;
    private Vector3 storedPosition;
    private Vector3 storedVelocity;
    public float timer = 1f;

    
    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        if (!player)
            Initialize();
        storedVelocity = player.GetComponent<Rigidbody>().velocity;
        storedPosition = player.transform.position; 
    }

    public override void Cast(KeyCode keypressed)
    {   
        Start();
        Debug.Log("REVERT SPELL LANCE");
        Invoke("RevertToOldPosition", timer);
    }

    void RevertToOldPosition()
    {
        Debug.Log("REVERT SPELL FINI");
        player.GetComponent<Rigidbody>().velocity = storedVelocity;
        player.transform.position = storedPosition;
    }
}
