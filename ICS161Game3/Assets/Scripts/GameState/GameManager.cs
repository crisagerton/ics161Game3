using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text winnerText;
    public GameObject endScreen;
    public GameObject pauseScreen;
    public GameState gameState;
    public Timer gameTimer;
    public GameObject player1;
    public GameObject player2;

    //private ShowPanels showPanels;
    private PlayMusic playMusic;
    private bool titleScreenActive = true;

    public void Start()
    {
        playMusic = GetComponent<PlayMusic>();
    }

    public void Update()
    {
        checkWinConditions();
        if (gameState.getWinner() != 0)
            setEndState();
        if (Input.GetKeyDown("escape") && !titleScreenActive)
        {
            Paused();
        }
    }

    public void setStartConditions()
    {
        playMusic.PlaySelectedMusic(1);
        titleScreenActive = false;
        gameState.resetPlayerHealth();
        endScreen.SetActive(false);
        gameState.setWinner(0);
        gameTimer.startTimer();
        player1.transform.position = new Vector3(-4, 0, 0);
        player2.transform.position = new Vector3(3.5f, 0, 0);
        EnablePlayers(true);
    }

    public void setEndState()
    {
        if (!titleScreenActive)
        {
            setWinnerText(gameState.getWinner());
            endScreen.SetActive(true);
            playMusic.PlaySelectedMusic(2);
        }
    }

    public void setWinnerText(int player)
    {
        if (player < 3)
            winnerText.text = "Player " + player;
        else if (player == 3)
            winnerText.text = "Mutual Destruction!";
    }

    public void checkWinConditions()
    {
        if (!checkPlayersHaveHealth() || checkTimerFinished())
            setWinnerBasedOnHealth();
        if (checkPlayerPosition(player1))
            dealWithInstaDeath(player1);
        if (checkPlayerPosition(player2))
            dealWithInstaDeath(player2);
    }

    //Private helper methods
    private bool checkPlayersHaveHealth()
    {
        int player1health = gameState.getPlayerHealth(1);
        int player2health = gameState.getPlayerHealth(2);
        return (player1health > 0 && player2health > 0); 
    }

    private bool checkTimerFinished()
    {
        return gameTimer.timer <= 0;
    }

    private bool checkPlayerPosition(GameObject player)
    {
        return player.transform.position.y <= -5.5;
    }

    private void setWinnerBasedOnHealth()
    {
        int player1health = gameState.getPlayerHealth(1);
        int player2health = gameState.getPlayerHealth(2);

        if (player1health <= 0 && player2health <= 0 || (gameState.IsGameOver() && player1health == player2health)) //checking to see if the players tied
            gameState.setWinner(3);
        else if (player1health <= 0 || (gameState.IsGameOver() && player1health < player2health)) //checking to see if player1 lost
            gameState.setWinner(2);
        else if (player2health <= 0 || (gameState.IsGameOver() && player2health < player1health)) //checking to see if player2 lost
            gameState.setWinner(1);

        killLooser();
    }

    private void dealWithInstaDeath(GameObject player) //falling off the stage
    {
        if (player == player1)
            gameState.setWinner(2);
        else if (player == player2)
            gameState.setWinner(1);

        killLooser();
    }

    private void EnablePlayers(bool enabled)
    {
        player1.SetActive(enabled);
        player2.SetActive(enabled);
    }

    private void killLooser()
    {
        int winner = gameState.getWinner();
        if (winner == 1)
            player2.SetActive(false);
        if (winner == 2)
            player1.SetActive(false);
        if (winner == 3)
            EnablePlayers(false);
    }

    public void Paused()
    {
        pauseScreen.SetActive(true);
        player1.SetActive(false);
        player2.SetActive(false);
        gameTimer.pauseTimer(true);
    }

    public void Unpaused()
    {
        pauseScreen.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(true);
        gameTimer.pauseTimer(false);
    }

}
