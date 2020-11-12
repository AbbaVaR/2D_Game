using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public float enemyHP = 100;
	void Start () 
	{
		
	}
	void Update () 
	{
		if (enemyHP < 0)
        {
			Destroy(gameObject);
        }
	}
}
