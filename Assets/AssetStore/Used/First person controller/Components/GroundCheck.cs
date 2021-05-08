using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float maxGroundDistance = .3f;
    public bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionStay(Collision collision)
    { 
        if (!isGrounded && !collision.gameObject.CompareTag("Player"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
