using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainChapter : MonoBehaviour
{
    public float maxHealth = 100; //Здоровье игрока
    public float currHealth = 100;
    public Rigidbody2D rb; //С помощью Rigidbody 2D будет осуществляться управление объектом
    public float jumpForce = 4000f; //Сила прыжка
    public float speed = 7f; //Скорость движения
	public bool isRightSide = true;
	public bool isGrounded;
	public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (currHealth > 0) //Управление объектом будет доступно, если здоровье выше нуля
        {
            float moveX = Input.GetAxis("Horizontal"); //Получение направления движения
            rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime); //Изменение позиции

			animator.SetFloat("Speed", Math.Abs(moveX));
		
            if (Input.GetKeyDown("space")) 
            {
				Jump(); 
            }

			if ((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide)) //Если игрок начал двигаться в противоположную сторону
			{ 
				if (moveX != 0f) 
				{ 
					Spin (); 
				}
			}
        }

        else
        {
            Destroy(gameObject);
        }


    }

	void Spin() //поворот персонажа вправо/влево
	{
		isRightSide = !isRightSide;
		transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y * 1f);
	}

	void Jump() 

	{
		if(isGrounded) //Можно прыгнуть, только если персонаж на земле
		{
			rb.AddForce(Vector2.up * jumpForce); //Добавление силы прыжка
			isGrounded = false;

			animator.SetBool("isGrounded", isGrounded); //Изменение параметра
		}
	}
}
