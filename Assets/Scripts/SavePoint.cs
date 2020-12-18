using System;
using System.Collections;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    delegate void StartPoint();
    StartPoint startPoint;
    public Player player;
    public OpenIngameMenu menu;
    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("1");
        startPoint += PointSave;
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        Debug.Log("2");
        startPoint -= PointSave;
    }

    private void PointSave()
    {
        if (Input.GetButtonDown("Use"))
        {
            SaveLoad.SaveGame(player);
            player.CurHP = player.MaxHP;
            Debug.Log("SavePoint");
            menu.ShowHideIGM();
            player.PlayerDamage(0);

        }
    }

    void FixedUpdate()
    {
        if (startPoint != null)
            startPoint();
    }

}
