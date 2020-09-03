using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapture : MonoBehaviour
{
    public GameObject captureEffect=null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Checks if entered capture zone
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harbor")
        {
            reachedCapturePoint();
            return;
        }
    }
    private void reachedCapturePoint()
    {
        //If capture effect is given
        if (captureEffect!=null)
        {
            GameObject effect = Instantiate(captureEffect, transform.position, captureEffect.transform.rotation);
            Destroy(effect, 5f);
        }

        //Destroy enemy
        Destroy(gameObject);
    }
}
