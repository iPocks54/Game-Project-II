using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    public Vector3 tpPos;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public bool setCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = tpPos;
            if (setCheckpoint)
                FindObjectOfType<Level>().setResetPos(tpPos);
        }
    }
}
