using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : AbsEnemyControl
{
    public float speed;
    public float positionOfPatrol;
    public Transform point;
    bool moveingRight;
    public Transform player;
    public float stoppingDistance;
    public float enemyHP = 150f;
    public Player p;
    public FinishDoor finishDoor;
    bool chill = true;
    bool angry = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        CheckPlayer();
    }

    public override void CheckPlayer()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
        }
    }

    public override void Walk()
    {
        if (chill == true)
        {
            Chill();
        }

        else if (angry == true)
        {
            Angry();
        }
    }

    public override void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            moveingRight = false;

        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            moveingRight = true;

        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }
    }

    public override void Angry()
    {
        if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            moveingRight = false;

        }
        else if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            moveingRight = true;

        }
        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }
    }

    public override void TakeDamage(float damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
            p.AddMoney(2000);
            finishDoor.Open();
        }
    }
}
