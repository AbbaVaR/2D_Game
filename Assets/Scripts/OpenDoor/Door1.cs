using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : Door
{
    public override void Open()
    {
        Destroy(gameObject);
    }
}
