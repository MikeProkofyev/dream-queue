using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
	public GameObject creditsPanel;
	public GameObject spaceMashPanel;


	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
		UnlockCursor();
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		LockCursor ();
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		UnlockCursor();
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		LockCursor ();
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		UnlockCursor();
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		LockCursor ();
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

	public void ShowCreditsPanel()
	{
		UnlockCursor();
		creditsPanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	public void HideCreditsPanel()
	{
		LockCursor ();
		creditsPanel.SetActive (false);
		optionsTint.SetActive(false);
	}

	public void ShowSpaceMashPanel()
	{
		UnlockCursor();
		spaceMashPanel.SetActive (true);
	}
	
	public void HideSpaceMashPanel()
	{
		LockCursor ();
		spaceMashPanel.SetActive (false);
	}

	public void UnlockCursor () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void LockCursor () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}
}
