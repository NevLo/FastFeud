using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Training_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text RoundScreen;
    public GameObject RoundBackground;
    public Data WhoWon;
    public bool RoundStart;
    public bool RoundStart2;
    public float RoundStartDelay;
    public float RoundStartTimer;

    void Start()
    {
        RoundStart = false;
        RoundStart2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
