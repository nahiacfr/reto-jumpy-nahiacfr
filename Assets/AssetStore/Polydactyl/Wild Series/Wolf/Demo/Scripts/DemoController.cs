﻿/* Scripted by Bamabu - omabuarts@gmail.com */
using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour {

	[Space (10)]
	public Animator anim;
	public Dropdown dropdown;

	public void NextAnim () {

		if (dropdown.value >= dropdown.options.Count - 1)
			dropdown.value = 0;
		else
			dropdown.value++;

		PlayAnim ();
	}

	public void PrevAnim () {

		if (dropdown.value <= 0)
			dropdown.value = dropdown.options.Count - 1;
		else
			dropdown.value--;
		
		PlayAnim ();
	}

	public void PlayAnim () {

		anim.SetTrigger (dropdown.options [dropdown.value].text);
	}

	public void GoToWebsite (string URL) {

		Application.OpenURL (URL);
	}
}