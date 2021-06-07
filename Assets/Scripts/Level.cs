using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private Stopwatch stopwatch;
    private TMP_Text winText;
    private GameObject winUI;
    public PlayfabManager playfabM;

    private void Start()
    {
        stopwatch = GameObject.FindGameObjectWithTag("Stopwatch").GetComponent<Stopwatch>();
        winUI = GameObject.FindGameObjectWithTag("WinUI");
        winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<TMP_Text>();
        winUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stopwatch.setPause(true);
            winUI.SetActive(true);
            FindObjectOfType<PauseMenu>().TriggerPause();
            //FindObjectOfType<PauseMenu>().enabled = false;
            //Time.timeScale = 1;
            winText.text = (stopwatch.getTime().ToString() + " SECONDES GG");
            //print("playfab M ? : |" + playfabM + "|");
            if (playfabM)
            {
                print("just befor the drame : " + -Mathf.RoundToInt(stopwatch.getTime() * 1000));
                playfabM.SendLeaderboard(-Mathf.RoundToInt(stopwatch.getTime() * 1000));
                playfabM.GetleaderBoard();
            }
        }
    }
}
