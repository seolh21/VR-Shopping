using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartFollow : MonoBehaviour
{
    Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        transform.position = MainCamera.transform.position + new Vector3(0,(float)-0.6,0);
        print(MainCamera.transform.position);
        transform.rotation = MainCamera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MainCamera.transform.position + MainCamera.transform.forward * 1 + new Vector3(0,(float)-0.6,0);
        transform.rotation = MainCamera.transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}
