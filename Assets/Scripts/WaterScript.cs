using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(RocketControl.allowRocketToMove == true){
            transform.position = new Vector3(RocketControl.canvasX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name =="Rocket"){
            CollisionScript.gameOver = true;
        }
    }
}
