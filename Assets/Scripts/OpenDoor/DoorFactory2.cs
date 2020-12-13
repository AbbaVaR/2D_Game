using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFactory2 : DoorAbsFactory
{
    public Button2 b;
    public Door2 d;
    public override void OnTriggerEnter2D(Collider2D obj)
    {
        b.Press();
        if (d != null)
            d.Open();
    }
}
