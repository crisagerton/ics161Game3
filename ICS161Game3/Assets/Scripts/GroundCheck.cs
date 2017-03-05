using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;

	void Start()
	{
		player = gameObject.GetComponentInParent<Player> ();
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		player.grounded = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
	}


}