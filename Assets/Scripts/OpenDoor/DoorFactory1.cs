using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFactory1 : DoorAbsFactory
{   public Button1 b ;
    public Door1 d;
    public override void OnTriggerEnter2D(Collider2D obj)
    { 
        b.Press();
        if( d != null)
            d.Open();
    }
}
