using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : Door
{
    public override void Open()
    {
        Destroy(gameObject);
    }
}