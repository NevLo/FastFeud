using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Round_Timer : MonoBehaviour
{

    public Round_Screen RoundScreen;
    public Text TimerText;
    private bool RoundHasStarted = false;
    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        //timer = 99;
        RoundHasStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = timer.ToString();
        if(RoundScreen.StartRoundTimer == true)
        {
            
            if(RoundHasStarted == true)
            {
                StartCoroutine(RoundCountdown());
                
            }
            
        }

        if (timer <= 0)
        {
            StopCoroutine(RoundCountdown());
        }
    }

    public IEnumerator RoundCountdown()
    {
        for(int i = 0; i < 99; i++)
        {
            RoundHasStarted = false;
            timer--;
            if(timer <= 0)
            {
                timer = 0;
            }

            yield return new WaitForSeconds(1f);
        }
        
    }
}
