using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cunscene : MonoBehaviour
{
    void OnEnable(){
        SceneManager.LoadScene("MainMenu_Scene");
    }
}
