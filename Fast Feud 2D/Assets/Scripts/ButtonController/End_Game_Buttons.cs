using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game_Buttons : MonoBehaviour
{
    // Start is called before the first frame update

    public Data PlayerData;
    public TurnOnWins wins;
    
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
        PlayerData.RoundCount = 1;
        wins.Win1.SetActive(false);
        wins.Win2.SetActive(false);
        wins.Win3.SetActive(false);
        wins.Win4.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu_Scene");
        ResetData();
    }

    public void GoToCharacterSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CharSelect_Scene");
        ResetData();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FightStage_Scene");
        ResetData();
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        ResetData();
        Application.Quit();
    }


}
