using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
    public GameObject HeavyAttack;
    public GameObject LightAttack;
    public bool attacking;
    public float cooldown = 0.25f;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= cooldown)
            {
                timer = 0;
                attacking = false;
                HeavyAttack.SetActive(false);
                LightAttack.SetActive(false);
            }
        }
    }
    
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.W) && this.gameObject.tag == "Player 1")
        {
            //attacking = true;
            HeavyAttack.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S) && this.gameObject.tag == "Player 1")
        {
            //attacking = true;
            LightAttack.SetActive(true);
        }

        ////////////////////////////////////////////////////////////////////////
        ///
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.gameObject.tag == "Player 2")
        {
            //attacking = true;
            HeavyAttack.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && this.gameObject.tag == "Player 2")
        {
           // attacking = true;
            LightAttack.SetActive(true);
        }
    }
}
