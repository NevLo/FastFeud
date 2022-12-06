using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject OtherPlayer;
    public GameObject PauseScreen;
    private bool IsPaused = false;
    public Player_Mechanics BlockKey;
    public float PlayerMaxHealth;
    public float PlayerHealth;
    public float Meter;
    public PlayerBar p1Bar;
    public PlayerBar p2Bar;
    public string PlayerName;
    public bool IsBlockingLow;
    public bool IsBlocking;
    public bool HitStun;
    public bool BlockStun;
    public float HitStunTimer;
    public float BlockStunTimer;
    public Data WhoWon;
    public Round_Timer RoundTimer;
    public bool doWinCheck = true;
    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// </summary>
    /// 
    private Character p1 = CharacterSelect.player1;
    private Character p2 = CharacterSelect.player2;
    public Rigidbody2D rb;
    public Player_Mechanics stun;
    public float MaxSpeed;
    public float speed;
    public float HorizontalMove;
    public float DistToGround;
    public bool grounded;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public LayerMask PlayerLayer;
    public int Grounded;
    public float JumpSpeed = 25;
 
    public bool BlockKeyLeft;
    public bool BlockKeyRight;
    public bool jumping;
    public bool IsCrouching;
    public float JumpCooldown;
    private bool IsFacingRight = true;


    /// <summary>
    /// 
    /// </summary>
    public GameObject HeavyAttack;
    public GameObject LightAttack;
    public GameObject SpecialAttack;

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

    public float SuperStartDelay;
    public float SuperActiveDelay;
    public float SuperRecoveryDelay;

    private float SpecialStartTimer = 0;
    private float SpecialActiveTimer = 0;
    private float SpecialRecoveryTimer = 0;

    private float PassedStartTimer = 0;
    private float PassedActiveTimer = 0;
    private float PassedRecoveryTimer = 0;

    public float PassedStartDelay;
    public float PassedActiveDelay;
    public float PassedRecoveryDelay;

    private bool LightAttackTrue;
    private bool HeavyAttackTrue;
    private bool SpecialAttackTrue;
    void Start()
    {
        HeavyAttackTrue = false;
        LightAttackTrue = false;
        SpecialAttackTrue = false;
        Application.targetFrameRate = 60;
        BlockKey = this.gameObject.GetComponent<Player_Mechanics>();

        if(gameObject.tag == "Player 1")
        {
            WhoWon = Resources.FindObjectsOfTypeAll<Data>()[0];
            RoundTimer = GameObject.Find("Health UI/Timer").GetComponent<Round_Timer>();
            p1Bar = GameObject.Find("Health UI/Player 1 HP").GetComponent<PlayerBar>();
            p1Bar.PlayerHealth = this.gameObject.GetComponent<Player_Mechanics>();
            var p1super = GameObject.Find("Health UI/Player1Meter").GetComponent<SuperBar>();
            p1super.Player = this.gameObject.GetComponent<Player_Mechanics>();

        }
        if (gameObject.tag == "Player 2")
        {
            WhoWon = Resources.FindObjectsOfTypeAll<Data>()[0];
            RoundTimer = GameObject.Find("Health UI/Timer").GetComponent<Round_Timer>();
            p2Bar = GameObject.Find("Health UI/Player 2 HP").GetComponent<PlayerBar>();
            p2Bar.PlayerHealth = this.gameObject.GetComponent<Player_Mechanics>();
            var p1super = GameObject.Find("Health UI/Player2Meter").GetComponent<SuperBar>();
            p1super.Player = this.gameObject.GetComponent<Player_Mechanics>();
        }
        ///////////////////////////////////////////////////////////
        ///
        MaxSpeed = speed;
        DistToGround = GetComponent<Collider2D>().bounds.extents.y;
        IsFacingRight = (gameObject.tag == "Player 1" ? true : false);
        //Changes Block Keys based on player (player1 = true/false, player2 = false/true)
        BlockKeyLeft = (gameObject.tag == "Player 1" ? true : false);
        BlockKeyRight = !BlockKeyLeft;
    }

    // Update is called once per frame
    void Update()
    {

        Attack();
        if (BlockStun == true)
        {
            BlockStunTimer++;
            if (BlockStunTimer >= 10)
            {

                BlockStun = false;
                BlockStunTimer = 0;
            }
        }

        if (HitStun == true)
        {

            HitStunTimer++;
            if (HitStunTimer >= 30)
            {
                HitStun = false;
                HitStunTimer = 0;
            }
        }

        if (BlockKey.BlockKeyLeft && Input.GetKey(KeyCode.A) && gameObject.tag == "Player 1")
        {
            IsBlocking = true;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsBlocking", true);

            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }
        else if (BlockKey.BlockKeyRight && Input.GetKey(KeyCode.D) && gameObject.tag == "Player 1")
        {
            IsBlocking = true;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsBlocking", true);
            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }

        else if (gameObject.tag == "Player 1")
        {
            IsBlockingLow = false;
            IsBlocking = false;
        }

        if (BlockKey.BlockKeyRight && Input.GetKey(KeyCode.RightArrow) && gameObject.tag == "Player 2")
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsBlocking", true);
            IsBlocking = true;

            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }

        else if (BlockKey.BlockKeyLeft && Input.GetKey(KeyCode.LeftArrow) && gameObject.tag == "Player 2")
        {
            IsBlocking = true;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsBlocking", true);
            if (BlockKey.IsCrouching)
            {
                IsBlockingLow = true;
            }
            else
            {
                IsBlockingLow = false;
            }
        }

        else if (gameObject.tag == "Player 2")
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsBlocking", false);
            IsBlockingLow = false;
            IsBlocking = false;
        }
        if ((PlayerHealth <= 0 || RoundTimer.timer <= 0 ) && doWinCheck)
        {
            if(OtherPlayer.tag == "Player 1" && OtherPlayer.GetComponent<Player_Mechanics>().PlayerHealth > PlayerHealth)
            {
                WhoWon.PlayerWin = 1;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player1Wins++;
            }

            else if(OtherPlayer.tag == "Player 2" && OtherPlayer.GetComponent<Player_Mechanics>().PlayerHealth > PlayerHealth)
            {
                WhoWon.PlayerWin = 2;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player2Wins++;
            }

            else if (OtherPlayer.GetComponent<Player_Mechanics>().PlayerHealth == PlayerHealth)
            {
                if(WhoWon.Player1Wins == WhoWon.Player2Wins)
                {
                    if (WhoWon.Player1Wins != 1)
                    {
                        WhoWon.Player1Wins++;
                        WhoWon.Player2Wins++;
                    }
                } 
                else if (WhoWon.Player1Wins > WhoWon.Player2Wins)
                {
                    WhoWon.Player2Wins++;
                }
                else
                {
                    WhoWon.Player1Wins++;
                }
                WhoWon.PlayerWin = 3;
                WhoWon.HasSomeoneWon = true;
            }

            this.gameObject.SetActive(false);
            doWinCheck = false;
        }


        //////////////////////////////////////////////////////////////////////////
        ///

        if (BlockStun == true || HitStun == true)
        {
            speed = 0;
        }

        if (IsCrouching)
        {
            speed = 5;
        }
        else if (!IsCrouching && (BlockStun == false && HitStun == false) && (isGroundedOnLayer(1.0f,GroundLayer) || isGroundedOnLayer(1.5f,PlayerLayer)) && gameObject.tag == "Player 1")
        {
            speed = 10;
        }
        else if (!IsCrouching && (BlockStun == false && HitStun == false) && (isGroundedOnLayer(1.0f,GroundLayer) || isGroundedOnLayer(1.5f,PlayerLayer)) && gameObject.tag == "Player 2")
        {
            speed = 10;
        }
    }

    private void FixedUpdate()
    {
        Meter = Mathf.Min(Meter + .05f, 100);
        if (!IsBlocking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsBlocking", false);
        }
        if (Input.GetKey(KeyCode.A) && this.gameObject.tag == "Player 1" && !BlockStun && !HitStun && !attacking 
            || (isGroundedOnLayer(1.5f,PlayerLayer) && Input.GetKey(KeyCode.A) && this.gameObject.tag == "Player 1") && !attacking)
        {

            if (isGroundedOnLayer(1.0f,GroundLayer))
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
                var animator = gameObject.GetComponent<Animator>();
                animator.SetBool("IsWalking", true);
            }

            else if (isGroundedOnLayer(1.5f,PlayerLayer))
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);

            }
        }

        if (Input.GetKey(KeyCode.D) && this.gameObject.tag == "Player 1" && !BlockStun && !HitStun && !attacking 
            || (isGroundedOnLayer(1.5f,PlayerLayer) && Input.GetKey(KeyCode.D) && this.gameObject.tag == "Player 1") && !attacking)
        {
            
            if (isGroundedOnLayer(1.0f,GroundLayer))
            {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
                var animator = gameObject.GetComponent<Animator>();
                animator.SetBool("IsWalking", true);
            }

            else if (isGroundedOnLayer(1.5f,PlayerLayer))
            {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            }
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && gameObject.tag == "Player 1" && !attacking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && (isGroundedOnLayer(1.0f,GroundLayer)) && this.gameObject.tag == "Player 1" && !BlockStun && !HitStun && !attacking)
        {
            IsCrouching = false;
            //jumping = true;
            rb.velocity = new Vector2(rb.velocity.x * .5f, JumpSpeed);
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsJumping", true);
   
        }

        if (Input.GetKey(KeyCode.S) && !jumping && this.gameObject.tag == "Player 1" && !BlockStun && !HitStun && !attacking)
        {
            IsCrouching = true;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsCrouching", true);
        }

        else if (!Input.GetKeyUp(KeyCode.S) && this.gameObject.tag == "Player 1" && !BlockStun && !HitStun && !attacking)
        {
            IsCrouching = false;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsCrouching", false);
        }


        //////////////////////////////////////////////////////////////////////////////////
        ///

        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.tag == "Player 2" && !BlockStun && !HitStun && !attacking 
            || (isGroundedOnLayer(1.5f,PlayerLayer) && Input.GetKey(KeyCode.LeftArrow)) && this.gameObject.tag == "Player 2" && !attacking)
      
        {
            IsCrouching = false;
            if (isGroundedOnLayer(1.0f,GroundLayer))
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
                var animator = gameObject.GetComponent<Animator>();
                animator.SetBool("IsWalking", true);
            }

            else if(isGroundedOnLayer(1.5f,PlayerLayer))
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.tag == "Player 2" && !BlockStun && !HitStun && !attacking 
            || (isGroundedOnLayer(1.5f,PlayerLayer) && Input.GetKey(KeyCode.RightArrow)) && this.gameObject.tag == "Player 2" && !attacking)
        {
            IsCrouching = false;
            if (isGroundedOnLayer(1.0f,GroundLayer))
            {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
                var animator = gameObject.GetComponent<Animator>();
                animator.SetBool("IsWalking", true);
            }

            else if (isGroundedOnLayer(1.5f,PlayerLayer))
            {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            }

        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && gameObject.tag == "Player 2" && !attacking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGroundedOnLayer(1.0f,GroundLayer)) && this.gameObject.tag == "Player 2" && !BlockStun && !HitStun && !attacking)
        {
            IsCrouching = false;
            //jumping = true;
            rb.velocity = new Vector2(rb.velocity.x * .5f, JumpSpeed);
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsJumping", true);

        }

        if (Input.GetKey(KeyCode.DownArrow) && !jumping && this.gameObject.tag == "Player 2" && !BlockStun && !HitStun && !attacking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsCrouching", true);
            IsCrouching = true;
        }
        else if (!Input.GetKeyUp(KeyCode.DownArrow) && this.gameObject.tag == "Player 2" && !BlockStun && !HitStun && !attacking)
        {
            IsCrouching = false;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsCrouching", false);
        }

        if (this.gameObject != null)
        {
            Flip();
        }

        if (!isGroundedOnLayer(1.0f,GroundLayer) && !isGroundedOnLayer(1.5f,PlayerLayer))
        {
            speed = MaxSpeed * .5f;
        }

    }

    bool isGroundedOnLayer(float offset, LayerMask layer)
    {
        return Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.localScale.y + .3f, layer);
    }

    void Flip()
    {
        // (((IFR & OP.pos.x <= trans.pos.x) || (!IFR & OP.pos.x >= trans.pos.x) ) && otherPlayer.gameObject != null))
        if (((IsFacingRight && OtherPlayer.transform.position.x <= gameObject.transform.position.x ) ||
            (!IsFacingRight && OtherPlayer.transform.position.x >= gameObject.transform.position.x )) && 
            OtherPlayer.gameObject != null)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
            BlockKeyLeft = !BlockKeyLeft;
            BlockKeyRight = !BlockKeyRight;
        }
    }


    void Attacking(ref float AttackStartTimer, ref float AttackActiveTimer, ref float AttackRecoveryTimer,
        float AttackStartDelay, float AttackActiveDelay, float AttackRecoveryDelay)
    {
        AttackStartTimer++;
        if (AttackStartTimer >= AttackStartDelay && AttackActiveTimer <= AttackActiveDelay)
        {
            AttackActiveTimer++;
            if (LightAttackTrue && (!BlockStun && !HitStun))
            {
                LightAttack.SetActive(true);
            }
            else if (HeavyAttackTrue && (!BlockStun && !HitStun))
            {
                HeavyAttack.SetActive(true);
            }
            else if (SpecialAttackTrue && (!BlockStun && !HitStun))
            {
                SpecialAttack.SetActive(true);
            }
        }
        else if (AttackActiveTimer >= AttackActiveDelay && AttackRecoveryTimer <= AttackRecoveryDelay)
        {
            AttackRecoveryTimer++;
            HeavyAttack.SetActive(false);
            LightAttack.SetActive(false);
            SpecialAttack.SetActive(false);
        }
        else if (AttackRecoveryTimer >= AttackRecoveryDelay)
        {
            attacking = false;
            LightAttackTrue = false;
            HeavyAttackTrue = false;
            SpecialAttackTrue = false;
            AttackStartTimer = 0;
            AttackActiveTimer = 0;
            AttackRecoveryTimer = 0;
            var animator = gameObject.GetComponent<Animator>();
            animator.SetBool("IsLightAttack", false);
            animator.SetBool("IsHeavyAttack", false);
        }
    }

    void Attack()
    {
        if (attacking)
        {
            Attacking(ref PassedStartTimer, ref PassedActiveTimer, ref PassedRecoveryTimer,
                PassedStartDelay, PassedActiveDelay, PassedRecoveryDelay);
        }

        if (Input.GetKeyDown(KeyCode.F) && this.gameObject.tag == "Player 1" && !LightAttackTrue && !HeavyAttackTrue && !SpecialAttackTrue && !BlockStun && !HitStun && !IsBlocking)
        {
            attacking = true;
            LightAttackTrue = true;
            var animator = gameObject.GetComponent<Animator>();
            animator.enabled = false;
            animator.SetBool("IsLightAttack", true);
            animator.enabled = true;
            PassedStartTimer = LightStartTimer;
            PassedActiveTimer = LightActiveTimer;
            PassedRecoveryTimer = LightRecoveryTimer;

            PassedStartDelay = p1.lightAttackSUF;
            PassedActiveDelay = p1.lightAttackACF;
            PassedRecoveryDelay = p1.lightAttackREF;

        }
        if (Input.GetKeyDown(KeyCode.R) && this.gameObject.tag == "Player 1" && !LightAttackTrue && !HeavyAttackTrue && !SpecialAttackTrue && !BlockStun && !HitStun && !IsBlocking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.enabled = false;
            animator.SetBool("IsHeavyAttack", true);
            animator.enabled = true;
            attacking = true;
            HeavyAttackTrue = true;

            PassedStartTimer = HeavyStartTimer;
            PassedActiveTimer = HeavyActiveTimer;
            PassedRecoveryTimer = HeavyRecoveryTimer;

            PassedStartDelay = p1.heavyAttackSUF;
            PassedActiveDelay = p1.heavyAttackACF;
            PassedRecoveryDelay = p1.heavyAttackREF;

        }

        if (Input.GetKeyDown(KeyCode.G) && this.gameObject.tag == "Player 1" && !LightAttackTrue && !HeavyAttackTrue && !SpecialAttackTrue && !BlockStun && !HitStun && !IsBlocking)
        {
            attacking = true;
            SpecialAttackTrue = true;
            p1.doSuperAttack();

            PassedStartTimer = SpecialStartTimer;
            PassedActiveTimer = SpecialActiveTimer;
            PassedRecoveryTimer = SpecialRecoveryTimer;

            PassedStartDelay = p1.superAttackSUF;
            PassedActiveDelay = p1.superAttackACF;
            PassedRecoveryDelay = p1.superAttackREF;
        }


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (Input.GetKeyDown(KeyCode.O) && this.gameObject.tag == "Player 2" && !LightAttackTrue && !HeavyAttackTrue && !SpecialAttackTrue && !BlockStun && !HitStun && !IsBlocking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.enabled = false;
            animator.SetBool("IsLightAttack", true);
            animator.enabled = true;
            attacking = true;
            LightAttackTrue = true;

            PassedStartTimer = LightStartTimer;
            PassedActiveTimer = LightActiveTimer;
            PassedRecoveryTimer = LightRecoveryTimer;

            PassedStartDelay = p2.lightAttackSUF;
            PassedActiveDelay = p2.lightAttackACF;
            PassedRecoveryDelay = p2.lightAttackREF;

        }
        if (Input.GetKeyDown(KeyCode.P) && this.gameObject.tag == "Player 2" && !LightAttackTrue && !HeavyAttackTrue && !SpecialAttackTrue && !BlockStun && !HitStun && !IsBlocking)
        {
            var animator = gameObject.GetComponent<Animator>();
            animator.enabled = false;
            animator.SetBool("IsHeavyAttack", true);
            animator.enabled = true;
            attacking = true;
            HeavyAttackTrue = true;
            PassedStartTimer = HeavyStartTimer;
            PassedActiveTimer = HeavyActiveTimer;
            PassedRecoveryTimer = HeavyRecoveryTimer;

            PassedStartDelay = p2.heavyAttackSUF;
            PassedActiveDelay = p2.heavyAttackACF;
            PassedRecoveryDelay = p2.heavyAttackREF;
        }

        if (Input.GetKeyDown(KeyCode.G) && this.gameObject.tag == "Player 2" && !LightAttackTrue && !HeavyAttackTrue && !SpecialAttackTrue && !BlockStun && !HitStun && !IsBlocking)
        {
            attacking = true;
            SpecialAttackTrue = true;
            p2.doSuperAttack();
            PassedStartTimer = SpecialStartTimer;
            PassedActiveTimer = SpecialActiveTimer;
            PassedRecoveryTimer = SpecialRecoveryTimer;

            PassedStartDelay = p2.superAttackSUF;
            PassedActiveDelay = p2.superAttackACF;
            PassedRecoveryDelay = p2.superAttackREF;
        }
    }
}


