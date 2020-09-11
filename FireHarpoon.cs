using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHarpoon : MonoBehaviour
{
    [Header("Attributes")]
    public int harpoonRange = 15;
    [Range(0, 10)]
    public int harpoonSpring = 5;
    [Range(0, 10)]
    public int harpoonDampener = 5;

    //Line/Rope
    private LineRenderer renderedLine;
    private SpringJoint joint;

    public Transform harpoonFirePoint, player;

    private GameObject grappledObject = null;

    void OnEnable()
    {
        EventManager.onFailedSkillCheck += StopGrapple;
        EventManager.onEarlyPlungerEnd += StopGrapple;
    }
    void OnDisable()
    {
        EventManager.onFailedSkillCheck -= StopGrapple;
        EventManager.onEarlyPlungerEnd -= StopGrapple;
    }
    void Awake()
    {
        renderedLine = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        playerInput();

        drawHarpoonRay();
    }
    private void playerInput()
    {
        //Inputs to start or end grapple
        if (Input.GetMouseButtonDown(0) && !joint)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //Called to disable the skill check event if currently active and to stop grapple
            EventManager.onEarlyPlungerEnd();
        }
        else if (!jointsAreValid())
        {
            //Called separately to mouse button
            StopGrapple();
        }
    }
    private void drawHarpoonRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(harpoonFirePoint.transform.position, -harpoonFirePoint.transform.right, out hit, harpoonRange))
        {
            //Draws the ray if hitting
            Debug.DrawRay(harpoonFirePoint.transform.position, -harpoonFirePoint.transform.right * harpoonRange, Color.green);
        }
        else
        {
            //Draws the ray if not hitting
            Debug.DrawRay(harpoonFirePoint.transform.position, -harpoonFirePoint.transform.right * harpoonRange, Color.yellow);
        }
    }

    void LateUpdate()
    {
        drawRope();
    }

    private void StartGrapple()
    {
        //Raycast to see if an object is hit
        RaycastHit hit;

        if (Physics.Raycast(harpoonFirePoint.transform.position, -harpoonFirePoint.transform.right, out hit, harpoonRange))
        {
            //Log what is being hit by the raycast within range
            Debug.Log("Raycast hit: " + hit.collider);

            //If the raycast did not hit an enemy, return
            if (hit.collider.gameObject.tag!="Enemy") return;

            //Sets the current grappled object to the hit ship
            grappledObject = hit.collider.gameObject;

            //Informs the ship that it is attached to the player boat
            grappledObject.GetComponent<EnemyCapture>().setIsAttached(true);

            //Fires off event that ship has been grappled with its paramenters
            EventManager.onStartSkillCheckEvent(grappledObject.GetComponent<EnemyEscapeEvent>().skillBarSpeed, grappledObject.GetComponent<EnemyEscapeEvent>().skillZoneThreshold, grappledObject.GetComponent<EnemyEscapeEvent>().chanceForEventPerSecond, StaticValues.PlungerStrength);

            //Adds the joint component to the hit component and configures correctly
            joint = hit.collider.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;

            //Sets restrictions between the points
            joint.maxDistance = harpoonRange;
            joint.minDistance = Vector3.Distance(harpoonFirePoint.position, hit.point) * 0.1f;

            //Parameters that affect the springiness and dampening of the harpoon
            joint.spring = harpoonSpring;
            joint.damper = harpoonDampener;

            renderedLine.positionCount = 2;
        }
    }
    private void drawRope()
    {
        //If no joint exist then return
        if (!joint) return;

        //Keeps the connected anchor on the grappled object
        joint.connectedAnchor = player.transform.position;///grappledObject.transform.position;

        //If a joint exists, visually draw
        renderedLine.SetPosition(0,harpoonFirePoint.position);
        renderedLine.SetPosition(1, grappledObject.transform.position);
    }

    public void StopGrapple()
    {
        //Informs the ship that it is no longer attached to the player boat
        if(grappledObject != null) grappledObject.GetComponent<EnemyCapture>().setIsAttached(false);

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
