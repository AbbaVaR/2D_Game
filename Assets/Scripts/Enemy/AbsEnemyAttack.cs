using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsEnemyAttack : MonoBehaviour
{
    public abstract void Control();
    public abstract void OnEnemyAttack();
}
