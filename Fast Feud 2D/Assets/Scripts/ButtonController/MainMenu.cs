using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private static Button StartGameButton = null;
    [SerializeField]
    private static Button OptionsButton = null;
    [SerializeField]
    private static Button FightButton = null;
    [SerializeField]
    private static Button BackButton = null;
    [SerializeField]
    private static Button QuitButton = null;




    public void Awake()
    {
        //StartGameButton.onClick.AddListener(PlayGame);
        //OptionsButton.onClick.AddListener(Fight);
        //FightButton.onClick.AddListener(Options);
        //BackButton.onClick.AddListener(ToTheMenu);
        //QuitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame (){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(wait(3f));
        SceneManager.LoadScene("CharSelect_Scene");
    }
    public void Fight (){
        StartCoroutine(wait(1f));
        SceneManager.LoadScene("FightStage_Scene");
    }
    public void SelectCharacter(){
        
    }
    public void Options (){
        StartCoroutine(wait(1f));
        SceneManager.LoadScene("OptionsMenu_Scene");
    }

    public void QuitGame (){
        StartCoroutine(wait(1f));
        Debug.Log("Quit!");
        Application.Quit();
        //System.Environment.Exit(0);
    }

    public void ToTheMenu(){
        SceneManager.LoadScene("MainMenu_Scene");
    }
    public IEnumerator wait(float i){
    yield return new WaitForSeconds(i);
}
}

