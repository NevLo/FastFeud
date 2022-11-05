using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject OtherPlayer;
    public GameObject PauseScreen;
    private bool IsPaused = false;
    public Player_Movement BlockKey;
    public float PlayerMaxHealth;
    public float PlayerHealth;
    public string PlayerName;
    public bool IsBlockingLow;
    public bool IsBlocking;
    public bool HitStun;
    public bool BlockStun;
    public float HitStunTimer;
    public float BlockStunTimer;
    public Data WhoWon;
    public bool doWinCheck = true;
    void Start()
    {
        Application.targetFrameRate = 60;
        BlockKey = this.gameObject.GetComponent<Player_Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        if(BlockStun == true)
        {
            BlockStunTimer++;
            if(BlockStunTimer >= 60)
            {

                BlockStun = false;
                BlockStunTimer = 0;
            }
        }

        if (HitStun == true)
        {
            
            HitStunTimer++;
            if (HitStunTimer >= 120)
            {
                HitStun = false;
                HitStunTimer = 0;
            }
        }

        if (BlockKey.BlockKeyLeft && Input.GetKey(KeyCode.A) && gameObject.tag == "Player 1")
        {
            IsBlocking = true;
            
            if(BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }
        else if (BlockKey.BlockKeyRight && Input.GetKey(KeyCode.D) && gameObject.tag == "Player 1")
        {
            IsBlocking = true;

            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }

        else if(gameObject.tag == "Player 1")
        {
            IsBlockingLow = false;
            IsBlocking = false;
        }

        if (BlockKey.BlockKeyRight && Input.GetKey(KeyCode.RightArrow) && gameObject.tag == "Player 2")
        {
            IsBlocking = true;

            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }

        else if (BlockKey.BlockKeyLeft && Input.GetKey(KeyCode.LeftArrow) && gameObject.tag == "Player 2")
        {
            IsBlocking = true;

            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }

        else if (gameObject.tag == "Player 2")
        {
            IsBlockingLow = false;
            IsBlocking = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false && gameObject.tag == "Player 1")
        {
            //WhoWon.PlayerWin = 0;
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
            IsPaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true && gameObject.tag == "Player 1")
        {
            //WhoWon.PlayerWin = 0;
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
            IsPaused = false;
        }

        if (PlayerHealth <= 0 && doWinCheck)
        {
            this.gameObject.SetActive(false);

            if(this.gameObject.tag == "Player 1")
            {
                WhoWon.PlayerWin = 2;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player2Wins++;
                
            }
            else if(this.gameObject.tag == "Player 2")
            {
                WhoWon.PlayerWin = 1;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player1Wins++;
                
            }
            doWinCheck = false;
        }
    }
}
