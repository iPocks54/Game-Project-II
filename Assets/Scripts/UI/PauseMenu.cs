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
    public static bool gameIsPaused = false;

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
            pauseUI.SetActive(gameIsPaused);
        }
    }

    public void TriggerPause()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            //Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        //RAJOUTER LES SORTS APRES SUREMENT :)
        /*player.GetComponent<FirstPersonMovement>().enabled = !gameIsPaused;
        player.GetComponent<Jump>().enabled = !gameIsPaused;
        player.GetComponent<PlayerReset>().enabled = !gameIsPaused;
        cam.GetComponent<FirstPersonLook>().enabled = !gameIsPaused;*/
        Cursor.visible = gameIsPaused;
    }
}
