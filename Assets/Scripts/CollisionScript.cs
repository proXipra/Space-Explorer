using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class CollisionScript : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverMenu, currentGame, countdown, planet, rocket, joystick, explosion;
    public GameObject boost;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        GetComponent<Renderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name =="Rocket"){
            Explosion();
            Destroy(col.gameObject);
            GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true){
            if(explosion.active == false){
                GameOver();
            }
        }
    }

    void Explosion(){
        explosion.active = true;
        explosion.GetComponent<ParticleSystem>().enableEmission = true;
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(exp, 1f);
        Invoke("GameOver", 1f);
        explosion.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void GameOver(){
        if(boost != null){
            boost.SetActive(false);
        }


        if (planet != null){
            GetComponent<Renderer>().enabled = false;
        }
            //joystick.SetActive = false;
        gameOver = false;
        currentGame.SetActive(false);
        countdown.SetActive(false);
        gameOverMenu.SetActive(true);

        if (rocket != null){
            rocket.SetActive(false);
        }
        
        GameObject[] boostObject = GameObject.FindGameObjectsWithTag("boost");
            foreach (GameObject target in boostObject)
                {
                    Destroy(target);
                }

        GameObject[] planetObjects = GameObject.FindGameObjectsWithTag("planet");
            foreach (GameObject target in planetObjects)
                {
                    if(target != gameObject){
                        target.GetComponent<Renderer>().enabled = false;
                }
            }

        TextMeshProUGUI scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
        scoreText.alignment = TMPro.TextAlignmentOptions.Center;
        scoreText.text = "Your Score is: " + PrefabGenerator.pointsInt;
        if(PlayerPrefs.GetInt("Highscore")< PrefabGenerator.pointsInt){
            PlayerPrefs.SetInt("Highscore", PrefabGenerator.pointsInt);
        }

    }

    public void onRestart(){
        SceneManager.LoadScene("Game");
    }

    public void OnMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void OnExit(){
        Application.Quit();
    }
}
