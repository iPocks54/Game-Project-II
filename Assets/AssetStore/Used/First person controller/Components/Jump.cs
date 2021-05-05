using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;
    FirstPersonMovement fpm;
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;
    public float gravity = 10f;
    GameObject cam;

    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        fpm = GetComponent<FirstPersonMovement>();
        cam = GameObject.FindGameObjectWithTag("MainCamera"); ;
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);

            if (fpm.getIsRunning())
                rigidbody.AddForce(cam.transform.forward * 200);

            Jumped?.Invoke();
        }

        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y - (gravity * Time.deltaTime) ,rigidbody.velocity.z);
    }
}
