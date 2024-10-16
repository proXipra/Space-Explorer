using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    private int time = 3;
    public TextMeshProUGUI countdown;
    public GameObject gameOverMenu;
    public GameObject currentGame;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        currentGame.SetActive(true);
        RocketControl.allowRocketToMove = false;
        StartCoroutine("Countdown");
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown.text = time.ToString();
        if (time == 0 ){
            StopCoroutine("Countdown");
            countdown.text = "";
            RocketControl.allowRocketToMove = true;
            this.enabled = false;
        }  
    }

    IEnumerator Countdown() {
        while(true) {
                yield return new WaitForSeconds(1);
                time--;
        }
    }
}
