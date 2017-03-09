using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameState : ScriptableObject {
    public GameObject[] characters;

    public int player1health;
    public int player2health;

    private int gamewinner = 0;

    public void Start()
    {
        player1health = 100;
        player2health = 100;
    }

    public bool IsGameOver()
    {
        return gamewinner != 0;
    }

    public int getPlayerHealth(int player)
    {
        if (player == 1)
            return player1health;
        if (player == 2)
            return player2health;
        return 0;
    }

    public void decreasePlayerHealth(int player, int damage)
    {
        if (player == 1)
            player1health -= damage;
        if (player == 2)
            player2health -= damage;
    }

    public int getWinner()
    {
        return gamewinner;
    }

    public void setWinner(int winner)
    {
            gamewinner = winner;
    }

    public void resetPlayerHealth()
    {
        player1health = 100;
        player2health = 100;
    }
}
