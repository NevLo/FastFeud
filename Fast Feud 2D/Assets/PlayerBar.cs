using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_Mechanics PlayerHealth;
    public Slider slider;
    float percentage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        percentage = (PlayerHealth.PlayerHealth / PlayerHealth.PlayerMaxHealth);

        slider.value = percentage;
    }
}
