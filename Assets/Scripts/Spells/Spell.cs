﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float cooldown = 2f;
    public string spellName = "noname";

    void Start()
    {

    }
    void Update()
    {

    }

    public virtual void Cast(KeyCode keyPressed)
    {

    }
}
