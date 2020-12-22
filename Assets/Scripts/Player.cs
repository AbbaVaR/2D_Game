using System;
using System.Collections;
using UnityEngine;

public class Player : AboutPlayer
{
    public event Action<float> HPchange;
    public event Action<float> SPchange;
    public event Action<float> Mchange;

 
    void Start()
    {
        MoneyLVL = (int)100 + 100 * Lvl / 5;
        MaxHP = 100 * HpLvl;
        MaxSP = 100 * SpLvl;
        PlayerD = 15 * StrLvl;
        BlockStr = 1 * BlockLvl;
        CurSP = MaxSP;
        if (SaveData.load)
            LoadCharacter();
    }

    void FixedUpdate()
    {
        ControlPlayer();
    }

    public void PlayerDamage(float dam)
    {
        float tempD;
        if (!Blocking)
        {
            CurHP -= dam;
            anim.Play("Player_hurt");
        }
        else
        {
            tempD = dam * BlockStr;
            if (CurSP < tempD)
                CurHP -= tempD - CurSP;
            SPDamage(tempD);
        }

        if (HPchange != null)
        {
            HPchange.Invoke(CurHP);
        }
    }

    public void SPDamage(float dam)
    {
        CurSP -= dam;
        AddSp();

        if (SPchange != null)
        {
            SPchange.Invoke(CurSP);
        }
    }

    private void AddSp()
    {
        if (CurSP < MaxSP)
        {
            if (Blocking) 
                StartCoroutine(AddSp_(2f, MaxSP * 0.01f));
            else if (CurSP <= 0)
            {
                StartCoroutine(AddSp_(10f, MaxSP * 0.1f));
            }
            else
                StartCoroutine(AddSp_(2f, MaxSP * 0.1f));
        }
    }

    public void AddMoney(int money)
    {
        Money += money;

        if (Mchange != null)
        {
            Mchange.Invoke(Money);
        }
    }
    IEnumerator AddSp_(float timeToWait, float add)
    {
        yield return new WaitForSeconds(timeToWait);
        SPDamage(-add);
    }

    private void ControlPlayer()
    {
        if (CurHP <= 0) 
        {
            Die();
        }
        else if (CurSP <= 0)
        {
            Tired();
        }
        else
        {
            Normal();
        }
    }

    private void Normal ()
    {
        anim.SetBool("Tired", false);
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);
        anim.SetBool("Grounded", IsGrounded);
        //движение
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        if (!Blocking)
            rb.MovePosition(rb.position + Vector2.right * moveX * Speed * Time.deltaTime);
        if (moveX > 0 && !IsFacingRight && !Blocking)
            Flip();
        else if (moveX < 0 && IsFacingRight && !Blocking)
            Flip();
        //прыжок
        if (IsGrounded && Input.GetButtonDown("Jump") && !Blocking)
        {
            anim.SetBool("Grounded", false);
            
            rb.AddForce(Vector2.up * JumpForce);
        }
        //атака
        if (Input.GetButtonDown("Fire1"))
        {
            SPDamage(30);
            anim.SetBool("Attacking", true);
            Fight.Action(attackCheck.position, AttackRadius, 9, PlayerD, false);
        }

        else
        {
            anim.SetBool("Attacking", false);
        }
        //блок

        if (Input.GetButton("Fire2"))
        {
            Blocking = true;
            anim.Play("Player_block");

        }
        if (Input.GetButtonUp("Fire2"))
        {
            Blocking = false;
            anim.Play("Player_idle");
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            LoadCharacter();
        }
    }

    private void Tired()
    {
        Blocking = false;
        anim.SetBool("Attacking", false);
        anim.SetBool("Tired", true);
        // anim.Play("Player_idle");
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundRadius, whatIsGround);
        anim.SetBool("Grounded", IsGrounded);
        //медленное движение
        float moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveX));
        if (!Blocking)
            rb.MovePosition(rb.position + Vector2.right * moveX * Speed * 0.4f * Time.deltaTime);
        if (moveX > 0 && !IsFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
        else if (moveX < 0 && IsFacingRight && !Input.GetKey(KeyCode.Mouse1))
            Flip();
    }
    private void Die()
    {
        Blocking = false;
        anim.Play("Player_die");
        LoadCharacter();
        anim.Play("Player_idle");

    }

private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    public void LoadCharacter()
    {
        SaveData data = SaveLoad.LoadGame();

        if (!data.Equals(null)) 
        {
            CurHP = data.curHP;
            CurSP = data.curSP;
            Lvl = data.lvl;
            Money = data.money;
            MaxHP = data.hpLvl;
            SpLvl = data.spLvl;
            StrLvl = data.strLvl;
            BlockLvl = data.blockLvl;
            MoneyLVL = (int)100 + 100 * Lvl / 5;
            MaxHP = 100 * HpLvl;
            MaxSP = 100 * SpLvl;
            PlayerD = 30 * StrLvl;
            BlockStr = 1 * BlockLvl;

            transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            HPchange.Invoke(CurHP);
            SPchange.Invoke(CurSP);
            Mchange.Invoke(Money);
        }
    }
}

