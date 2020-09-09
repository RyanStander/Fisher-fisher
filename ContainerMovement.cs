using UnityEngine;
using System.Collections.Generic;

public class ContainerMovement : MonoBehaviour
{
    private GameObject _currentTarget;
    private List<GameObject> _unvisitedTargets= new List<GameObject>();
    private List<GameObject> _visitedTargets= new List<GameObject>();
    [SerializeReference] string targetTag= "CargoWaypoint";
    [SerializeField]float movementSpeed = 300f;
    private float currentSpeed;
    [SerializeField] float rotationalDamp = 1f;

    [SerializeField] float detectionDistance = 6f;
    [SerializeField] float rayCastOffset = 0.7f;
    [SerializeField] float startPoint = 0f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float maxSpeed=2;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
        _unvisitedTargets.AddRange(GameObject.FindGameObjectsWithTag(targetTag));
    }
    void Update()
    {
        TargetSwitching();
        Move();
        Pathfinding();
        ReachedTarget();
        NoTargetsLeft();
    }
    private void NoTargetsLeft()
    {
        if (_unvisitedTargets.Count == 0)
        {
            _unvisitedTargets.AddRange(GameObject.FindGameObjectsWithTag(targetTag));
            _visitedTargets.Clear();
        }
    }
    private void ReachedTarget()
    {
        if (Vector3.Distance(_currentTarget.transform.position, transform.position)<7)
        {
            _visitedTargets.Add(_currentTarget);
            _unvisitedTargets.Remove(_currentTarget);
        }
    }
    void TurnToTarget()
    {
        if (_currentTarget != null)
        {
            Vector3 newPos = _currentTarget.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(newPos);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
    }
    void Move()
    {
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void Pathfinding()
    {
        //checks what is ahead of AI, depending on where this objects blocks the view of the ai it will try to turn away
        RaycastHit hit;
        Vector3 raycastOffset=Vector3.zero;
        /*these are the points i am raycasting from to check where
        collisions are happening                                */
        Vector3 left = transform.position - transform.right*rayCastOffset-transform.forward*startPoint;
        Vector3 right = transform.position + transform.right * rayCastOffset - transform.forward * startPoint;

       Debug.DrawRay(left, transform.forward*detectionDistance, Color.yellow);
       Debug.DrawRay(right, transform.forward * detectionDistance, Color.yellow);

        if (Physics.Raycast(left,transform.forward,out hit, detectionDistance))
        {
            if (!hit.collider.CompareTag(targetTag))
            {
                raycastOffset += Vector3.up;
            }
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            if (!hit.collider.CompareTag(targetTag))
            {
                raycastOffset += Vector3.down;
            }
        }
        if  (raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 25f * Time.deltaTime);
        }
        else
        {
            TurnToTarget();
        }
    }
    public GameObject GetTarget()
    {
        return _currentTarget;
    }
    private void TargetSwitching()
    {
        if (_unvisitedTargets != null)
        {
            GameObject closest = _unvisitedTargets[0];
            _currentTarget = closest;
            foreach (GameObject target in _unvisitedTargets)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < Vector3.Distance(transform.position, closest.transform.position))
                {
                    closest = target;
                    _currentTarget = target;
                }
            }
        }
    }


} 
