using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatform : MonoBehaviour
{ 
    public float xmove = 0;
    public float ymove = 0;
    public float zmove = 0;
    public float movingTime;
    private float time = 0;
    private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= movingTime)
        {
            xmove = -xmove;
            ymove = -ymove;
            zmove = -zmove;
            time = 0;
        }
        pos.Translate(xmove, ymove, zmove);
    }
}
