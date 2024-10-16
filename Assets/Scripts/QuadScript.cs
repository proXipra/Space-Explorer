using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
    MeshRenderer mr;
    Material material;

    void Update()
    {
        mr = GetComponent<MeshRenderer>();
        material = mr.material;
        material.mainTextureOffset = 
        new Vector2(transform.position.x/transform.localScale.x/2f,
         transform.position.y/transform.localScale.y/2f);
    }
}
