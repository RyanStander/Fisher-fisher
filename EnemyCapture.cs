using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapture : MonoBehaviour
{
    public GameObject captureEffect=null;
    private bool isAttached;

    //Checks if entered capture zone
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harbor")
        {
            //Prevents other ships from canceling the skill check and only the grappled ship can
            if(isAttached)
            {
                //Fires this event to simply stop the grapple
                EventManager.onEarlyPlungerEnd();
                EventManager.onTogglePlungerEvent(true);
            }

            //Runs capture effect (if given) and destroys the target
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

    //Toggles the isAttached bool
    public void setIsAttached(bool state)
    {
        isAttached = state;
    }
}
