using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AbsEnemyAttack
{
    private float timeBtwAttack = 70f;
    private float startTimeBtwAttack;
    public float speed;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private Player player;
    public Animator anim;
    public bool flag = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
    }

    void FixedUpdate()
    {
        Control();
        OnEnemyAttack();
    }

    public override void Control()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
    }


    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        flag = true;
    }
    public void OnTriggerExit2D(Collider2D obj)
    {
        flag = false;
    }

    public override void OnEnemyAttack()
    {
        if (flag)
        {
            if (timeBtwAttack == 70f)
            {
                anim.Play("enemy_attack");
                player.PlayerDamage(30f);
                timeBtwAttack = 0f;
            }
            else
            {
                timeBtwAttack += 1f;
            }
        }
    }
}



