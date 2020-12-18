using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mbar : MonoBehaviour
{
    public Player player;
    public Text mBar;


    private void OnEnable()
    {
        player.Mchange += UpdateValue;
    }

    private void OnDisable()
    {
        player.Mchange -= UpdateValue;
    }

    public void UpdateValue(float value)
    {
        if (player == null) return;

        mBar.text = player.MoneyLVL.ToString() + " / " + value.ToString();
    }
}

