using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followToCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + Vector3.up * offset.y 
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;
        
        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
        transform.rotation = target.transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}
