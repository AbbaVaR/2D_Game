using UnityEngine;

public abstract class DoorAbsFactory : MonoBehaviour
{
    public abstract void OnTriggerEnter2D(Collider2D obj);
}
public abstract class DoorButton : MonoBehaviour
{
    public abstract void Press();
}

public abstract class Door: MonoBehaviour
{
    public abstract void Open();
}

