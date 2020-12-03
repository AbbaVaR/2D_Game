using System;
using System.Collections;
using UnityEngine;

public class Player : AboutPlayer 
{
    public event Action<float> HPchange;
    public event Action<float> SPchange;
    private float hpvalue;
    private float HPvalue
    {
        get
        {
            return hpvalue;
        }
        set
        {
            if (value > 0) hpvalue = value;
            else hpvalue = 0;
        }
    }
    void Start()
    {
        CurHP = MaxHP;
        CurSP = MaxSP;
    }
     
    void FixedUpdate()
    {
        ControlPlayer();
    }

    public void PlayerDamage(float dam)
    {
        if (!Blocking)
        {
        CurHP -= dam;
            HPvalue = CurHP / MaxHP * 100;
        }
        if (HPchange != null)
        {
            
            HPchange.Invoke(HPvalue);
        }
        if (CurHP <= 0)
        {
            Die(); 
        }

    }

    public void SPDamage(float dam)
    {
        CurSP -= dam;
        AddSp();
        
        if (SPchange != null)
        {
            SPchange.Invoke(CurSP/MaxSP*100);
        }
    }

    private void AddSp()
    {
        if (CurSP < MaxSP)
        {
            if (Blocking) StartCoroutine(AddSp_(1.3f, MaxSP * 0.01f));
            else StartCoroutine(AddSp_(1.3f, MaxSP * 0.1f));
        } 
    }

    IEnumerator AddSp_(float timeToWait, float add)
    {
        yield return new WaitForSeconds(timeToWait);
        SPDamage(-add);
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
