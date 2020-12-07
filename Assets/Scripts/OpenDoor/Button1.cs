using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : DoorButton
{
    public override void Press()
    {
        Destroy(gameObject);
    }
}
