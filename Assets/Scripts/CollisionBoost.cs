using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBoost : MonoBehaviour
{
    public GameObject boost;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Rocket"){
            PowerBarScript.CurrentPower = 20f;
            PrefabGenerator.extraPoints++;
            Destroy(boost);
        }
    }
}
