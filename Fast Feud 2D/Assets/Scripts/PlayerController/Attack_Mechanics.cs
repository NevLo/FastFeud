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

    public bool isHeavyAttack;

    void Start()
    {
        if(gameObject.tag == "HAP1")
        {
            damage = p1.heavyAttackDamage;
            isHeavyAttack = true;
        }
        else if (gameObject.tag == "HAP2")
        {
            damage = p2.heavyAttackDamage;
            isHeavyAttack = true;
        }
        else if (gameObject.tag == "LAP1")
        {
            damage = p1.lightAttackDamage;
            isHeavyAttack = false;
        }
        else if (gameObject.tag == "LAP2")
        {
            damage = p2.lightAttackDamage;
            isHeavyAttack = false;
        }
        else if (gameObject.tag == "SAP1")
        {
            damage = p1.superAttackDamage = 0;
            isHeavyAttack = false;
        }
        else if (gameObject.tag == "SAP2")
        {
            damage = p2.superAttackDamage = 0;
            isHeavyAttack = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(blocking != null)
        {
            if (blocking.HitStun || blocking.BlockStun)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherPlayer = collision.gameObject.GetComponent<Player_Mechanics>();

        if(otherPlayer != null)
        {
            if ((!otherPlayer.IsBlocking) || (otherPlayer.IsBlockingLow && isHeavyAttack) || (!otherPlayer.IsBlockingLow && !isHeavyAttack))
            {
                var LPunchHit = GameObject.Find("Light_punch").GetComponent<AudioSource>();
                var HPunchHit = GameObject.Find("Heavy_punch").GetComponent<AudioSource>();
                
                if(isHeavyAttack){
                    HPunchHit.Play();
                }
                else{
                    LPunchHit.Play();
                }
                otherPlayer.PlayerHealth -= damage;
                otherPlayer.HitStun = true;
                blocking.Meter = Mathf.Min(blocking.Meter + damage * 3, 100);

            }
            else
            {
                otherPlayer.BlockStun = true;
            }
        }
    }
}
