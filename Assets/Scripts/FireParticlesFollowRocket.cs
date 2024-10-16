using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticlesFollowRocket : MonoBehaviour
{
    public GameObject followObject;
    public Vector3 offset, offSetStart;
    private Renderer renderer;

    
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
    
        offset = transform.position - followObject.transform.position;
    }

    
    void Update()
    {
        if (followObject != null){
            if(RocketControl.actY >= -2.56f){
                transform.position = followObject.transform.position + offset;
            }else{
                transform.position = new Vector3(followObject.transform.position.x + offset.x,
                transform.position.y, followObject.transform.position.z + offset.z);
            }
        }
        if (RocketControl.allowRocketToMove == true && RocketControl.rotationX == 0 && RocketControl.rotationY == 0){
            renderer.enabled = false;
        } else{
            renderer.enabled = true;
        }
    }
}
