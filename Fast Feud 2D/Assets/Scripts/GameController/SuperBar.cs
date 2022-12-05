using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_Mechanics Player;
    public Slider slider;
    float percentage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Player.Meter);
        percentage = (Player.Meter / 100);
        Debug.Log(percentage);
        slider.value = percentage;
    }
}
