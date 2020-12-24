using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsEnemyControl : MonoBehaviour
{
    public abstract void CheckPlayer();
    public abstract void Walk();
    public abstract void Chill();
    public abstract void Angry();
    public abstract void TakeDamage(float damage);

}
