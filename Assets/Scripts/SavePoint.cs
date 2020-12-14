using System;
using System.Collections;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    delegate void StartPoint();
    StartPoint startPoint;
    public Player player;
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
            player.CurHP = player.MaxHP;
            player.PlayerDamage(0);
            Debug.Log("SavePoint");
        }
    }

    void FixedUpdate()
    {
        if (startPoint != null)
            startPoint();
    }

}
