using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWins : MonoBehaviour
{
    public GameObject Win1, Win2, Win3, Win4;
    public Data PlayerWins;

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerWins.Player1Wins == 1)
        {
            Win1.SetActive(true);
        }

        if (PlayerWins.Player1Wins == 2)
        {
            Win2.SetActive(true);
        }

        if (PlayerWins.Player2Wins == 1)
        {
            Win3.SetActive(true);
        }

        if (PlayerWins.Player2Wins == 2)
        {
            Win4.SetActive(true);
        }

    }
}
