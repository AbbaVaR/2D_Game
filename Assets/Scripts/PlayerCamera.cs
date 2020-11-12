using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public GameObject player;
	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, (player.transform.position.y+1.7f)*0.4f, -5f);
	}
}