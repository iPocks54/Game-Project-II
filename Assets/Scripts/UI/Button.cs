using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public void ExitScene()
    {
        Application.Quit();
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
        PlayerPrefs.SetFloat("level", scene);
        if (PauseMenu.gameIsPaused)
            FindObjectOfType<PauseMenu>().TriggerPause();
    }
    public void LoadLevel(int scene)
    {
        PlayerPrefs.SetFloat("level", scene);
        SceneManager.LoadScene(scene + 2);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene((int)PlayerPrefs.GetFloat("level"));
        if (PauseMenu.gameIsPaused)
            FindObjectOfType<PauseMenu>().TriggerPause();
    }
}
