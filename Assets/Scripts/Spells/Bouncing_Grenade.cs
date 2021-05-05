using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing_Grenade : MonoBehaviour
{
    public float force = 100f;
    GameObject cam;
    public float angle = 1f;
    public GameObject shockwave;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera"); ;
        Vector3 pos =  new Vector3(cam.transform.forward.x, cam.transform.forward.y + angle, cam.transform.forward.z);
        GetComponent<Rigidbody>().AddForce(cam.transform.forward * force);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Detonate();
        shockwave.transform.position = transform.position;
        GameObject clone = shockwave;
        clone = Instantiate(clone) as GameObject;
        Destroy(clone, 0.5f);
        Destroy(gameObject);
    }

    void Detonate()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }
}
