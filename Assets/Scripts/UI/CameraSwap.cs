using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    private Transform _target=null;
    public Transform MainMenu = null;
    public Transform UpgradeMenu = null;
    public Transform LevelSelectMenu = null;
    public Camera BackgroundCam = null;
    public float camMoveSpeed = 5f;

    public void Start()
    {
        _target = BackgroundCam.transform;
    }
    public void Update()
    {
        BackgroundCam.transform.position = Vector3.Slerp(BackgroundCam.transform.position, _target.position,camMoveSpeed*Time.deltaTime);
        BackgroundCam.transform.rotation = Quaternion.Slerp(BackgroundCam.transform.rotation, _target.rotation, camMoveSpeed * Time.deltaTime);
    }
    public void SwapMainMenu()
    {
        _target = MainMenu;
    }
    public  void SwapUpgradeMenu()
    {
        _target = UpgradeMenu;
    }
    public void SwapLevelSelect()
    {
        _target = LevelSelectMenu;
    }
}
