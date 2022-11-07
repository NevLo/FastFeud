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
    public float JumpSpeed;
    private float JumpTimer;
    public bool BlockKeyLeft;
    public bool BlockKeyRight;
    public bool jumping;
    public bool IsCrouching;
    public float JumpCooldown;
    private bool IsFacingRight = true;
    private Vector3 offset;

    void Start()
    {
        Application.targetFrameRate = 60;
        BlockKey = this.gameObject.GetComponent<Player_Mechanics>();

        ///////////////////////////////////////////////////////////
        ///

        MaxSpeed = speed;
        DistToGround = GetComponent<Collider2D>().bounds.extents.y;
        if (this.gameObject.tag == "Player 1")
        {
            IsFacingRight = true;
        }
        else
        {
            IsFacingRight = false;
        }

        //offset = new Vector3(0, -.2f, 0);
        //offset = new Vector3(0, -1f, 0);

        if (gameObject.tag == "Player 1")
        {
            BlockKeyLeft = true;
            BlockKeyRight = false;
        }
        else if (gameObject.tag == "Player 2")
        {
            BlockKeyLeft = false;
            BlockKeyRight = true;
        }

        stun = gameObject.GetComponent<Player_Mechanics>();

    }

    // Update is called once per frame
    void Update()
    {
        if (BlockStun == true)
        {
            BlockStunTimer++;
            if (BlockStunTimer >= 60)
            {

                BlockStun = false;
                BlockStunTimer = 0;
            }
        }

        if (HitStun == true)
        {

            HitStunTimer++;
            if (HitStunTimer >= 120)
            {
                HitStun = false;
                HitStunTimer = 0;
            }
        }

        if (BlockKey.BlockKeyLeft && Input.GetKey(KeyCode.A) && gameObject.tag == "Player 1")
        {
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
        else if (BlockKey.BlockKeyRight && Input.GetKey(KeyCode.D) && gameObject.tag == "Player 1")
        {
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

        else if (gameObject.tag == "Player 1")
        {
            IsBlockingLow = false;
            IsBlocking = false;
        }

        if (BlockKey.BlockKeyRight && Input.GetKey(KeyCode.RightArrow) && gameObject.tag == "Player 2")
        {
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
            IsBlockingLow = false;
            IsBlocking = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false && gameObject.tag == "Player 1")
        {
            //WhoWon.PlayerWin = 0;
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
            IsPaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true && gameObject.tag == "Player 1")
        {
            //WhoWon.PlayerWin = 0;
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
            IsPaused = false;
        }*/

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

            /*else if (OtherPlayer.tag == "Player 1" && OtherPlayer.GetComponent<Player_Mechanics>().PlayerHealth < PlayerHealth)
            {
                WhoWon.PlayerWin = 2;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player2Wins++;
            }

            else if (OtherPlayer.tag == "Player 2" && OtherPlayer.GetComponent<Player_Mechanics>().PlayerHealth < PlayerHealth)
            {
                WhoWon.PlayerWin = 1;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player1Wins++;
            }*/

            else if (OtherPlayer.GetComponent<Player_Mechanics>().PlayerHealth == PlayerHealth)
            {
                SceneManager.LoadScene("FightStage_Scene");
            }

            this.gameObject.SetActive(false);

            /*if (this.gameObject.tag == "Player 1")
            {
                WhoWon.PlayerWin = 2;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player2Wins++;

            }
            else if (this.gameObject.tag == "Player 2")
            {
                WhoWon.PlayerWin = 1;
                WhoWon.HasSomeoneWon = true;
                WhoWon.Player1Wins++;

            }*/
            doWinCheck = false;
        }


        //////////////////////////////////////////////////////////////////////////
        ///

        if (stun.BlockStun == true || stun.HitStun == true)
        {
            speed = 0;
        }

        if (IsCrouching)
        {
            speed = 5;
        }
        else if (!IsCrouching && (stun.BlockStun == false && stun.HitStun == false) && (IsGrounded() || IsGroundedOnPlayer()) && gameObject.tag == "Player 1")
        {
            speed = 10;
        }
        else if (!IsCrouching && (stun.BlockStun == false && stun.HitStun == false) && (IsGrounded() || IsGroundedOnPlayer()) && gameObject.tag == "Player 2")
        {
            speed = 10;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun || (IsGroundedOnPlayer() && Input.GetKey(KeyCode.A)))
        {

            if (IsGrounded())
            {
                rb.velocity = new Vector2(-1 * speed, 0);
            }

            /*else
            {
                //rb.AddForce(Vector2.left * speed);
            }*/

            else if (IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(-1 * speed, 0);
            }
        }

        if (Input.GetKey(KeyCode.D) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun || (IsGroundedOnPlayer() && Input.GetKey(KeyCode.D)))
        {

            if (IsGrounded())
            {
                rb.velocity = new Vector2(1 * speed, 0);
            }

            /*else
            {
                rb.AddForce(Vector2.right * speed);
            }*/

            else if (IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(1 * speed, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && (IsGrounded()) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            //jumping = true;
            rb.velocity = new Vector2(rb.velocity.x * .5f, JumpSpeed);
        }

        if (Input.GetKey(KeyCode.S) && !jumping && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = true;
        }

        else if (!Input.GetKeyUp(KeyCode.S) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
        }


        //////////////////////////////////////////////////////////////////////////////////
        ///
        //var turnAmount = Input.GetAxis("Horizontal");
        // Debug.Log(turnAmount);
        // rb.AddForce(Vector2.left * speed * turnAmount * -20);

        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun || (IsGroundedOnPlayer() && Input.GetKey(KeyCode.LeftArrow)))
        //if (Input.GetInput("Horzontal") && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            if (IsGrounded())
            {
                rb.velocity = new Vector2(-1 * speed, 0);
            }

            /*else
            {
                rb.AddForce(Vector2.left * speed);
            }*/

            else if(IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(-1 * speed, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun || (IsGroundedOnPlayer() && Input.GetKey(KeyCode.RightArrow)))
        {
            IsCrouching = false;
            if (IsGrounded())
            {
                rb.velocity = new Vector2(1 * speed, 0);
            }

            /*else
            {
                rb.AddForce(Vector2.right * speed);
            }*/

            else if (IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(1 * speed, 0);
            }

        }

        /*if (Input.GetKeyDown(KeyCode.UpArrow) && jumping == false && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGrounded()) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            //jumping = true;
            rb.velocity = new Vector2(rb.velocity.x * .5f, JumpSpeed);

        }

        if (Input.GetKey(KeyCode.DownArrow) && !jumping && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = true;
        }

        else if (!Input.GetKeyUp(KeyCode.DownArrow) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
        }

        if (this.gameObject != null)
        {
            Flip();
        }

        if (!IsGrounded() && !IsGroundedOnPlayer() && this.gameObject.tag == "Player 1")
        {
            speed = MaxSpeed * .5f;
        }
        else
        {
            //speed = MaxSpeed;
        }

        if (!IsGrounded() && !IsGroundedOnPlayer() && this.gameObject.tag == "Player 2")
        {
            speed = MaxSpeed * .5f;
        }
        else
        {
            //speed = MaxSpeed;
        }

    }

    bool IsGrounded()
    {

        return Physics2D.OverlapCircle(GroundCheck.position, 1f, GroundLayer);

    }

    bool IsGroundedOnPlayer()
    {

        //return Physics2D.OverlapCircle(GroundCheck.position - offset, 1f, PlayerLayer);
        return Physics2D.OverlapCircle(GroundCheck.position, 1.5f, PlayerLayer);
    }

    void Flip()
    {

        if (IsFacingRight && OtherPlayer.transform.position.x <= this.gameObject.transform.position.x && OtherPlayer.gameObject != null)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
            BlockKeyLeft = !BlockKeyLeft;
            BlockKeyRight = !BlockKeyRight;

        }

        else if (!IsFacingRight && OtherPlayer.transform.position.x >= this.gameObject.transform.position.x && OtherPlayer.gameObject != null)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
            BlockKeyLeft = !BlockKeyLeft;
            BlockKeyRight = !BlockKeyRight;

        }

    }

}
