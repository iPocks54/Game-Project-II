using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spell_Manager : MonoBehaviour
{
    public Spell[] spells;
    public TMP_Text[] CDs;
    public TMP_Text[] names;

    CooldownTimer[] timers;
    void Start()
    {
        timers = new CooldownTimer[spells.Length];

        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] = new CooldownTimer(spells[i].cooldown);
            timers[i].TimeRemaining = 0;
            names[i].text = spells[i].spellName;
        }
    }

    void Update()
    {
        if (spells.Length != 0 && CDs.Length != 0)
        {
            Inputs();
            UpdateCDs();
        }
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpellPressed(0, KeyCode.Alpha1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpellPressed(1, KeyCode.Alpha2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SpellPressed(2, KeyCode.Alpha3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SpellPressed(3, KeyCode.Alpha4);
    }

    void UpdateCDs()
    {
        foreach (CooldownTimer timer in timers)
            timer.Update(Time.deltaTime);

        for (int i = 0; i < timers.Length; i++)
            CDs[i].text = timers[i].TimeRemaining.ToString("F1");
        

    }

    void SpellPressed(int n, KeyCode keyPressed)
    {
        if (!timers[n].IsActive)
        {
            timers[n].Start();
            spells[n].Cast(keyPressed);
        }
    }
}
