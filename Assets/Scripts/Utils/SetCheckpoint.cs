﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetCheckpoint : MonoBehaviour
{
    private TMP_Text checkText;
    private bool isTrigger = false;
    private bool isDisplay = false;
    [SerializeField]
    private float displayTime = 2;
    private float time = 0;

    public GameObject animation;

    private void Start()
    {
        checkText = GameObject.FindGameObjectWithTag("CheckpointText").GetComponent<TMP_Text>();
        if (checkText)
            checkText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && FindObjectOfType<PlayerReset>().setResetPos(transform.position))
        {
            checkText.enabled = true;
            isTrigger = true;
            isDisplay = true;
            animation.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject clone = animation;
            clone = Instantiate(clone) as GameObject;
            Destroy(clone, 2f);
        }

    }

    private void stopDisplay()
    {
        checkText.enabled = false;
        time = 0;
        isTrigger = false;
        isDisplay = false;
    }

    void Update()
    {
        if (isTrigger)
        {
            if (time >= displayTime)
                stopDisplay();
            if (isDisplay)
                time += Time.deltaTime;
        }
    }
}
