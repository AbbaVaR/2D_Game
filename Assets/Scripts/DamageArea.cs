using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour {

    public Player player;
    public Pluslvl plusLvl;
    void OnTriggerEnter2D(Collider2D obj)
    {
        player.PlayerDamage(70);
        plusLvl.SpUp();
    }
}
