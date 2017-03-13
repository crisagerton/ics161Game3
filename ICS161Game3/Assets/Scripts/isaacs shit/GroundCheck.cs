using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private playerMove player;

	void Start()
	{
		player = gameObject.GetComponentInParent<playerMove> ();
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		player.grounded = true;
		player.jumps = 0;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
		player.jumps = 0;
	}


}