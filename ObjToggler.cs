using UnityEngine;

public class ObjToggler : MonoBehaviour
{
    [SerializeField] GameObject toggleObjOn=null;
    [SerializeField] GameObject toggleObjOff=null;

    public void ToggleObj()
    {
        if (toggleObjOn != null)
            toggleObjOn.SetActive(true);
        if (toggleObjOff != null)
            toggleObjOff.SetActive(false);
    }
}
