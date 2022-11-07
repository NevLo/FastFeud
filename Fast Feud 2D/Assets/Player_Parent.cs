using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Parent : MonoBehaviour
{

    private bool IsPaused;
    public GameObject PauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false)
        {
            //WhoWon.PlayerWin = 0;
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
            IsPaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true)
        {
            //WhoWon.PlayerWin = 0;
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
            IsPaused = false;
        }

    }

    public void BackToGame()
    {
        if(IsPaused)
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }
}
