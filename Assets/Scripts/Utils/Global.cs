using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public InputField nameInput;
    public GameObject window;
    public static string Username = "Bob";

    public void setUsername()
    {
        Username = nameInput.text;
        if (Username.Length > 3 && Username.Length < 20)
            window.SetActive(false);
    }
}
