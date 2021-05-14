using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCheckpoint : MonoBehaviour
{
    //[SerializeField]
    //private Vector3 checkpointPos;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Level>().setResetPos(transform.position);
    }
}
