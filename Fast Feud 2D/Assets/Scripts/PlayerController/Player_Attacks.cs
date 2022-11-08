using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
    public Player_Mechanics stun;
    public GameObject HeavyAttack;
    public GameObject LightAttack;

    private Character p1 = CharacterSelect.player1;
    private Character p2 = CharacterSelect.player2;
    public bool attacking;
    public float cooldown = 0.25f;
    public float timer;

    public float LightStartDelay;
    public float LightActiveDelay;
    public float LightRecoveryDelay;

    private float LightStartTimer = 0;
    private float LightActiveTimer = 0;
    private float LightRecoveryTimer = 0;

    public float HeavyStartDelay;
    public float HeavyActiveDelay;
    public float HeavyRecoveryDelay;

    private float HeavyStartTimer = 0;
    private float HeavyActiveTimer = 0;
    private float HeavyRecoveryTimer = 0;

    private float PassedStartTimer = 0;
    private float PassedActiveTimer = 0;
    private float PassedRecoveryTimer = 0;

    public float PassedStartDelay;
    public float PassedActiveDelay;
    public float PassedRecoveryDelay;

    private bool LightAttackTrue;
    private bool HeavyAttackTrue;

    // Start is called before the first frame update
    void Start()
    {
        HeavyAttackTrue = false;
        LightAttackTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();


    }

    void Attacking(ref float AttackStartTimer, ref float AttackActiveTimer, ref float AttackRecoveryTimer, 
        float AttackStartDelay, float AttackActiveDelay, float AttackRecoveryDelay)
    {

        if (attacking)
        {
            //if (HeavyAttackTrue == true || LightAttackTrue == true)
            //{
            AttackStartTimer++;
            //}

            if (AttackStartTimer >= AttackStartDelay && AttackActiveTimer <= AttackActiveDelay)
            {
                AttackActiveTimer++;
                if (LightAttackTrue && (!stun.BlockStun && !stun.HitStun))
                {
                    LightAttack.SetActive(true);
                }
                else if (HeavyAttackTrue && (!stun.BlockStun && !stun.HitStun))
                {
                    HeavyAttack.SetActive(true);
                }
            }

            else if (AttackActiveTimer >= AttackActiveDelay && AttackRecoveryTimer <= AttackRecoveryDelay)
            {
                AttackRecoveryTimer++;
                HeavyAttack.SetActive(false);
                LightAttack.SetActive(false);
            }

            else if (AttackRecoveryTimer >= AttackRecoveryDelay)
            {
                attacking = false;
                LightAttackTrue = false;
                HeavyAttackTrue = false;
                AttackStartTimer = 0;
                AttackActiveTimer = 0;
                AttackRecoveryTimer = 0;
            }
        }
    }
    
    void Attack()
    {
        if(attacking)
        {
            Attacking(ref PassedStartTimer, ref PassedActiveTimer, ref PassedRecoveryTimer,
                PassedStartDelay, PassedActiveDelay, PassedRecoveryDelay);
        }

        if(Input.GetKeyDown(KeyCode.F) && this.gameObject.tag == "Player 1" && !LightAttackTrue && !HeavyAttackTrue && !stun.BlockStun && !stun.HitStun && !stun.IsBlocking)
        {
            attacking = true;
            LightAttackTrue = true;

            //PassedStartTimer = p1.lightAttackSUF;
            //PassedActiveTimer = p1.lightAttackACF;
            //PassedRecoveryTimer = p1.lightAttackREF;

            PassedStartTimer = LightStartTimer;
            PassedActiveTimer = LightActiveTimer;
            PassedRecoveryTimer = LightRecoveryTimer;

            PassedStartDelay = p1.lightAttackSUF;
            PassedActiveDelay = p1.lightAttackACF;
            PassedRecoveryDelay = p1.lightAttackREF;
    
}

        if (Input.GetKeyDown(KeyCode.R) && this.gameObject.tag == "Player 1" && !LightAttackTrue && !HeavyAttackTrue && !stun.BlockStun && !stun.HitStun && !stun.IsBlocking)
        {
            attacking = true;
            HeavyAttackTrue = true;

            PassedStartTimer = HeavyStartTimer;
            PassedActiveTimer = HeavyActiveTimer;
            PassedRecoveryTimer = HeavyRecoveryTimer;

            PassedStartDelay = p1.heavyAttackSUF;
            PassedActiveDelay = p1.heavyAttackACF;
            PassedRecoveryDelay = p1.heavyAttackREF;

            //PassedStartDelay = HeavyStartDelay;
            //PassedActiveDelay = HeavyActiveDelay;
            //PassedRecoveryDelay = HeavyRecoveryDelay;

        }

        ////////////////////////////////////////////////////////////////////////
        ///
        if (Input.GetKeyDown(KeyCode.O) && this.gameObject.tag == "Player 2" && !LightAttackTrue && !HeavyAttackTrue && !stun.BlockStun && !stun.HitStun && !stun.IsBlocking)
        {
            attacking = true;
            LightAttackTrue = true;

            PassedStartTimer = LightStartTimer;
            PassedActiveTimer = LightActiveTimer;
            PassedRecoveryTimer = LightRecoveryTimer;

            PassedStartDelay = p2.lightAttackSUF;
            PassedActiveDelay = p2.lightAttackACF;
            PassedRecoveryDelay = p2.lightAttackREF;

            //PassedStartDelay = LightStartDelay;
            //PassedActiveDelay = LightActiveDelay;
            //PassedRecoveryDelay = LightRecoveryDelay;
        }

        if (Input.GetKeyDown(KeyCode.P) && this.gameObject.tag == "Player 2" && !LightAttackTrue && !HeavyAttackTrue && !stun.BlockStun && !stun.HitStun && !stun.IsBlocking)
        {
            attacking = true;
            HeavyAttackTrue = true;

            PassedStartTimer = HeavyStartTimer;
            PassedActiveTimer = HeavyActiveTimer;
            PassedRecoveryTimer = HeavyRecoveryTimer;

            PassedStartDelay = p2.heavyAttackSUF;
            PassedActiveDelay = p2.heavyAttackACF;
            PassedRecoveryDelay = p2.heavyAttackREF;

            //PassedStartDelay = HeavyStartDelay;
            //PassedActiveDelay = HeavyActiveDelay;
            //PassedRecoveryDelay = HeavyRecoveryDelay;
        }

        













            /*timer += Time.deltaTime;

            if(timer >= cooldown)
            {
                timer = 0;
                attacking = false;
                HeavyAttack.SetActive(false);
                LightAttack.SetActive(false);
            }*/
        }
    }

