using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public InputField nameInput;
    public GameObject window;
    public GameObject menu;
    public static string Username;

    private void Start()
    {
        if (Username != null)
        {
            window.SetActive(false);
            menu.SetActive(true);
        }
        else
            menu.SetActive(false);

    }

    public void setUsername()
    {
        Username = nameInput.text;
        if (Username.Length > 3 && Username.Length < 20)
        {
            window.SetActive(false);
            menu.SetActive(true);
        }
    }
}
