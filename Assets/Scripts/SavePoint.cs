using System;
using System.Collections;
using UnityEngine;

public class SavePoint : AbsSavePoint
{
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

    public override void PointSave()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SaveLoad.SaveGame(player);
            player.CurHP = player.MaxHP;
            Debug.Log("SavePoint");
            menu.ShowHideIGM();
            player.PlayerDamage(0);

        }
    }

    void Update()
    {
        if (startPoint != null)
            startPoint();
    }

}
