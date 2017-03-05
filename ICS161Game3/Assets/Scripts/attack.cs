using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	private int count;

	void Start() {
		count = 0;
	}

	void Update () {
		++count;
		if (count > 20) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
