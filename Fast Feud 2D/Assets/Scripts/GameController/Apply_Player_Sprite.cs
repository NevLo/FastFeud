using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply_Player_Sprite : MonoBehaviour
{
    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
    public bool gameObjectsSet = false;

    public GameObject waffle;
    public GameObject waffle2;
    public GameObject wendy;
    public GameObject wendy2;
    public GameObject jack;
    public GameObject jack2;
    public GameObject burger;
    public GameObject burger2;

    public Sprite WendySprite;
    public Sprite JackSprite;
    public Sprite WaffleSprite;
    public Sprite BurgerSprite;


    /// <summary>
    /// 
    /// </summary>
    void Start()
    {

        Character p1 = CharacterSelect.player1;
        Character p2 = CharacterSelect.player2;

        switch(p1.ToString())
        {
            case "Wendy":

                Player1Prefab = Instantiate(wendy, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            case "Jack":

                Player1Prefab = Instantiate(jack, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            case "Waffle":

                Player1Prefab = Instantiate(waffle, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            case "BurgerKing":
                Player1Prefab = Instantiate(burger, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            default:
            break;
        }
        switch (p2.ToString()) { 
            case "Wendy":
                Player2Prefab = Instantiate(wendy2, new Vector3(7, -2, -1), new Quaternion(0, 180, 0, 0));
                Player2Prefab.tag = "Player 2";
                //player2.tag = "Player 2";
                break;
            case "Jack":
                Player2Prefab = Instantiate(jack2, new Vector3(7, -2, -1), new Quaternion (0,180,0,0));
                Player2Prefab.tag = "Player 2";
                //player2.tag = "Player 2";
                break;
            case "Waffle":
                Player2Prefab = Instantiate(waffle2, new Vector3(7, -2, -1), new Quaternion(0, 180, 0, 0));
                Player2Prefab.tag = "Player 2";
                //player2.tag = "Player 2";
                break;
            case "BurgerKing":
                Player2Prefab = Instantiate(burger2, new Vector3(7, -2, -1), new Quaternion(0, 180, 0, 0));
                Player2Prefab.tag = "Player 2";
                //player2.tag = "Player 2";
                break;
            default:
            break;
        }

        gameObjectsSet = true;
        Debug.Log("We have successfully instantiated the gameobjects");

        Player1Prefab.GetComponent<Player_Mechanics>().OtherPlayer = Player2Prefab;
        Player2Prefab.GetComponent<Player_Mechanics>().OtherPlayer = Player1Prefab;
    }
}
