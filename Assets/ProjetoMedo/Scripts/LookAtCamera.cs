using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        Vector3 cameraDirection = -(mainCamera.transform.position - transform.position);
        //cameraDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(cameraDirection);
    }
}