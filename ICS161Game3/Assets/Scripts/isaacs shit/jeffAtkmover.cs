using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeffAtkmover : MonoBehaviour {

	private GameObject player2;
	private playerMove move;
	private andrewAtk atk;

	void Start () {
		player2 = GameObject.FindGameObjectWithTag ("player2");
		move = player2.GetComponent <playerMove> ();
		atk = player2.GetComponent <andrewAtk> ();
	}

	void Update () {
		Vector3 newlocat = new Vector3 (player2.transform.position.x + (move.direction * atk.atkRange),
			player2.transform.position.y + .15f, .01f);

		this.transform.position = newlocat;
	}
}
