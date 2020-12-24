using UnityEngine;

public class Money : MonoBehaviour
{

    public Player player;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            player.AddMoney(200);
            Destroy(gameObject);
        }
           
    }
}
