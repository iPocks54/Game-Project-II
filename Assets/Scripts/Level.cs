using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject player;
    public Vector3 resetPos;
    public Stopwatch stopwatch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.transform.SetPositionAndRotation(resetPos, player.transform.localRotation);
            //stopwatch.resetStopwatch();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Win welplé");
        }
    }
}
