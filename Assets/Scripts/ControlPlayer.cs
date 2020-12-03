using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IControlPlayer : Player
{
    public virtual void Control(ControlPlayer controlPlayer) { }
    protected void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
public class ControlPlayer : AboutPlayer
{
    public IControlPlayer State { get; set; }

    public ControlPlayer(IControlPlayer cp)
    {
        State = cp;
    }
    public void Control()
    {
        State.Control(this);
    }
}

public class Normal : IControlPlayer
{
    public override void Control(ControlPlayer controlPlayer)
    {

        if (CurHP <= 0)
            controlPlayer.State = new Die();
        else if (CurSP <= 0)
            controlPlayer.State = new Tired();
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);
        anim.SetBool("Grounded", IsGrounded);
        //движение
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        if (!Blocking)
            rb.MovePosition(rb.position + Vector2.right * moveX * Speed * Time.deltaTime);
        if (moveX > 0 && !IsFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
        else if (moveX < 0 && IsFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
        //прыжок
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space) && !Blocking)
        {
            anim.SetBool("Grounded", false);
            rb.AddForce(Vector2.up * JumpForce);
        }
        //атака
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SPDamage(30);
            anim.SetBool("Attacking", true);
            Fight2D.Action(attackCheck.position, AttackRadius, 9, PlayerD, false);
        }
        else
        {
            anim.SetBool("Attacking", false);
        }
        //блок
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Blocking = true;
            anim.Play("Player_block");

        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Blocking = false;
            anim.Play("Player_idle");
        }
    }
}

public class Tired : IControlPlayer
{
    public override void Control(ControlPlayer controlPlayer)
    {
        if (CurHP <= 0)
            controlPlayer.State = new Die();
        else if (CurSP > 0)
            controlPlayer.State = new Normal();
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);
        anim.SetBool("Grounded", IsGrounded);
        Blocking = false;
        anim.Play("Player_idle");
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        if (!Blocking)
            rb.MovePosition(rb.position + Vector2.right * moveX * Speed * 0.4f * Time.deltaTime);
        if (moveX > 0 && !IsFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
        else if (moveX < 0 && IsFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
    }

}

public class Die : IControlPlayer
{
    public override void Control(ControlPlayer controlPlayer)
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);
        anim.SetBool("Grounded", IsGrounded);
        anim.Play("Player_die");
    }
}