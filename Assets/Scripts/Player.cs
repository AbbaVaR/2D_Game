﻿using System.Collections;
using UnityEngine;

public class Player : AboutPlayer 
{
    void Start()
    {
        CurHP = MaxHP;
        CurStam = MaxStam;
    }
     
    void FixedUpdate()
    {
        ControlPlayer();
    }

    public void PlayerDamage(float dam)
    {
        if (!Blocking) 
        CurHP -= dam; 
        if (CurHP <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        anim.Play("Player_die");
        StartCoroutine(Waiting(1f));
    }
    IEnumerator Waiting(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        Destroy(gameObject);
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void ControlPlayer()
    {

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
