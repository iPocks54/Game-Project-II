using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject player;
    private GameObject cam;
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private KeyCode pauseKey = KeyCode.Escape;
    private bool isPaused = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerPause();
            pauseUI.SetActive(isPaused);
        }
    }

    public void TriggerPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        //RAJOUTER LES SORTS APRES SUREMENT :)
        player.GetComponent<FirstPersonMovement>().enabled = !isPaused;
        player.GetComponent<Jump>().enabled = !isPaused;
        player.GetComponent<PlayerReset>().enabled = !isPaused;
        cam.GetComponent<FirstPersonLook>().enabled = !isPaused;
        Cursor.visible = isPaused;
    }
}
