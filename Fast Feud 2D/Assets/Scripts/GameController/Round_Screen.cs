using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Round_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text RoundScreen;
    public GameObject RoundBackground;
    public Data WhoWon;
    public bool RoundStart;
    public bool RoundStart2;
    public bool StartRoundTimer;
    public float RoundStartDelay;
    public float RoundStartTimer;
    public Win_Screen ws;
    public GameObject Wall1;
    public GameObject Wall2;

    void Start()
    {
        RoundStart = false;
        RoundStart2 = false;
        StartRoundTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundStart)
        {
            RoundStartTimer++;
            if (RoundStartTimer >= RoundStartDelay)
            {
                RoundScreen.text = "START";
                RoundStart2 = true;
                RoundStart = false;
                RoundStartTimer = 0;
            }
        }

        if(RoundStart2)
        {
            RoundStartTimer++;
            if (RoundStartTimer >= RoundStartDelay)
            {
                RoundScreen.text = "";
                RoundStart2 = true;
                RoundStart = false;
                RoundStartTimer = 0;
                StartRoundTimer = true;
                Wall1.SetActive(false);
                Wall2.SetActive(false);
            }
        }

        if(WhoWon.Player1Wins >= 2 || WhoWon.Player2Wins >= 2)
        {
            //int whomsteved = WhoWon.Player1Wins > WhoWon.Player2Wins ? 1 : 2;
            ws.won = true;
            RoundBackground.SetActive(true);
            WhoWon.HasSomeoneWon = false;
            if (WhoWon.Player1Wins > WhoWon.Player2Wins) 
            {
                RoundScreen.text = "Player 1 Wins";
                //WhoWon.Player1Wins = 0;
                //WhoWon.Player2Wins = 0;
            }
            else
            {
                RoundScreen.text = "Player 2 Wins";
                //WhoWon.Player1Wins = 0;
                //WhoWon.Player2Wins = 0;
            }
        }

        else if(WhoWon.Player1Wins == 1 && WhoWon.Player2Wins == 1 && !RoundStart && !RoundStart2)
        {
            RoundScreen.text = "Round " + WhoWon.RoundCount;
            RoundStart = true;
        }

        else if (WhoWon.HasSomeoneWon == false && !RoundStart && !RoundStart2)
        {
            RoundScreen.text = "Round " + WhoWon.RoundCount;
            WhoWon.Player1Wins = 0;
            WhoWon.Player2Wins = 0;
            RoundStart = true;
        }


        else if(WhoWon.HasSomeoneWon == true && !RoundStart && !RoundStart2)
        {
            RoundScreen.text = "Round " + WhoWon.RoundCount;
            RoundStart = true;
        }

        
    }
    
}
