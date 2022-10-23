using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject OtherPlayer;
    public Player_Mechanics stun;
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
    

    // Start is called before the first frame update
    void Start()
    {
        DistToGround = GetComponent<Collider2D>().bounds.extents.y;
        if(this.gameObject.tag == "Player 1")
        {
            IsFacingRight = true;
        }
        else
        {
            IsFacingRight = false;
        }

        offset = new Vector3(0, -0.2f, 0);

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



        if(stun.BlockStun == true || stun.HitStun == true)
        {
            speed = 0;
        }

        if(IsCrouching)
        {
            speed = 5;
        }
        else if(!IsCrouching || (stun.BlockStun == true && stun.HitStun == true))
        {
            speed = 10;
        }

        if (jumping)
        {
            JumpTimer += Time.deltaTime;

            if (JumpTimer >= JumpCooldown)
            {
                JumpTimer = 0;
                jumping = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            
            if (IsGrounded() || IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(-1 * speed, 0);
            }

            else
            {
                rb.AddForce(Vector2.left * speed);
            }
        }

        if (Input.GetKey(KeyCode.D) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            
            if (IsGrounded() || IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(1 * speed, 0);
            }

            else
            {
                rb.AddForce(Vector2.right * speed);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && jumping == false && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            //IsCrouching = false;
            jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

        if (Input.GetKey(KeyCode.S) && !jumping && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = true;
        }

        else if(!Input.GetKeyUp(KeyCode.S) && this.gameObject.tag == "Player 1" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
        }


        //////////////////////////////////////////////////////////////////////////////////
        ///
        //var turnAmount = Input.GetAxis("Horizontal");
       // Debug.Log(turnAmount);
       // rb.AddForce(Vector2.left * speed * turnAmount * -20);

        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        //if (Input.GetInput("Horzontal") && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            if (IsGrounded() || IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(-1 * speed, 0);
            }

            else
            {
                rb.AddForce(Vector2.left * speed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            if (IsGrounded() || IsGroundedOnPlayer())
            {
                rb.velocity = new Vector2(1 * speed, 0);
            }
            
            else
            {
                rb.AddForce(Vector2.right * speed);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumping == false && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
            jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow) && !jumping && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = true;
        }

        else if (!Input.GetKeyUp(KeyCode.DownArrow) && this.gameObject.tag == "Player 2" && !stun.BlockStun && !stun.HitStun)
        {
            IsCrouching = false;
        }

        if(this.gameObject != null)
        {
            Flip();
        }
        
    }

    bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(GroundCheck.position, .2f, GroundLayer);
        
    }

    bool IsGroundedOnPlayer()
    {

        return Physics2D.OverlapCircle(GroundCheck.position - offset, 1f, PlayerLayer);
    }

    void Flip()
    {

        if(IsFacingRight && OtherPlayer.transform.position.x <= this.gameObject.transform.position.x && OtherPlayer.gameObject != null)
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
















        /*if(IsFacingRight && Input.GetKey(KeyCode.A) && this.gameObject.tag == "Player 1")
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        }

        else if (!IsFacingRight && Input.GetKey(KeyCode.D) && this.gameObject.tag == "Player 1")
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        }*/

        //////////////////////////////////////////////////////////////
        ///
        /*else if (IsFacingRight && Input.GetKey(KeyCode.LeftArrow) && this.gameObject.tag == "Player 2")
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        }

        else if (!IsFacingRight && Input.GetKey(KeyCode.RightArrow) && this.gameObject.tag == "Player 2")
        {
            IsFacingRight = !IsFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        */
    }

}
