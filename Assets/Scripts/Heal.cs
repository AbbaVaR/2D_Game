using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Player player;
    void OnTriggerEnter2D(Collider2D obj)
    {
        player.PlayerDamage(player.MaxHP*-0.6f);
        Destroy(gameObject);
    }
}
