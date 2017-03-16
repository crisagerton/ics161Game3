using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

    public GameState gamestate;
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel
    public GameObject instructionsPanel;
    public GameObject mechanicsPanel;
    public GameObject endGamePanel;

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
	}

    public void ShowMechanicsPanel()
    {
        mechanicsPanel.SetActive(true);
    }

    public void HideMechanicsPanel()
    {
        mechanicsPanel.SetActive(false);
    }

    public void ShowEndPanel()
    {
        endGamePanel.SetActive(true);
    }

    public void HideEndPanel()
    {
        endGamePanel.SetActive(false);
    }

    public void ShowInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
    }
}
