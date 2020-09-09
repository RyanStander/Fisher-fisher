using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private GameObject _currentTarget;
    private GameObject[] _targets;
    [SerializeReference] string targetTag="FishingZone";
    [SerializeField]float movementSpeed = 300f;
    private float currentSpeed;
    [SerializeField] float rotationalDamp = 1f;

    [SerializeField] float detectionDistance = 6f;
    [SerializeField] float rayCastOffset = 0.7f;
    [SerializeField] float startPoint = 0f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float maxSpeed=4;

    [SerializeField] float fishingRate=2;
    private float _extraDampForCollisionAvoid = 40;//it for some reason doesnt work without
    private GameObject _player;
    private bool _isPlayerClose=false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        CheckIfPlayerClose();
        TargetSwitching();
        Move();
        Pathfinding();
        SlowIfClose();
        FishDepletion();
    }
    private void CheckIfPlayerClose()
    {
        //Debug.Log("distance is: " + Vector3.Distance(_player.transform.position, transform.position));
        if (Vector3.Distance(_player.transform.position, transform.position) < 20)
        {
            _isPlayerClose = true;
        }
        if (Vector3.Distance(_player.transform.position, transform.position)>40)
        {
            _isPlayerClose = false;
        }
    }
    private void FishDepletion()
    {
        if (Vector3.Distance(_currentTarget.transform.position, transform.position) < 5)
        {
            FishZones fz= _currentTarget.transform.root.GetComponent<FishZones>();
            fz.DepleteFishStock(fishingRate);
        }
    }
    private void SlowIfClose()
    {
        if (Vector3.Distance(_currentTarget.transform.position, transform.position)<7&&!_isPlayerClose)
        {
            currentSpeed--;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        else
        {
            currentSpeed = movementSpeed;
        }
    }
    void TurnToFish()
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
    void TurnAwayFromPlayer()
    {
        if (_currentTarget != null)
        {
            Vector3 newPos = transform.position-_player.transform.position ;
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
        Vector3 raycastOffset = Vector3.zero;
        /*these are the points i am raycasting from to check where
        collisions are happening                                */
        Vector3 left = transform.position - transform.right * rayCastOffset - transform.forward * startPoint;
        Vector3 right = transform.position + transform.right * rayCastOffset - transform.forward * startPoint;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.yellow);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.yellow);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
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
        if (raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * rotationalDamp* _extraDampForCollisionAvoid * Time.deltaTime);
        }
        else if (_isPlayerClose)
        {
            TurnAwayFromPlayer();
        }
        else
        {
            TurnToFish();
        }
    }
    public GameObject GetTarget()
    {
        return _currentTarget;
    }
    private void TargetSwitching()
    {
        _targets = GameObject.FindGameObjectsWithTag(targetTag);
        if (_targets != null)
        {
 
            GameObject closest = _targets[0];
            _currentTarget = closest;
            foreach (GameObject target in _targets)
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
