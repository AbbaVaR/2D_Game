using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class SaveData 
{
    public static bool load = false;
    public float curHP;
    public float curSP;
    public int lvl;
	public int money;
    public float hpLvl;
    public float spLvl;
    public float strLvl;
    public float blockLvl;
    public float[] position; 

	public SaveData(Player player)
	{
        curHP = player.CurHP;
        curSP = player.CurSP;
        lvl = player.Lvl;
        money = player.Money;
        hpLvl = player.MaxHP;
        spLvl = player.SpLvl;
        strLvl = player.StrLvl;
        blockLvl = player.BlockLvl;
        position = new float[3]
		    {
			    player.transform.position.x,
			    player.transform.position.y,
			    player.transform.position.z
		    };
	}
}