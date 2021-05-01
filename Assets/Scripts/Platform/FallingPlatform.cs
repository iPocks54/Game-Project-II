using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject Player;

    private bool isFalling = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            isFalling = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFalling)
        {
            transform.Translate(0, -0.2f , 0);
        }
    }
}
