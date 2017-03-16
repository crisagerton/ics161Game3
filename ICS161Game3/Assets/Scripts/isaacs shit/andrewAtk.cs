using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class andrewAtk : MonoBehaviour {

	private playerMove move;

	public Object rightAtk;
	public Object leftAtk;
	public string atkKey;
	public string enemy;

	public float atkRange = 1f;
	public int atkSpd = 10;

	private int atkTimer;

	private Rigidbody2D rb2d;
	private Player player;
	private Animator anim;

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		move = gameObject.GetComponent<playerMove> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		player = gameObject.GetComponent<Player> ();
		player.attacking = false;
	}

	void Update () {
		if (Input.GetKey (atkKey) && !player.attacking) {
			player.attacking = true;
			anim.SetBool ("attacking", player.attacking);

			Vector3 spawnlocat = new Vector3 (this.transform.position.x + (move.direction * atkRange),
				this.transform.position.y + .15f, .01f);
			if (move.direction > 0) {
				Instantiate (rightAtk, spawnlocat, this.transform.rotation);
			} else if (move.direction < 0) {
				Instantiate (leftAtk, spawnlocat, this.transform.rotation);
			}
		}

		if (player.attacking) {
			atkTimer++;
		}

		if (atkTimer > atkSpd) {
			player.attacking = false;
			atkTimer = 0;
			anim.SetBool ("attacking", player.attacking);
			}
	}
}
