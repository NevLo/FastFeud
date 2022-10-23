using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelect : MonoBehaviour
{
    public static Character player1 = null;
    public static Character player2 = null;
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
    
    public void BindCharacterToPlayer(int ind)
    {
        if (player1 == null)
        {
            player1 = charList[ind];
            Debug.Log("Player 1 has selected " + player1.ToString());
        }
        else
        {
            player2 = charList[ind];
            Debug.Log("Player 2 has selcted " + player2.ToString());
        }
    }
}
