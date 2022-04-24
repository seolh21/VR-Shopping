using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class followToCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;
    private int flag = 0;
    ActionBasedController controller;


    // void start()
    // {
        // controller = GetComponent<ActionBasedController>();

        // transform.position = target.position + Vector3.up * offset.y 
        //     + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
        //     + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;
    // }
    // Update is called once per frame
    void FixedUpdate() {
        // if(controller.selectAction.action.ReadValue<float>() > 0.5)
        // {
        //     RaycastHit hit;
        //     // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     Ray ray = new Ray(controller.transform.position, controller.transform.forward);
        //     if(Physics.Raycast(ray, out hit, 100.0f))
        //     {
        //         if(hit.collider.gameObject.name == this.name)
        //         {
                   
        //             flag = 1-flag;
                    
        //         }
        //     }
        // }
        // Debug.Log(flag);

        transform.position = Vector3.Lerp ( transform.position, target.position + Vector3.up * offset.y 
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z, Time.deltaTime * moveSpeed);
        
        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
        transform.rotation = target.transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}