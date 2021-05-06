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

    float fallSpeedModifier = 0;
    bool isFalling;
    float fallPos;

    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
       // if (!groundCheck)
          //  groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        fpm = GetComponent<FirstPersonMovement>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        fallPos = gameObject.transform.position.y;
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

        checkIfFall();
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y - (gravity * Time.deltaTime + fallSpeedModifier) ,rigidbody.velocity.z);
    }
    
    void checkIfFall()
    {
        if (gameObject.transform.position.y < fallPos)
            fallSpeedModifier += 2 * Time.deltaTime;
        
        fallPos = gameObject.transform.position.y;

        if (groundCheck.isGrounded)
            fallSpeedModifier = 0;
    }
}
