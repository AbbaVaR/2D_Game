using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour {

    public Player player;
    void OnTriggerEnter2D(Collider2D obj)
    {
        player.PlayerDamage(70);
    }
}
