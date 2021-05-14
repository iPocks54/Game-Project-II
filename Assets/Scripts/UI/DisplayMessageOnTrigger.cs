using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMessageOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string messageText;
    [SerializeField]
    private float DisplayTime;
    private float time = 0;
    private DisplayMessage displayMessage;
    private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        displayMessage = GameObject.FindObjectOfType<DisplayMessage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        displayMessage.displayMessage(messageText);
        isTrigger = true;
    }

    void Update()
    {
        if (isTrigger)
        {
            if (time >= DisplayTime)
            {
                displayMessage.hideMessage();
                time = 0;
                isTrigger = false;
            }
            if (displayMessage.getIsDisplay())
            {
                time += Time.deltaTime;
            }
        }
    }
}
