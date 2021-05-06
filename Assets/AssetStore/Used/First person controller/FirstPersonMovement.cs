using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FirstPersonMovement : MonoBehaviour
{
    public float normalSpeed = 3;
    public float runSpeed = 5;
    public float maxFOV = 90;
    public float startFOV = 80;

    public KeyCode runBind;

    Camera cam;
    Vector2 velocity;
    float t = 5;
    bool isRunning = false;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam.fieldOfView = startFOV;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(runBind))
            run();
        else if (!Input.GetKey(runBind))
            walk();
        transform.Translate(velocity.x, 0, velocity.y);

    }

    void walk()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, startFOV, t * Time.deltaTime);
        velocity.y = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");

        velocity = velocity.normalized * normalSpeed * Time.deltaTime;

        isRunning = false;
    }

    void run()
    {
        FOVChanger();
        velocity.y = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");

        velocity = velocity.normalized * runSpeed * Time.deltaTime;


    }

    void FOVChanger()
    {
        if (velocity.y > 0.02)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, maxFOV, t * Time.deltaTime);
            isRunning = true;
        }
        else if (Input.GetAxis("Vertical") < 0.8)
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, startFOV, t * Time.deltaTime * 2);
    }
    public bool getIsRunning()
    {
        return isRunning;
    }
}
