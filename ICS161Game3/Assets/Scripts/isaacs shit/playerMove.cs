using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public string leftKey;
	public string rightKey;
	public string jumpKey;

	public float direction;
	public float maxSpeed = 2;
	public float maxJumpSpeed = 7;
	public float speed = 50f;
	public float jumpPower = 150f;
	public int jumpLimit = 1;
	public int jumps = 0;

	public bool grounded;
	private int count;

	private Rigidbody2D rb2d;
	private Player player;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		player = gameObject.GetComponent<Player> ();
		direction = 1.0f;
	}

	void Update () {
		//getting input & jumping
		if (Input.GetKeyDown(jumpKey) && jumps < jumpLimit && !player.attacking) {
			rb2d.AddForce (Vector2.up * jumpPower);
			jumps += 1;
		}

		if (Input.GetKey (leftKey)) 
		{
			transform.localScale = new Vector3 (-.25f, transform.localScale.y, 
				transform.localScale.z);
			direction = -1.0f;
		}

		if (Input.GetKey (rightKey)) 
		{
			transform.localScale = new Vector3 (.25f, transform.localScale.y, 
				transform.localScale.z);
			direction = 1.0f;
		}
	}

	void FixedUpdate() {

		//friction
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.6f;

		if (grounded) 
		{
			rb2d.velocity = easeVelocity;
		}

		//setting the direction
		float h;

		if (Input.GetKey (rightKey)) {
			h = 1.0f;
		} else if (Input.GetKey (leftKey)) {
			h = -1.0f;
		} else {
			h = 0.0f;
		}
			
		//move player
		if (h != 0 && !player.attacking) {
			rb2d.AddForce (Vector2.right * speed * h);
		}

		//limit player speed
		if (rb2d.velocity.x > maxSpeed) 
		{
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y); 
		}
		if (rb2d.velocity.x < (-1 * maxSpeed)) 
		{
			rb2d.velocity = new Vector2 (-1 * maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.y > maxJumpSpeed) 
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, maxSpeed);
		}
		if (h == 0) {
			rb2d.velocity = new Vector3 (0.0f, rb2d.velocity.y, 0.0f);
		}
	}
}
