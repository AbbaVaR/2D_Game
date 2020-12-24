using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	public float damping = 5f;
	public Vector2 offset = new Vector2(0f, 1f);
	private Transform player;
	public Player p;
	private int lastX;

	void Start()
	{
		offset = new Vector2(Mathf.Abs(offset.x), offset.y);
		FindPlayer();
	}
	void Update()
	{
		Camera();
	}

	public void FindPlayer()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		lastX = Mathf.RoundToInt(player.position.x);
		if (p.IsFacingRight)
		{
			transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
		}
	}

	void Camera()
    {
		if (player)
		{
			int currentX = Mathf.RoundToInt(player.position.x);
			lastX = Mathf.RoundToInt(player.position.x);

			Vector3 target;
			if (p.IsFacingRight)
			{
				target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
			}
			else
			{
				target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
			}
			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}
