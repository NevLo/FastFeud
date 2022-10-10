using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button StartGameButton = null;
    [SerializeField]
    private Button OptionsButton = null;
    [SerializeField]
    private Button FightButton = null;
    [SerializeField]
    private Button BackButton = null;
    [SerializeField]
    private Button QuitButton = null;




    public void Awake()
    {
        StartGameButton.onClick.AddListener(PlayGame);
        OptionsButton.onClick.AddListener(Fight);
        FightButton.onClick.AddListener(Options);
        BackButton.onClick.AddListener(ToTheMenu);
        QuitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame (){
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       SceneManager.LoadScene("CharSelect_Scene");
    }
    public void Fight (){
        SceneManager.LoadScene("FightStage_Scene");
    }
    public void SelectCharacter(){
        
    }
    public void Options (){
        SceneManager.LoadScene("OptionsMenu_Scene");
    }

    public void QuitGame (){
    Debug.Log("Quit!");
    Application.Quit();
    //System.Environment.Exit(0);
    }

    public void ToTheMenu(){
        SceneManager.LoadScene("MainMenu_Scene");
    }
}
