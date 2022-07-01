using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Properties

    [SerializeField] public float speed;
    [SerializeField] private float maxFallSpeed;
    [SerializeField] private float maxJumpSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] private float checkRadius;
    [SerializeField] private int jumpsValue;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheckLeft;
    [SerializeField] private Transform wallCheckRight;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private LayerMask whatIsKillingObstacle;

    private float moveInput;

    private Rigidbody2D rb;
    [SerializeField] private GameObject Sprite;
    [SerializeField] private GameObject Trail;

    private bool faceRight = true;

    private bool isGrounded;
    private bool isWalledLeft;
    private bool isWalledRight;
    private bool isJumping;
    private bool jumpedLeft;
    private bool jumpedRight;

    private int jumps;

    Animator animator;

    #endregion

    // START //

    #region
    private void Start()
    {
        jumps = jumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion

    void Awake()
    {
        animator = Sprite.GetComponent<Animator>();
    }

    // FIXED UPDATE //

    #region FixedUpdate
    private void FixedUpdate()
    {
        // ALLOW JUMPING // 

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isWalledLeft = Physics2D.OverlapCircle(wallCheckLeft.position, checkRadius, whatIsWall);
        isWalledRight = Physics2D.OverlapCircle(wallCheckRight.position, checkRadius, whatIsWall);


        // FALL SPEED //

        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
        if (rb.velocity.y > maxJumpSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
        }

        // MOVE INPUT + SPRITE FLIP //

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(faceRight == false && moveInput > 0)
        {
            Flip();
        } else if(faceRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    #endregion

    // UPDATE //

    #region Update
    private void Update()
    {
        Jump();
        WallJump();

        // ANIMATIONS //

        animator.SetBool("Jump", isJumping);
        animator.SetBool("Grounded", isGrounded);
    }
    #endregion

    // JUMP & WALLJUMP //

    #region Jump
    private void Jump()
    {
        if (isGrounded)
        {
            isJumping = false;
            jumps = jumpsValue;
        }
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumps--;
            isJumping = true;
        }
        
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && jumps > 0 && rb.velocity.y > 0)
        {
            rb.velocity = Vector2.up * (jumpForce / 2);
        }
        // Stop animator wanneer y velocity kleiner is dan 220
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || rb.velocity.y < 220)
        {
            isJumping = false;
        }

    }

    private void WallJump()
    {
        if(isWalledLeft == false)
        {
            jumpedLeft = true;
        }

        if (isWalledRight == false)
        {
            jumpedRight = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isWalledLeft && jumpedLeft)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpedLeft = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isWalledRight && jumpedRight)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpedRight = false;
        }
    }
    #endregion

    // FLIP CHARACTER SPRITE //

    #region Flip
    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    #endregion
}