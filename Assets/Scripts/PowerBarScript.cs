using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarScript : MonoBehaviour
{

    public static float CurrentPower;
    public static float MaxPower;
    public GameObject rocket;
    public Slider powerBar;
    public Image Fill;

    // Start is called before the first frame update
    void Start()
    {
        MaxPower = 20f;
        CurrentPower = MaxPower;
        powerBar.value = CalculatePower();
        Fill.color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {
        if (RocketControl.allowRocketToMove == true && rocket != null)
        {
            DealDamage(0.004f);
            DealDamage(RocketControl.rotationX/20);
            Fill.color = Color.Lerp(Color.red, Color.yellow, CalculatePower());
        }
    }

    public void DealDamage(float damageValue){
        if (damageValue<0){
            damageValue = damageValue * (-1);
        }
        CurrentPower -= damageValue;
        powerBar.value = CalculatePower();
        if (CurrentPower<= 0)
        {
            CurrentPower = 0;
            CollisionScript.gameOver = true;
        }
    }
    float CalculatePower()
    {
        return CurrentPower/MaxPower;
    }
}
