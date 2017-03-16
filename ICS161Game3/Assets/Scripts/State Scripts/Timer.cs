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
    private int originalTimerAmount;
    private bool paused;

    public void Start()
    {
        originalTimerAmount = 1;
    }

	public void startTimer () {
        StopAllCoroutines();
        timer = originalTimerAmount * 60 + 1;
        min = Mathf.FloorToInt(timer / 60F);
        sec = Mathf.FloorToInt(timer - min * 60);
        string niceTime = string.Format("{0:00}:{1:00}", min, sec);

        timerText.text = displayText + niceTime;
        StartCoroutine(Countdown());
    }

    public void pauseTimer(bool pausetimer)
    {
        paused = pausetimer;
    }

    private void Update()
    {
        if (gameState.IsGameOver())
            StopAllCoroutines();
        if (timer <= 0)
            gameState.setWinner(4);
    }
	
    IEnumerator Countdown()
    {
        while (min >= 0 && sec >= 0)
        {
            if (!paused)
            {
                timer -= 1;
                min = Mathf.FloorToInt(timer / 60F);
                sec = Mathf.FloorToInt(timer - min * 60);
                string niceTime = string.Format("{0:00}:{1:00}", min, sec);

                timerText.text = displayText + niceTime;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
