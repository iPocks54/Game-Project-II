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
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(resetKey) || player.transform.position.y < resetLimit)
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
        player.transform.SetPositionAndRotation(resetPos, player.transform.localRotation);
    }

    public bool setResetPos(Vector3 newResetPos)
    {
        if (newResetPos == resetPos)
            return false;
        resetPos = newResetPos;
        return true;
    }
}
