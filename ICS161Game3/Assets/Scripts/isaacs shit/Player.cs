using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int playernumber;
	public Object atkobj;
	public Object atkobj2;
	public string left;
	public string right;
	public string jump;
	public string attack;
	public string enemy;
	//public Text lives;
    //public int life;
    public GameState gameState;

	public float maxSpeed = 2;
	public float maxJumpSpeed = 7;
	public float speed = 50f;
	public float jumpPower = 150f;
	public float range = 1f;

	public bool grounded;
	private bool attacking;
	private int count;
	private float direction;

	private Rigidbody2D rb2d;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		//life = 6;
		attacking = false;
		direction = 1.0f;
	}

	void Update () {
		if (Input.GetKeyDown(jump) && grounded) {
			rb2d.AddForce (Vector2.up * jumpPower);
		}

		if (Input.GetKey (left)) 
		{
			transform.localScale = new Vector3 (-.25f, transform.localScale.y, 
				transform.localScale.z);
			direction = -1.0f;
		}

		if (Input.GetKey (right)) 
		{
			direction = 1.0f;
			transform.localScale = new Vector3 (.25f, transform.localScale.y, 
				transform.localScale.z);
		}

		if (Input.GetKey (attack) && !attacking) {
			Vector3 spawnlocat = new Vector3 (this.transform.position.x + (direction * range),
				                     this.transform.position.y);
			if (direction > 0) {
				Instantiate (atkobj, spawnlocat, this.transform.rotation);
			} else if (direction < 0) {
				Instantiate (atkobj2, spawnlocat, this.transform.rotation);
			}
			attacking = true;
		}

		if (attacking) {
			count++;
		}
		if (count > 20) {attacking = false; count = 0;}
	}

	void FixedUpdate()
	{
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.6f;

		float h;

		if (Input.GetKey (right)) {
			h = 1.0f;
		} else if (Input.GetKey (left)) {
			h = -1.0f;
		} else {
			h = 0.0f;
		}

		//friction
		if (grounded) 
		{
			rb2d.velocity = easeVelocity;
		}

		//move player
		if (h != 0) {
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
		if (h == 0) {
			rb2d.velocity = new Vector3 (0.0f, rb2d.velocity.y, 0.0f);
		}

		//player lives
		//if (life == 6) {
		//	lives.text = "Player Lives = 3";
		//} else if (life == 4) {
		//	lives.text = "Player Lives = 2";
		//} else if (life == 2) {
		//	lives.text = "Player Lives = 1";
		//} else if (life <= 0) {
		//	lives.text = "Player Lives = 0";
		//}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag(enemy)){
            //life -= 1;
            gameState.decreasePlayerHealth(playernumber, 10);
            if (gameState.getPlayerHealth(playernumber) <= 0)
                gameState.setWinner(playernumber);

        }
	}
}
