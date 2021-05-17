using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        print("cursor la : " + Cursor.visible);
        if (!Cursor.visible || Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
