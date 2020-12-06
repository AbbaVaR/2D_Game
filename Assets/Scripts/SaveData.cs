using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class SaveData 
{
	//Создание полей с игровыми параметрами
	public float currHP;
	public float HP;

	public float curMP;
	public float MP;

	public float currXP;
	public float XP;

	public int level;

	public float[] position; //В Unity позиция игрока записана с помощью класса Vector3, но его нельзя сериализовать. Чтобы обойти эту проблему, данные о позиции будут помещены в массив типа float.

	public SaveData(Player player) //Конструктор класса
	{
		//Получение данных, которые нужно сохранить
		HP = player.MaxHP;
		currHP = player.CurHP;

		MP = player.MaxSP;
		currXP = player.CurSP;

		level = player.Lvl;

		position = new float[3] //Получение позиции
		{
			player.transform.position.x,
			player.transform.position.y,
			player.transform.position.z
		};
	}
}