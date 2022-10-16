using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    

    public TextMeshProUGUI win;
    private bool won = false;
    private float WinTimer;
    public float WinCooldown;
    public Data WhoWon;

    void Start()
    {
        won = false;
        win.text = "";
        WhoWon.PlayerWin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(WhoWon.PlayerWin == 1)
        {
            win.text = "Player 1 Wins";
            won = true;
        }
        else if (WhoWon.PlayerWin == 2)
        {
            win.text = "Player 2 Wins";
            won = true;
        }

        else
        {
            win.text = "";
        }

        if (won)
        {
            WinTimer += Time.deltaTime;

            if (WinTimer >= WinCooldown)
            {
                WinTimer = 0;
                WhoWon.PlayerWin = 0;
                won = false;
            }
        }
    }
}
