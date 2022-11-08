using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Win_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    

    public Text win;
    public GameObject background;
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
        if(WhoWon.PlayerWin == 1 && WhoWon.Player1Wins < 2)
        {
            win.text = "Player 1 Wins The Round";
            won = true;
            //Data.Player1Wins++;
            //if()
        }
        else if (WhoWon.PlayerWin == 2 && WhoWon.Player2Wins < 2)
        {
            win.text = "Player 2 Wins The Round";
            won = true;
        }

        else
        {
            win.text = "";
        }

        if (won)
        {
            WinTimer += Time.deltaTime;
            background.SetActive(true);

            if (WinTimer >= WinCooldown)
            {
                background.SetActive(false);
                WinTimer = 0;
                WhoWon.PlayerWin = 0;
                won = false;
                SceneManager.LoadScene("FightStage_Scene");
            }
        }
    }
}
