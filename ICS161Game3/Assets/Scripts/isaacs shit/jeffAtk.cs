﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeffAtk : MonoBehaviour {

	private playerMove move;

	public Object rightAtk;
	public Object leftAtk;
	public string atkKey;
	public string enemy;

	public float atkRange = 1f;
	public int atkSpd = 10;
	public int atkChrg = 10;

	private int atkTimer;
	private int chrgTimer;
	private bool charging;

	private Rigidbody2D rb2d;
	private Player player;
	private Animator anim;

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		move = gameObject.GetComponentInParent<playerMove> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		player = gameObject.GetComponent<Player> ();
		player.attacking = false;
		charging = false;
	}

	void Update () {

		//pre attack delay / charging
		anim.SetBool ("charging", charging);

		if (Input.GetKey (atkKey) && !player.attacking) {
			charging = true;
			player.attacking = true;
		}
		if (charging) {
			chrgTimer++;
		}

		//the actual attack
		if (chrgTimer > atkChrg){
			charging = false; chrgTimer = 0;
			Vector3 spawnlocat = new Vector3 (this.transform.position.x + (move.direction * atkRange),
				this.transform.position.y);
			if (move.direction > 0) {
				Instantiate (rightAtk, spawnlocat, this.transform.rotation);
			} else if (move.direction < 0) {
				Instantiate (leftAtk, spawnlocat, this.transform.rotation);
			}
		}

		//post attack delay
		if (player.attacking) {
			atkTimer++;
		}
		if (atkTimer > (atkSpd + atkChrg)) {
			player.attacking = false; atkTimer = 0;
		}
	}

}