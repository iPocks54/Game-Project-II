using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spell_Manager : MonoBehaviour
{
    public Spell[] spells;
    public TMP_Text[] CDs;
    CooldownTimer[] timers = new CooldownTimer[4];
    void Start()
    {
        timers[0] = new CooldownTimer(spells[0].cooldown);
        timers[1] = new CooldownTimer(spells[1].cooldown);
        timers[2] = new CooldownTimer(spells[2].cooldown);
        timers[3] = new CooldownTimer(spells[3].cooldown);

        timers[0].TimeRemaining = 0;
        timers[1].TimeRemaining = 0;
        timers[2].TimeRemaining = 0;
        timers[3].TimeRemaining = 0;
    }

    void Update()
    {
        Inputs();
        UpdateCDs();
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

        CDs[0].text = timers[0].TimeRemaining.ToString("F1");
        CDs[1].text = timers[1].TimeRemaining.ToString("F1");
        CDs[2].text = timers[2].TimeRemaining.ToString("F1");
        CDs[3].text = timers[3].TimeRemaining.ToString("F1");

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
