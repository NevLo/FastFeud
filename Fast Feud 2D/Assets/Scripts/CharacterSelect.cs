using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelect : MonoBehaviour
{
    public bool p1Selected = false;
    public bool p2Selected = false;
    public Text p1;
    public Text p2;
    public static Character player1 = null;
    public static Character player2 = null;

    public GameObject FightBtn;
    Character[] charList =
    {
        new Jack(),
        new BurgerKing(),
        new Annie(),
        new LilCeaser(),
        new Panda(),
        new Wendy(),
        new Ronnie(),
        new Colonel(),
        new Waffle()
    };
    string[] stageList =
    {
        "Wendys Parking Lot",
        "Jacks Front Lawn",
        "Waffle House Interior",
        "Burgers Kingdom"
    };
    public static int currentlySelectedStage = 0;

    public Text stageText; 
    public void Start()
    {
        player1 = null;
        player2 = null;
        p1Selected = false;
        p2Selected = false;
        stageText = GameObject.Find("StageTextChangeable").GetComponent<Text>();
        stageText.text = stageList[currentlySelectedStage];
        p1 = GameObject.Find("Player1Txt").GetComponent<Text>();
        p2 = GameObject.Find("Player2Txt").GetComponent<Text>();
        FightBtn.SetActive(false);
        
    }
    public void Update()
    {
        stageText.text = stageList[currentlySelectedStage];
    }

    public void sceneSelect(){

    }
    public void rand (){
        int setRand = Random.Range(0,9);
        BindCharacterToPlayer(setRand);
        BindCharacterToPlayer(Random.Range(0, 9));

    }
    //implemented
    public void char1 (){
        BindCharacterToPlayer(0);
        //Boxer Jack

        //display char
        //Store character pngs as masks
        //pass char1 
    }
    //implemented    
    public void char2 (){
        BindCharacterToPlayer(1);
        //king borg
    }
    public void char3 (){
        BindCharacterToPlayer(2);
        //annie P
    }
    public void char4 (){
        BindCharacterToPlayer(3);
        //little C

    }
    public void char5 (){
        BindCharacterToPlayer(4);
        //Panda

    }

    //implemented 
    public void char6 (){
        BindCharacterToPlayer(5);
        //Wendy
    }

    public void char7 (){
        BindCharacterToPlayer(6);
        //Ronnie
    }
    public void char8 (){
        BindCharacterToPlayer(7);
        //SLander
    }

    // implemented
    public void char9()
    {
        BindCharacterToPlayer(8);
        //Waffle
    }
    public void nextStage()
    {
        currentlySelectedStage = (currentlySelectedStage + 1) % stageList.Length;
    }
    public void prevStage()
    {
        if(currentlySelectedStage == 0)
        {
            currentlySelectedStage = 3;
            return;
        }
        currentlySelectedStage = (currentlySelectedStage - 1) % stageList.Length;
    }

    public void resetPlayer1()
    {
        player1 = null;
        p1Selected = false;
        p1.text = "PLAYER 1 UNSELECTED";
        FightBtn.SetActive(false);
    }
    public void resetPlayer2()
    {
        player2 = null;
        p2Selected = false;
        p2.text = "PLAYER 2 UNSELECTED";
        FightBtn.SetActive(false);
    }


    public void BindCharacterToPlayer(int ind)
    {
        if (player1 == null)
        {
            player1 = charList[ind];
            Debug.Log("Player 1 has selected " + player1.ToString());
            p1.text = "Player 1: " + player1.ToString();
        }
        else
        {
            player2 = charList[ind];
            Debug.Log("Player 2 has selcted " + player2.ToString());
            p2.text = "Player 2: " + player2.ToString();
        }

        if(player1 != null && player2 != null){
            FightBtn.SetActive(true);
        }
    }
}
  