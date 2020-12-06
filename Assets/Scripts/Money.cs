using UnityEngine;

public class Money : MonoBehaviour
{

    public Player player;

    void OnTriggerEnter2D(Collider2D obj)
    {
        player.AddMoney(200);
        Destroy(gameObject);
    }
}
