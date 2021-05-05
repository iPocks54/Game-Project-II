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
    private float time = 0;
    private GameObject currentBullet;
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
        currentBullet = Instantiate(bullet, throwing_position.transform.position, Quaternion.identity);
        Destroy(currentBullet, 7);
    }
}
