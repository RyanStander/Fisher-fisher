using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    public int harpoonRange=15;

    private LineRenderer renderedLine;
    public LayerMask grappleLayer;
    public Transform harpoonTip, player;
    private SpringJoint joint;
    private GameObject grappledObject=null;

    void OnEnable()
    {
        EventManager.onFailedSkillCheck += StopGrapple;
    }
    void OnDisable()
    {
        EventManager.onFailedSkillCheck -= StopGrapple;
    }
    void Awake()
    {
        renderedLine = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        //Inputs to start or end grapple
        if (Input.GetMouseButtonDown(0) && !joint)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonDown(0) || !jointsAreValid())
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
        //Raycast to see if an object is hit
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, harpoonRange))
        {
            Debug.Log("Raycast hit: " + hit.collider);

            //Sets the grappled object to the collided object
            if (hit.collider.gameObject.tag!="Enemy") return;

            //Sets the current grappled object to the hit ship
            grappledObject = hit.collider.gameObject;

            //Fires off event that ship has been grappled with its paramenters
            EventManager.onStartSkillCheckEvent(grappledObject.GetComponent<EnemyEscapeEvent>().skillBarSpeed, grappledObject.GetComponent<EnemyEscapeEvent>().skillZoneThreshold, grappledObject.GetComponent<EnemyEscapeEvent>().chanceForEventPerSecond);

            //Adds the joint component and configures correctly
            joint = hit.collider.gameObject.AddComponent<SpringJoint>();///player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;

            //Sets restrictions between the points
            joint.maxDistance = 10;
            joint.minDistance = Vector3.Distance(player.position, hit.point) * 0.1f;

            //Parameters that affect the spring
            joint.spring = 10;
            joint.damper = 0;

            renderedLine.positionCount = 2;
        }
    }
    void drawRope()
    {
        //If no joints, dont draw
        if (!joint) return;

        //Keeps the connected anchor on the grappled object
        joint.connectedAnchor = player.transform.position;///grappledObject.transform.position;

        //If a joint exists, visually draw
        renderedLine.SetPosition(0,harpoonTip.position);
        renderedLine.SetPosition(1, grappledObject.transform.position);
    }

    public void StopGrapple()
    {
        //Removes total vertices, destroys the joint and nulls the grapples boat
        grappledObject = null;
        renderedLine.positionCount = 0;
        Destroy(joint);
    }

    //Checks that the jointed objects are still active/valid, if not, stop grapple
    private bool jointsAreValid()
    {
        if (joint == null) return false;
        else return true;
    }

}
