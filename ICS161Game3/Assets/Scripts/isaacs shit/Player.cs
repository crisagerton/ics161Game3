using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int playernumber;
	public string enemy;

    public GameState gameState;

	public bool attacking;

	private Rigidbody2D rb2d;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		attacking = false;
	}

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag(enemy)){
            gameState.decreasePlayerHealth(playernumber, 10);
            if (gameState.getPlayerHealth(playernumber) <= 0)
                gameState.setWinner(playernumber);

        }
	}
}
