using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReset : MonoBehaviour
{
    private GameObject player;
    public Vector3 resetPos;
    public KeyCode resetKey = KeyCode.R;
    public float resetLimit = -50;

    Transform resetTransform;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        resetTransform = player.transform;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(resetKey))
        {
            resetLevel();
        }
        if ( player.transform.position.y < resetLimit)
        {
            resetPlayer();
        }
    }

    public void resetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void resetPlayer()
    {
        player.transform.SetPositionAndRotation(resetPos, resetTransform.rotation);
    }

    public bool setResetPos(Vector3 newResetPos)
    {
        if (newResetPos == resetPos)
            return false;
        resetPos = newResetPos;
        return true;
    }
}
