using UnityEngine;
using System.Collections;

public class PlayerMove : PlayerChar
{
    public float speed = 5f;
    public float jumpForce = 7000f;
    protected bool isFacingRight = true;
    public Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.1f;
    public LayerMask whatIsGround;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        IsGround();
        Jump();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void IsGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Grounded", isGrounded);
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Grounded", false);
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));

        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (moveX > 0 && !isFacingRight)
            Flip();
        else if (moveX < 0 && isFacingRight)
            Flip();
    }
}