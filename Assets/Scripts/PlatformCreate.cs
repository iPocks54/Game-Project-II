using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreate : MonoBehaviour
{
    public float force = 100f;
    GameObject cam;
    public float angle = 1f;
    public GameObject platform;
    private KeyCode keyPressed;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera"); ;
        Vector3 pos = new Vector3(cam.transform.forward.x, cam.transform.forward.y + angle, cam.transform.forward.z);
        GetComponent<Rigidbody>().AddForce(cam.transform.forward * force);
        print("lol : " + cam.transform.forward);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyPressed))
        {
            Destroy(gameObject);
        }
    }

    public void setKeyPressed(KeyCode key)
    {
        keyPressed = key;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(platform, transform.position, transform.rotation);
    }
}
