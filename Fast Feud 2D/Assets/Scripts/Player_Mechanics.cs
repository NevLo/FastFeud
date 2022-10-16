using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public float PlayerHealth;
    public Data WhoWon;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
