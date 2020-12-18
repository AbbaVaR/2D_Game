using UnityEngine;
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary; 
using System;

public static class SaveLoad 
{

	private static string path = Application.persistentDataPath + "/gamesave.oursave"; 
	private static BinaryFormatter formatter = new BinaryFormatter(); 
	public static void SaveGame(Player character) 
	{
		Debug.Log("Save");
		FileStream fs = new FileStream(path, FileMode.Create); 

		SaveData data = new SaveData(character); 

		formatter.Serialize(fs, data); 

		fs.Close(); 

	}

	public static SaveData LoadGame() 
	{
		if (File.Exists(path))
		{ 
			FileStream fs = new FileStream(path, FileMode.Open); 

			SaveData data = formatter.Deserialize(fs) as SaveData; 

			fs.Close();
			Debug.Log("Load");

			return data; 
		}
		else
		{
			return null; 
		}

	}
}