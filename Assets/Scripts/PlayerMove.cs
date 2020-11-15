using UnityEngine;
using System.Collections;

public class PlayerMove : Player
{
    public float speed = 5f;
    public float jumpForce = 7000f;
    protected bool isFacingRight = true;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    public Transform attackCheck;
    public float attackRadius = 0.35f;
    private bool blocking = false;
    public bool Blocking { get { return blocking; } }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        //IsGround();
        ControlPlayer();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    

    private void ControlPlayer()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Grounded", isGrounded);
        //движение
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        if (!Input.GetKey(KeyCode.Mouse1))
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        if (moveX > 0 && !isFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
        else if (moveX < 0 && isFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
        //прыжок
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("Grounded", false);
            rb.AddForce(Vector2.up * jumpForce);
        }
        //атака
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("Attacking", true);
            Fight2D.Action(attackCheck.position, attackRadius, 9, PlayerD, false);
        }

        else
        {
            anim.SetBool("Attacking", false);
        }
        //блок

        if (Input.GetKey(KeyCode.Mouse1))
        {
            blocking = true;
            anim.Play("Player_block");

        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            blocking = false;
            anim.Play("Player_idle");
        }
    }

}
