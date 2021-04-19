using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 400;
    Rigidbody rig;
    bool isDashing;

    //public GameObject dashEffect;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            isDashing = true;
    }

    private void FixedUpdate()
    {
        if (isDashing)
            Dashing();
    }

    private void Dashing()
    {
       // rig.MovePosition(rig.position + new Vector3(-4,0,0));
        rig.AddForce(transform.forward * dashSpeed, ForceMode.Force);
        isDashing = false;

        /*GameObject effect = Instantiate(dashEffect, Camera.main.transform.position, dashEffect.transform.rotation);
        effect.transform.parent = Camera.main.transform;
        effect.transform.LookAt(transform);*/
    }
}
