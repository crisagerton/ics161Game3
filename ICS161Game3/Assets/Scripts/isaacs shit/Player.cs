using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int playernumber;
	public string enemy;

    public GameState gameState;

	public bool attacking;
	public bool hurt;

	private Rigidbody2D rb2d;
	private Animator anim;
	private int count;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		attacking = false;
		hurt = false;
		count = 0;
	}

	void Update () {
		anim.SetBool ("hurt", hurt);

		if (hurt) {
			count++;
		}
		if (count > 30){
			hurt = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag(enemy)){
			hurt = true;
            gameState.decreasePlayerHealth(playernumber, 10);
            if (gameState.getPlayerHealth(playernumber) <= 0)
                gameState.setWinner(playernumber);

        }
	}
}
