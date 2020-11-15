using System.Collections;
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
    }

    public void PlayerDamage(float dam)
    {
        //if (!pM.Blocking) 
        CurHP -= dam; 
        if (CurHP <= 0)
        {
            Die(); 
        }
    }

    /*private void HPbar()
    {
        FillHpBar =  CurHP/MaxHP;
        hpBar.fillAmount = FillHpBar;
    }*/

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
