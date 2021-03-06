﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartWindow : GenericWindow {

	public Button continueButton;

	public override void Open ()
	{
		var canContinue = true;

		continueButton.gameObject.SetActive (canContinue);

		if (continueButton.gameObject.activeSelf) 
		{
			firstSelected = continueButton.gameObject;
		}
		base.Open ();
	}

	public void NewGame()
	{
		SceneManager.LoadScene ("PlayerStaging");
	}

	public void Continue()
	{
		Debug.Log ("Continue Pressed");
	}

	public void Options()
	{
		Debug.Log ("Options Pressed");
	}

}
