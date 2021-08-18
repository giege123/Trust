using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Main Movement")]
    public float runSpeed;
    public float ClimbSpeed;
    public float jumpPower;
    public float jumpPadHigh;
    public float fallMultiplyer = 2;
    public float lowJumpMultiplyer = 1;
    public float jumpLerp = 10;

    [Header("KnockBack")]
    public float KB;
    public float KBLen;
    public float KBCout;
    public bool KBRight;

    [Header("Walls")]
    public float slidePower = 1;
    public int side;
    public bool wallGrab;
    public bool wallSlide;
    public bool canMove;
    public bool wallJumped;
    public Transform characterContainer;

    [Header("Other")]
    public bool facingRight;
    public float SlowFactor = 2;
    private Rigidbody2D rb;
    private Animator anim;
    private Collision collision;
    public Vector2 direction;
    /// anim

    public void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collision = GetComponent<Collision>();

    }

    public void Update()
    {


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        direction = new Vector2(x, y);
        Run(direction);
        if (!collision.OnGround && !wallGrab)
        {
            y = 0f;
            direction.y = 0f;
        }

        if (collision.OnGround)
        {
            y = 0f;
            direction.y = 0f;
        }

        /// WallJUMPING -----------------------------------------
        if (collision.OnWall && Input.GetButton("Grab"))
        {
            direction.y = 0f;
            wallGrab = true;
            wallSlide = false;
        }

        if (!collision.OnWall || Input.GetButtonUp("Grab"))
        {
            wallGrab = false;
            wallSlide = false;
        }
        if (wallGrab)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            float speedModifier = y > 0 ? 0.35f : 1;
            rb.velocity = new Vector2(rb.velocity.x, y * (ClimbSpeed * speedModifier));
        }
        else rb.gravityScale = 3;
        if (collision.OnWall && !collision.OnGround)
        {
            if (!wallGrab)
            {
                wallSlide = true;
                Wallslide();
            }
        }

        if (collision.OnWall && collision.OnGround)
        {
            wallSlide = false;
        }
        if (collision.OnGround)
        {
            wallJumped = false;

        }
        // Normal jump
        if (Input.GetButtonDown("Jump"))
        {
            if (collision.OnGround)
            {
                anim.SetTrigger("Jump");
                Jump(Vector2.up);
            }

        }
        if (collision.jumppad)
        {
            anim.SetTrigger("Jump");
            Jumpad();
        }
        // wall Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (!collision.OnGround && collision.OnWall)
            {
                anim.SetTrigger("Jump");
                WallJumpas();
            }
        }
        anim.SetFloat("VerticalAxis", direction.y);
        anim.SetFloat("HorizontalAxis", direction.x);
        anim.SetBool("OnGround", collision.OnGround);
        anim.SetBool("OnAir", !collision.OnGround && !wallGrab && !wallSlide);
        anim.SetBool("Grab", wallGrab);
        anim.SetBool("Slide", wallSlide);

        if (wallGrab) return;
        /// WallJUMPING------------------------------------------

        /// Rotations Right -----------------------------------------

        if (x > 0)
        {
            side = 1;
            Vector3 theScale = characterContainer.localScale;
            if (!facingRight)
            {
                theScale.x *= -1;
                characterContainer.localScale = theScale;
                facingRight = true;
            }
        }
        //
        if (x < 0)
        {
            side = -1;
            Vector3 theScale = characterContainer.localScale;
            if (facingRight)
            {
                theScale.x *= -1;
                characterContainer.localScale = theScale;
                facingRight = false;
            }
        }
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplyer * Time.deltaTime;
        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplyer * Time.deltaTime;
        /// Rotations -----------------------------------------
    }
    public void Wallslide()
    {
        bool pushingWall = false;
        if ((collision.OnRightWall && rb.velocity.x > 0) || (collision.OnLeftWall && rb.velocity.x < 0))
            pushingWall = true;
        float push = pushingWall ? 0 : rb.velocity.x;
        rb.velocity = new Vector2(push, -slidePower);
    }
    public void WallJumpas()
    {
        StartCoroutine(DisableMovement(0.1f));
        Vector2 wallDirection = collision.OnRightWall ? Vector2.left : Vector2.right;
        Jump(Vector2.up + wallDirection);
        wallJumped = true;

    }
    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void Run(Vector2 dir)
    {
        if (!canMove) return;
        if (wallGrab) return;
        if (!wallJumped) rb.velocity = new Vector2(dir.x * runSpeed, rb.velocity.y);
        if (collision.OnSlow)
        {
            rb.velocity = new Vector2(rb.velocity.x / SlowFactor, rb.velocity.y);
        }
        else rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(dir.x * runSpeed, rb.velocity.y), jumpLerp * Time.deltaTime);
    }
    public void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
    }
    public void Jumpad()
    {
        rb.velocity = Vector2.up * jumpPadHigh;
    }


    // void KnockBackMethod()
    // {
    //     if (KBCout <= 0)
    //     {
    //         rb.velocity = new Vector2(mx * movementSpeed, rb.velocity.y);
    //     }
    //     else
    //     {
    //         if (KBRight)
    //         {
    //             rb.velocity = new Vector2(-KB * 2, KB);
    //         }
    //         if (!KBRight)
    //         {
    //             rb.velocity = new Vector2(KB * 2, KB);
    //         }
    //         KBCout -= Time.deltaTime;
    //     }
    // }


}