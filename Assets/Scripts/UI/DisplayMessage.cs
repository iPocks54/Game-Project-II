using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMessage : MonoBehaviour
{
    [SerializeField]
    private TMP_Text message;
    private bool isDisplay = false;

    // Start is called before the first frame update
    void Start()
    {
        message.enabled = false;
    }

    public void displayMessage(string messageText)
    {
        message.text = messageText;
        message.enabled = true;
        isDisplay = true;
    }

    public void hideMessage()
    {
        message.enabled = false;
        isDisplay = false;
    }

    public bool getIsDisplay()
    {
        return (isDisplay);
    }
}
