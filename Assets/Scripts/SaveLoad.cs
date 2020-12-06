using UnityEngine;
using System.IO; //Библиотек для работы с файлами
using System.Runtime.Serialization.Formatters.Binary; //Библиотека для работы бинарной сериализацией
using System;

public static class SaveLoad //Создание статичного класса позволит использовать методы без объявления его экземпляров 
{

	private static string path = "d://MyGame/gamesave.game"; //Путь к сохранению. Вы можете использовать любое расширение
	private static BinaryFormatter formatter = new BinaryFormatter(); //Создание сериализатора 

	public static void SaveGame(Player character) //Метод для сохранения
	{
		Debug.Log("Save");
		FileStream fs = new FileStream(path, FileMode.Create); //Создание файлового потока

		SaveData data = new SaveData(character); //Получение данных

		formatter.Serialize(fs, data); //Сериализация данных

		fs.Close(); //Закрытие потока

	}

	public static SaveData LoadGame() //Метод загрузки
	{
		if (File.Exists(path))
		{ //Проверка существования файла сохранения
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока

			SaveData data = formatter.Deserialize(fs) as SaveData; //Получение данных

			fs.Close(); //Закрытие потока
			Debug.Log("Load");

			return data; //Возвращение данных
		}
		else
		{
			return null; //Если файл не существует, будет возвращено null
		}

	}
}