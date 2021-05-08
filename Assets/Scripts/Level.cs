using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject player;
    public Vector3 resetPos;
    public KeyCode resetKey = KeyCode.R;
    public float resetLimit = -100;
    public Stopwatch stopwatch;

    void Update()
    {
        if (Input.GetKeyDown(resetKey) || player.transform.position.y < resetLimit)
        {
            resetPlayer();
        }
    }

    public void resetPlayer()
    {
        player.transform.SetPositionAndRotation(resetPos, player.transform.localRotation);
    }

    public void setResetPos(Vector3 newResetPos)
    {
        resetPos = newResetPos;
    }

    //PLACER LA WIN PEUT ETRE OTRE PAR ENFAIT ^^^^^^ xD sale pute
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Win welplé");
            stopwatch.setPause(true);
        }
    }
}
