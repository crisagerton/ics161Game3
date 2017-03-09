using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	public int atkspeed;
	private int count;

	void Start() {
		count = 0;
	}

	void Update () {
		++count;
		if (count > atkspeed) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
