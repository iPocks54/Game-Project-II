using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject throwing_position;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shootingInterval = 1f;
    [SerializeField]
    private float lifeTime = 3;
    private float time = 0;
    private GameObject currentBullet;
    [SerializeField]
    private AudioSource throwSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= shootingInterval)
        {
            time = 0;
            throwBullet();
        }
    }

    private void throwBullet()
    {
        throwSound.Play();
        currentBullet = Instantiate(bullet, throwing_position.transform.position, Quaternion.identity);
        Destroy(currentBullet, lifeTime);
    }
}
