using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;
    public float StartDelay;
    public float ActiveDelay;
    public float RecoveryDelay;

    private float StartTimer;
    private float ActiveTimer;
    private float RecoveryTimer;

    private Character p1 = CharacterSelect.player1;
    private Character p2 = CharacterSelect.player2;
    [SerializeField]
    private bool activeCharIsP1;

    public Player_Mechanics blocking;

    void Start()
    {

        if(gameObject.tag == "HAP1")
        {
            damage = p1.heavyAttackDamage;
        }

        else if (gameObject.tag == "HAP2")
        {
            damage = p2.heavyAttackDamage;
        }

        else if (gameObject.tag == "LAP1")
        {
            damage = p1.lightAttackDamage;
        }

        else if (gameObject.tag == "LAP2")
        {
            damage = p2.lightAttackDamage;
        }
        //this.gameObject.GetComponent<Collider2D>().enabled = false;
        //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //blocking = gameObject.GetComponent<Player_Mechanics>();
    }

    // Update is called once per frame
    void Update()
    {

        if(blocking.HitStun || blocking.BlockStun)
        {
            gameObject.SetActive(false);
        }









        /*if(StartTimer >= StartDelay && RecoveryTimer <= RecoveryDelay)
        {
            this.gameObject.SetActive(true);
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            ActiveTimer++;
        }

        if (ActiveTimer >= ActiveDelay)
        {
            StartTimer = 0;
            //this.gameObject.SetActive(true);
            RecoveryTimer++;
        }

        if(RecoveryTimer >= RecoveryDelay)
        {
            StartTimer = 0;
            ActiveTimer = 0;
            RecoveryTimer = 0;
            this.gameObject.SetActive(false);
            
        }

        else
        {
            StartTimer++;
        }*/
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //meep

        if(collision.gameObject.GetComponent<Player_Mechanics>() != null)
        {
            if(!collision.gameObject.GetComponent<Player_Mechanics>().IsBlocking)
            {
                collision.gameObject.GetComponent<Player_Mechanics>().PlayerHealth -= damage;
                collision.gameObject.GetComponent<Player_Mechanics>().HitStun = true;
            }
            else if(collision.gameObject.GetComponent<Player_Mechanics>().IsBlocking)
            {
                collision.gameObject.GetComponent<Player_Mechanics>().BlockStun = true;
            }
            
        }

    }
}
