using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsSavePoint : MonoBehaviour
{
    protected delegate void StartPoint();

    public abstract void PointSave();
}
