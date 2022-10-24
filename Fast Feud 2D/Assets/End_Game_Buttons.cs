using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game_Buttons : MonoBehaviour
{
    // Start is called before the first frame update

    public Data PlayerData;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetData()
    {
        PlayerData.PlayerWin = 0;
        PlayerData.Player1Wins = 0;
        PlayerData.Player2Wins = 0;
        PlayerData.HasFightStarted = false;
        PlayerData.HasSomeoneWon = false;
        PlayerData.HasSomeoneWonTwice = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu_Scene");
        ResetData();
    }

    public void GoToCharacterSelect()
    {
        SceneManager.LoadScene("CharSelect_Scene");
        ResetData();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("FightStage_Scene");
        ResetData();
    }
}
