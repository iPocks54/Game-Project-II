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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(resetKey) || player.transform.position.y < resetLimit)
        {
            resetPlayer();
            //stopwatch.resetStopwatch();
        }
    }

    public void resetPlayer()
    {
        player.transform.SetPositionAndRotation(resetPos, player.transform.localRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Win welplé");
            stopwatch.setPause(true);
        }
    }
}
