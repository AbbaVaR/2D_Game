using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    Quaternion rotZ;
    public void help(float an)
    {
        rotZ = Quaternion.AngleAxis(an, new Vector3(0, 0, 1));
        transform.rotation *= rotZ;
    }
}
