using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply_Player_Sprite : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
    public GameObject OtherFor1;
    public GameObject OtherFor2;
    public bool gameObjectsSet = false;

    [SerializeField]
    public GameObject jackPre;
    [SerializeField]
    public GameObject burgPre;

    
    public AnimationClip WendySprite_idle;
    public AnimationClip WendySprite_walk;
    public AnimationClip WendySprite_blck;
    public AnimationClip WendySprite_crouch;
    public AnimationClip WendySprite_crouchblock;
    public AnimationClip WendySprite_jump;
    public AnimationClip WendySprite_lightattack;
    public AnimationClip WendySprite_heavyattack;

    public GameObject wendyprefab;
    public GameObject waffle;
    public GameObject waffle2;

    public Sprite WendySprite;
    public Sprite JackSprite;
    public Sprite WaffleSprite;
    public Sprite BurgerSprite;


    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        //player1.AddComponent<Animation>();
        //player2.AddComponent<Animation>();

        //var p1anim = player1.GetComponent<Animator>();
        //var p2anim = player2.GetComponent<Animator>();
        //player1.tag = "Player 1";
        //player2.tag = "Player 2";

        /*
        WendySprite_idle = Resources.Load<AnimationClip>("wendy_idle.anim");
        WendySprite_walk = Resources.Load<AnimationClip>("wendy_walk.anim");
        WendySprite_blck = Resources.Load<AnimationClip>("wendy_block.anim");
        WendySprite_crouch = Resources.Load<AnimationClip>("wendy_crouch.anim");
        WendySprite_crouchblock = Resources.Load<AnimationClip>("wendy_block_and_crouch.anim");
        WendySprite_jump = Resources.Load<AnimationClip>("wendy_jump_state.anim");
        WendySprite_lightattack = Resources.Load<AnimationClip>("wendy_light_punch.anim");
        WendySprite_heavyattack = Resources.Load<AnimationClip>("wendy_heavy_punch.anim");
        */
        //WendySprite = Resources.Load<Sprite>("wendycharTogether");
        //JackSprite = Resources.Load<Sprite>("jackcharacterTogether");
        //WaffleSprite = Resources.Load<Sprite>("waffleTogether");
        //BurgerSprite = Resources.Load<Sprite>("burgerkingcharTogether");
        Character p1 = CharacterSelect.player1;
        Character p2 = CharacterSelect.player2;


        //GameObject wendyinst = Instantiate(wendyprefab);


        switch(p1.ToString())
        {
            case "Wendy":
                /*
                p1anim.AddClip(WendySprite_idle, "idle");
                p1anim.AddClip(WendySprite_walk, "walk");
                p1anim.AddClip(WendySprite_blck, "block");
                p1anim.AddClip(WendySprite_crouch, "crouch");
                p1anim.AddClip(WendySprite_crouchblock, "crouchblock");
                p1anim.AddClip(WendySprite_jump, "jump");
                p1anim.AddClip(WendySprite_lightattack, "lightattack");
                p1anim.AddClip(WendySprite_heavyattack, "heavyattack");
                */
                //Debug.Log("WE ARE HERE");
                //player1.GetComponent<SpriteRenderer>().sprite = WendySprite;
                //p1anim.Play("idle");

                //Debug.Log(wendyinst.transform.position);
                //Debug.Log(player1.transform.position);
                //wendyinst.transform.position = player1.transform.position;
                //Debug.Log(wendyinst.transform.position);
                //player1.SetActive(false);

                //p1 = Instantiate(waffle, new Vector3(-7, -2, -1), Quaternion.identity);
                Player1Prefab = Instantiate(waffle, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            case "Jack":
                //player1.GetComponent<SpriteRenderer>().sprite = JackSprite;
                Player1Prefab = Instantiate(waffle, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            case "Waffle":
                //player1.GetComponent<SpriteRenderer>().sprite = WaffleSprite;
                Player1Prefab = Instantiate(waffle, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            case "BurgerKing":
                //player1.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                Player1Prefab = Instantiate(waffle, new Vector3(-7, -2, -1), Quaternion.identity);
                //player1.tag = "Player 1";
                break;
            default:
            break;
        }
                switch(p2.ToString())
        {
            case "Wendy":
                //player2.GetComponent<SpriteRenderer>().sprite = WendySprite;
                Player2Prefab = Instantiate(waffle2, new Vector3(7, -2, -1), new Quaternion(0, 180, 0, 0));
                //player2.tag = "Player 2";
                break;
            case "Jack":
                //player2.GetComponent<SpriteRenderer>().sprite = JackSprite;
                Player2Prefab = Instantiate(waffle2, new Vector3(7, -2, -1), new Quaternion (0,180,0,0));
                //player2.tag = "Player 2";
                break;
            case "Waffle":
                //player2.GetComponent<SpriteRenderer>().sprite = WaffleSprite;
                Player2Prefab = Instantiate(waffle2, new Vector3(7, -2, -1), new Quaternion(0, 180, 0, 0));
                //player2.tag = "Player 2";
                break;
            case "BurgerKing":
                //player2.GetComponent<SpriteRenderer>().sprite = BurgerSprite;
                Player2Prefab = Instantiate(waffle2, new Vector3(7, -2, -1), new Quaternion(0, 180, 0, 0));
                //player2.tag = "Player 2";
                break;
            default:
            break;
        }

        gameObjectsSet = true;
        Debug.Log("We have successfully instantiated the gameobjects");

        Player1Prefab.GetComponent<Player_Mechanics>().OtherPlayer = Player2Prefab;
        Player2Prefab.GetComponent<Player_Mechanics>().OtherPlayer = Player1Prefab;
        //new1.SetActive(true);
        //new2.SetActive(true);
        //player1.GetComponent<Player_Mechanics>().OtherPlayer = player2;
        //player2.GetComponent<Player_Mechanics>().OtherPlayer = player1;

    }

    // Update is called once per frame

}
