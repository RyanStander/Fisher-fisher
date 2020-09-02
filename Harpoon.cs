using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private LineRenderer renderedLine;
    private Vector3 grapplePoint;
    public LayerMask grappleLayer;
    public Transform harpoonTip, player;
    private SpringJoint joint;
    private Transform grappledObject;

    void Awake()
    {
        renderedLine = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        //StartGrapple();
        if (Input.GetKeyDown(KeyCode.Space) && !joint)
        {
            StartGrapple();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StopGrapple();
        }
    }
    void LateUpdate()
    {
        drawRope();
    }

    void StartGrapple()
    {
        Vector3 forwardDirection = this.transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            Debug.Log("Raycast hit: " + hit.collider);
            //Debug.DrawRay(this.transform.position, forwardDirection * 50, Color.green);

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position,grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.9f;
            joint.minDistance = distanceFromPoint * 0.1f;

            joint.spring = 4;
            joint.damper = 6;
            joint.massScale =4;

            renderedLine.positionCount = 2;
        }
    }
    void drawRope()
    {
        //If no joints, dont draw
        if (!joint) return;

        //If joints, draw
        renderedLine.SetPosition(0,harpoonTip.position);
        renderedLine.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        renderedLine.positionCount = 0;
        Destroy(joint);
    }

}
