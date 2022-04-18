using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

 public float speed = 5.0f;
 void Update()
 {
     if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.position = transform.position + new Vector3(speed * Time.deltaTime,0,0);
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.position = transform.position + new Vector3(-speed * Time.deltaTime,0,0);
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
         transform.position = transform.position + new Vector3(0,0,-speed * Time.deltaTime);
     }
     if(Input.GetKey(KeyCode.UpArrow))
     {
         transform.position = transform.position + new Vector3(0,0,speed * Time.deltaTime);
     }
 }
}
