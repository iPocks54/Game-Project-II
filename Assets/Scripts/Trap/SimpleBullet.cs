using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private void Start()
    {
    }
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            FindObjectOfType<PlayerReset>().resetPlayer();
        Destroy(gameObject);
    }
}
