using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour {

	public MainChapter player;
	public LayerMask groundLayers;
	private void OnTriggerEnter2D(Collider2D other)
    {
		if (1 << other.gameObject.layer == groundLayers)
        {
			player.isGrounded = true;
        }

    }

	private void OnTriggerExit2D(Collider2D other)
	{
		if (1 << other.gameObject.layer == groundLayers.value)
		{
			player.isGrounded = false;
		}

	}

}
