using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Player player = new Player();
    public void PlayPress()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadPress()
    {
        SaveData.load = true;
        SceneManager.LoadScene("MainScene");
    }

    public void ExitPress()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
