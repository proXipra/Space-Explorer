using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PrefabGenerator : MonoBehaviour
{
    GameObject planet, newPlanet;
    public static GameObject planetOriginal;
    Vector2 vectorPlanet, vectorBoost;
    //private float lastPosition;
    public GameObject rocket;
    public static GameObject boost, newBoost;

    public TextMeshProUGUI points;
    public static int pointsInt;
    public static int extraPoints;


    void Start()
    {
        pointsInt = 0;
        points.text = "Score: "+ pointsInt.ToString();

        planet = GameObject.Find("Planet") as GameObject;
        float randomX = Random.Range(4f, 6.5f);
        float randomY = Random.Range(1.5f, 2.4f);
        planet.transform.position = new Vector2(randomX, randomY);
        planetOriginal = planet;
        newPlanet = planet;
        //lastPosition = rocket.transform.position.x;

        boost = GameObject.Find("Boost") as GameObject;
        float randomX2 = Random.Range(2.5f, 6.5f);
        float randomY2 = Random.Range(4.3f, 4.6f);
        boost.transform.position = new Vector2(randomX2,randomY2);
        newBoost = boost;

        extraPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointsInt = Mathf.RoundToInt(RocketControl.distanceCovered)+ extraPoints;
        points.text = "Score: "+ pointsInt.ToString();

        if (rocket != null && boost != null && newBoost !=null && 
        (newBoost.transform.position.x - rocket.transform.position.x) <= 10f &&
        (newBoost.transform.position.x - rocket.transform.position.x) > 0f){
            
            float randomX = Random.Range(12f, 18f);
            float randomY = Random.Range(-2f, 3f);
            vectorBoost = new Vector2(boost.transform.position.x + randomX, boost.transform.position.y + randomY);

            if(vectorBoost.y < 0) {
                vectorBoost.y = Random.Range(0f, 2f);
            }
            
            newBoost = Instantiate(boost, vectorBoost, Quaternion.identity)as GameObject;
            
            
            
            //lastPosition = lastPosition + 10;
            float randomXPlus = Random.Range(-2f, 2f);
            float randomYPlus = Random.Range(2f, 3f);
            if (Random.value < 0.5f){
                randomYPlus = - randomYPlus;
            }
            vectorPlanet = new Vector2(boost.transform.position.x + randomX + randomXPlus, boost.transform.position.y 
            + randomY + randomYPlus);

            if (vectorPlanet.y < 0)
            {
                vectorPlanet.y = Random.Range(0f, 2f);
            }

            newPlanet = Instantiate(planet, vectorPlanet, Quaternion.identity) as GameObject;


            newBoost.SetActive(true);
            newPlanet.SetActive(true);
            boost = newBoost;
            planet = newPlanet;
        }

        GameObject[] boostObjects = GameObject.FindGameObjectsWithTag("boost");
        foreach (GameObject target in boostObjects)
            {
                if(target != boost && target != newBoost)
                {
                    if(rocket != null && target != null && (rocket.transform.position.x - target.transform.position.x) > 20)
                    {
                        Destroy(target);
                    }
                }

            }


        GameObject[] planetObjects = GameObject.FindGameObjectsWithTag("planet");
        foreach (GameObject target in planetObjects)
            {
                if(target != planet && target != newPlanet && target == planetOriginal)
                {
                    if(rocket !=null && (rocket.transform.position.x - target.transform.position.x) > 20)
                    {
                        Destroy(target);
                    }
                }

            }
    }
}