using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameState gameState;
    public int timer;
    public string displayText;
    public Text timerText;

    private int sec;
    private int min;

	// Use this for initialization
	void Start () {
        timer = timer * 60;
        min = Mathf.FloorToInt(timer / 60F);
        sec = Mathf.FloorToInt(timer - min * 60);
        string niceTime = string.Format("{0:00}:{1:00}", min, sec);

        timerText.text = displayText + niceTime;
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (gameState.IsGameOver())
        {
            StopAllCoroutines();
        }
    }
	
    IEnumerator Countdown()
    {
        while (min >= 0 && sec >= 0)
        {
            timer -= 1;
            min = Mathf.FloorToInt(timer / 60F);
            sec = Mathf.FloorToInt(timer - min * 60);
            string niceTime = string.Format("{0:00}:{1:00}", min, sec);

            timerText.text = displayText + niceTime;
            yield return new WaitForSeconds(1f);
        }
    }
}
