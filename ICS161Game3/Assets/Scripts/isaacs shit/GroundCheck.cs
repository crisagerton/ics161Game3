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
		player.jumps = 1;
	}

	void OnTriggerStay2D(Collider2D col)
	{

        if (!col.CompareTag("wall"))
        {
            player.grounded = true;
            player.jumps = 0;
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
        if (!col.CompareTag("wall"))
        {
            player.grounded = true;
            player.jumps = 0;
        }
    }


}