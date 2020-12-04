using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluslvl : MonoBehaviour
{
   public Player player;
    public void HpUp()
    {
        player.Lvl += 1;
        player.HpLvl += 0.2f;
        player.MaxHP = 100 * player.HpLvl;
        player.Money -= player.MoneyLVL;
    }

    public void SpUp()
    {
        player.Lvl += 1;
        player.SpLvl += 0.2f;
        player.MaxSP = 100 * player.SpLvl;
        player.Money -= player.MoneyLVL;
    }

    public void StrUp()
    {
        player.Lvl += 1;
        player.StrLvl += 0.2f;
        player.PlayerD = 30 * player.StrLvl;
        player.Money -= player.MoneyLVL;
    }

    public void BlockUp()
    {
        player.Lvl += 1;
        player.BlockLvl += 0.2f;
        player.BlockStr = 1 * player.BlockLvl;
        player.Money -= player.MoneyLVL;
    }
}
