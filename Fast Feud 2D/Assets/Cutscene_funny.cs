using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene_funny: MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }
}

