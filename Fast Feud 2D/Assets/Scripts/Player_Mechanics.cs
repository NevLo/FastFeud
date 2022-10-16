using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject OtherPlayer;
    public Player_Movement BlockKey;
    public float PlayerHealth;
    public bool IsBlockingLow;
    public bool IsBlocking;
    public Data WhoWon;

    void Start()
    {
        Application.targetFrameRate = 60;
        BlockKey = this.gameObject.GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BlockKey.BlockKeyLeft && Input.GetKey(KeyCode.A) && gameObject.tag == "Player 1")
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WhoWon.PlayerWin = 0;
            Application.Quit();
        }

        if(PlayerHealth <= 0)
        {
            Destroy(this.gameObject);

            if(this.gameObject.tag == "Player 1")
            {
                WhoWon.PlayerWin = 2;
            }
            else if(this.gameObject.tag == "Player 2")
            {
                WhoWon.PlayerWin = 1;
            }
        }
    }
}
