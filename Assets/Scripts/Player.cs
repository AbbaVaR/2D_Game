using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Director;
using UnityEngine.UI;
public class Player : MonoBehaviour 
{
    protected float maxHP = 100f;
    private float curHP;
    public  float CurHP { get { return curHP; } set { curHP = value; } }
    private float playerD = 25f;
    public float PlayerD { get { return playerD; } }
    protected float maxStam = 100f;
    private float curStam = 100f;
    public float CurStam { get { return curStam; } set { curStam = value; } }
    public Animator anim;
    public Image hpBar;
    private PlayerMove pM;
    public float fill = 1;


    void Start()
    {
        curHP = maxHP;
    }
     
    void FixedUpdate()
    {
        HPbar();
    }

    public void PlayerDamage(float dam)
    {
        if (!pM.Blocking) curHP -= dam; 
        if (curHP <= 0)
        {
            Die(); 
        }
    }

    private void HPbar()
    {
        fill =  curHP/maxHP;
        hpBar.fillAmount = fill;
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
}
