 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    public float speed;

    public float positionOfPatrol;
    public Transform point;
    bool moveingRight;
    public Transform player;
    public float stoppingDistance;
    bool chill = true;
    bool angry = false;

	void Start () 
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	void FixedUpdate () 
	{
        CheckPlayer();
        if (Math.Abs(transform.position.x - player.position.x) > 0.85)
            Walk();
    }

    void CheckPlayer()
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

    void Walk()
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

    void Chill()
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

    void Angry()
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
}

