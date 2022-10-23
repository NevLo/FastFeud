using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelect : MonoBehaviour
{

    Data PlayerSelect;
    private int WhichPlayer;
    private void Update()
    {
        Player1Player2();
    }


    public void sceneSelect(){

    }
    public void rand (){
       int setRand = Random.Range(0,8);
    }
    public void char1 (){

        if(WhichPlayer == 1)
        {
            
        }

        //Boxer Jack

       //display char
       //Store character pngs as masks
       //pass char1 
    }
    
    public void char2 (){
       //king borg
    }
    public void char3 (){
       //annie P
    }
    public void char4 (){
        //little C
       
    }
    public void char5 (){
        //Panda
       
    }
    public void char6 (){
        //Wendy
    }
    public void char7 (){
       //Ronnie
    }
    public void char8 (){
       //SLander
    }

    public void Player1Player2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            WhichPlayer = 1;
        }

        else if (Input.GetMouseButtonDown(1))
        {
            WhichPlayer = 2;
        }

        else
        {
            WhichPlayer = 3;
        }
    }
    
}
