using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Grappling : MonoBehaviour
{
    private GameObject player;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    private LineRenderer lineRenderer;
    private GameObject shootingPos;
    private SpringJoint joint;
    public float maxDistance = 100;
    Rigidbody rig;

    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lineRenderer = player.transform.Find("Throwing_position").GetComponent<LineRenderer>();
        shootingPos = player.transform.Find("Throwing_position").gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void DrawRope()
    {
        if (!joint)
            return;
        lineRenderer.SetPosition(0, shootingPos.transform.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void StartGrapple()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.2f;

            joint.spring = 60f;
            joint.damper = 0.1f;
            joint.massScale = 30f;

            lineRenderer.positionCount = 2;
        }
    }

    public void resetGrapplePoint()
    {
        grapplePoint = Vector3.zero;
        Destroy(joint);
        lineRenderer.positionCount = 0;
    }

    public bool isGrappling()
    {
        return joint != null;
    }

    void StopGrapple()
    {
        resetGrapplePoint();
    }
}
