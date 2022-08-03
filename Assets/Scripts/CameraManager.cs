using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    private bool activateMainCamera = true;
    void Start()
    {
        
    }

    void Update()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    { 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameras[0].SetActive(!activateMainCamera);
            cameras[1].SetActive(activateMainCamera);
            activateMainCamera = !activateMainCamera;
        }       
    }
}
