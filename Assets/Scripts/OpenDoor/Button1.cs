using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : DoorButton
{
    public Help help;
    public override void Press()
    {
        anim.Play("ButtonUnL");
        help.help(180);
    }
}
