using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    public Vector3 offset, offSetStart;

    void Start()
    {
        offset = transform.position - followObject.transform.position;
    }

    void Update()
    {
        if (followObject != null)
        {
            if(RocketControl.actY >= -2.56f)
            {
                transform.position = followObject.transform.position + offset;
            }
            else
            {
                transform.position = new Vector3(followObject.transform.position.x + offset.x,
                transform.position.y, followObject.transform.position.z + offset.z);
            }
        }
        
    }
}
