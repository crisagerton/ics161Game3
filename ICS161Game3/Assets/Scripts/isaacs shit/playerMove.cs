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
	public AudioClip jmpsound;

	public bool grounded;
	private bool moving;
	private int count;
	private float scale;

	private Rigidbody2D rb2d;
	private Player player;
	private Animator anim;
	private AudioSource source;

	void Start () {
		source = gameObject.GetComponent<AudioSource> ();
		anim = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		player = gameObject.GetComponent<Player> ();
		direction = 1.0f;
		scale = transform.localScale.x;
	}

	void Update () {
		//getting input & jumping
		anim.SetBool("grounded", grounded);

		if (Input.GetKeyDown(jumpKey) && jumps <= jumpLimit && !player.attacking) {
			jumps++;
			rb2d.AddForce (Vector2.up * jumpPower);

			source.clip = jmpsound;
			source.Play ();
		}

		if (!player.attacking) {
			if (Input.GetKey (leftKey)) {
				transform.localScale = new Vector3 (-scale, 
					transform.localScale.y, transform.localScale.z);
				direction = -1.0f;
			}

			if (Input.GetKey (rightKey)) {
				transform.localScale = new Vector3 (scale, 
					transform.localScale.y, transform.localScale.z);
				direction = 1.0f;
			}
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
		anim.SetBool("moving", moving);

		float h;

		if (Input.GetKey (rightKey)) {
			moving = true;
			h = 1.0f;
		} else if (Input.GetKey (leftKey)) {
			moving = true;
			h = -1.0f;
		} else {
			moving = false;
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
