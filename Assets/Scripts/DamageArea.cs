﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour {

    public Player player;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D obj)
    {
        player.PlayerDamage(70);
        anim.SetBool("Active", true);
    }
}
