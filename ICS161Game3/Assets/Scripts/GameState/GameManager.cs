using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text winnerText;
    public GameObject endScreen;
    public GameState gameState;

    private ShowPanels showPanels;

    public void Update()
    {
        if (gameState.getWinner() != 0)
        {
            setWinnerText(gameState.getWinner());
            //endScreen.SetActive(true);
        }
    }

    public void setWinnerText(int player)
    {
        winnerText.text = "Player " + player;
    }

    public void setStartConditions()
    {
        gameState.resetPlayerHealth();
        endScreen.SetActive(false);
        gameState.setWinner(0);
    }

}
