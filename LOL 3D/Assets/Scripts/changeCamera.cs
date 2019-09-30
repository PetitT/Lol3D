using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera Tpc;
    
    private bool mainCameraActive = false;
    private bool tpcActive = true;

    private CursorLockMode lockmode;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.gameObject.SetActive(!mainCameraActive);
            Tpc.gameObject.SetActive(!tpcActive);

            mainCameraActive = !mainCameraActive;
            tpcActive = !tpcActive;

            if (mainCameraActive)
                lockmode = CursorLockMode.Locked;
            else
                lockmode = CursorLockMode.Confined;
        }
    }
}
