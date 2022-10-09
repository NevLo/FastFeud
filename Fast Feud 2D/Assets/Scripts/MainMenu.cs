using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame (){
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       SceneManager.LoadScene(2);
    }
    public void Fight (){
        SceneManager.LoadScene(3);
    }
    public void SelectCharacter(){
        
    }
    public void Options (){
        SceneManager.LoadScene(1);
    }

    public void QuitGame (){
    Debug.Log("Quit!");
    Application.Quit();
    //System.Environment.Exit(0);
    }

    public void toTheMenu(){
        SceneManager.LoadScene(0);
    }
}
