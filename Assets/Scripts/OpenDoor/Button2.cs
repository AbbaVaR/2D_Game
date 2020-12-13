
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : DoorButton
{
    public Help help;
    public override void Press()
    {
        anim.Play("Button2UnL");
        help.help(270);
    }
}
