using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply_Player_Sprite : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    public Sprite WendySprite;
    public Sprite JackSprite;
    public Sprite WaffleSprite;
    public Sprite BurgerSprite;


    void Start()
    {
        WendySprite = Resources.Load<Sprite>("wendycharTogether");
        JackSprite = Resources.Load<Sprite>("jackcharacterTogether");
        WaffleSprite = Resources.Load<Sprite>("waffleTogether");
        BurgerSprite = Resources.Load<Sprite>("burgerkingcharTogether");
        Character p1 = CharacterSelect.player1;
        Character p2 = CharacterSelect.player2;

        switch(p1.ToString())
        {
            case "Wendy":
                player1.GetComponent<SpriteRenderer>().sprite = WendySprite;
                break;
            case "Jack":
                player1.GetComponent<SpriteRenderer>().sprite = JackSprite;
                break;
            case "Waffle":
                player1.GetComponent<SpriteRenderer>().sprite = WaffleSprite;
                break;
            case "BurgerKing":
                player1.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                break;
            default:
            break;
        }
                switch(p2.ToString())
        {
            case "Wendy":
                player2.GetComponent<SpriteRenderer>().sprite = WendySprite;
                break;
            case "Jack":
                player2.GetComponent<SpriteRenderer>().sprite = JackSprite;
                break;
            case "Waffle":
                player2.GetComponent<SpriteRenderer>().sprite = WaffleSprite;
                break;
            case "BurgerKing":
                player2.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                break;
            default:
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
