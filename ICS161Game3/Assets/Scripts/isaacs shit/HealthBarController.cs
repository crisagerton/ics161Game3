using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    public Slider healthbar;
    public int player;
    public GameState gameState;

    private void FixedUpdate()
    {
        healthbar.value = gameState.getPlayerHealth(player);
    }
}
