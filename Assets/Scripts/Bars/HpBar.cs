using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Player player;
    public Text hpBar;
   

    private void OnEnable()
    {
        player.HPchange += UpdateValue;
    }

    private void OnDisable()
    {
        player.HPchange -= UpdateValue;
    }

    public void UpdateValue (float value)
    {
        if (player == null) return;

        hpBar.text = "HP: " + value.ToString() + "%";
    }
}

