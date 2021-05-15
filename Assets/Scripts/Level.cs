using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    private GameObject player;
    public Vector3 resetPos;
    public KeyCode resetKey = KeyCode.R;
    public float resetLimit = -50;
    private Stopwatch stopwatch;
    private TMP_Text winText;
    private float time = 0;
    public float displayTime = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stopwatch = GameObject.FindGameObjectWithTag("Stopwatch").GetComponent<Stopwatch>();
        winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<TMP_Text>();
        winText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(resetKey) || player.transform.position.y < resetLimit)
        {
            resetPlayer();
        }
        if (winText.enabled == true)
        {
            time += Time.deltaTime;
            if (time >= displayTime)
            {
                time = 0;
                winText.enabled = false;
            }
        }
    }

    public void resetPlayer()
    {
        player.transform.SetPositionAndRotation(resetPos, player.transform.localRotation);
    }

    public bool setResetPos(Vector3 newResetPos)
    {
        if (newResetPos == resetPos)
            return false;
        resetPos = newResetPos;
        return true;
    }

    //PLACER LA WIN PEUT ETRE OTRE PAR ENFAIT ^^^^^^ xD sale pute
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stopwatch.setPause(true);
            winText.text = ("T4AS GAGN2 EN " + stopwatch.getTime().ToString() + " SECONDES GG BG :P");
            winText.enabled = true;
        }
    }
}
