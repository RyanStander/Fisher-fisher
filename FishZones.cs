using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishZones : MonoBehaviour
{
    //the max fish amount
    [SerializeField] float fishStock=10;
    //the current fish amount
    private float _curFishStock;
    //the speed at which fish restock
    [SerializeField] float fishRestockSpeed=3;
    //the amount of fish that comes back over time
    [SerializeField] float fishRestockAmount = 1;
    // Start is called before the first frame update
    private float nextDeplete;
    void Start()
    {
        _curFishStock = fishStock;

        InvokeRepeating("Regenerate", fishRestockSpeed, fishRestockSpeed);
    }
    //regenerating the fish amount so that the supply can come back
    private void Regenerate()
    {
        //if missing fish they will repopulate over time
        if (_curFishStock < fishStock)
            _curFishStock += fishRestockAmount;

        if (_curFishStock > fishStock)
            _curFishStock = fishStock;
    }
    public void DepleteFishStock(float depleteRate)
    {
        //when a fishing boat is nearby they will deplete the amount of fish in a spot over time
        if (Time.time > nextDeplete)
        {
            nextDeplete = Time.time + depleteRate;

            _curFishStock--;

            //Debug.Log("Fish are being depleted:" + _curFishStock);
        }
        if (_curFishStock < 1)
        {
            Destroy(gameObject);
        }

    }
    public float GetMaxFishStock()
    {
        return fishStock;
    }
    public float GetCurFishStock()
    {
        return _curFishStock;
    }
}
