using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluslvl : MonoBehaviour
{
   public Player player;
    public void HpUp()
    {
        if (player.Money >= player.MoneyLVL)
        {
            player.Lvl += 1;
            player.HpLvl += 0.2f;
            player.MaxHP = 100 * player.HpLvl;
            player.AddMoney(-player.MoneyLVL);
            player.MoneyLVL = (int)100 + 100 * player.Lvl / 5;
            player.AddMoney(0);
            player.CurHP = player.MaxHP;
            player.PlayerDamage(0);
        }

    }

    public void SpUp()
    {
        if (player.Money >= player.MoneyLVL)
        {
            player.Lvl += 1;
            player.SpLvl += 0.2f;
            player.MaxSP = 100 * player.SpLvl;
            player.AddMoney(-player.MoneyLVL);
            player.MoneyLVL = (int)100 + 100 * player.Lvl / 5;
            player.AddMoney(0);
            player.SPDamage(0);
        }

    }

    public void StrUp()
    {
        if (player.Money >= player.MoneyLVL)
        {
            player.Lvl += 1;
            player.StrLvl += 0.2f;
            player.PlayerD = 30 * player.StrLvl;
            player.AddMoney(-player.MoneyLVL);
            player.MoneyLVL = (int)100 + 100 * player.Lvl / 5;
            player.AddMoney(0);
        }

    }

    public void BlockUp()
    {
        if(player.Money >= player.MoneyLVL)
        {
            player.Lvl += 1;
            player.BlockLvl += 0.2f;
            player.BlockStr = 1 * player.BlockLvl;
            player.AddMoney(-player.MoneyLVL);
            player.MoneyLVL = (int)100 + 100 * player.Lvl / 5;
            player.AddMoney(0);
        }


    }
}
