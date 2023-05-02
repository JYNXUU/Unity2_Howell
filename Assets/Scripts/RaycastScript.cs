using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    public bool canOpenDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 7))
        {
            Debug.Log(hit.collider.tag);
            // hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.LogError(hit.collider.tag +" " + canOpenDoor);
            if (hit.collider.tag == "Door" && canOpenDoor)
            {
                hit.collider.gameObject.GetComponent<DoorScript>().doorOpen = true;
            }
        }
        
    }
}
