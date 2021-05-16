using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    public Vector3 tpPos;
    [SerializeField]
    public bool setCheckpoint;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = tpPos;
            if (setCheckpoint)
                FindObjectOfType<PlayerReset>().setResetPos(tpPos);
        }
    }
}
