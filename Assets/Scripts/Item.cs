using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public float price; 
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.name;
        price = 3;
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.collider.gameObject.name == name)
                {
                   
                    print(this.name);
                }
            }
        }
        if (!GetComponent<Renderer>().isVisible)
        { 
            transform.position = new Vector3(0, (float)1.5, -10);
        }
    }
}
