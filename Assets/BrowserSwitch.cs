﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BrowserSwitch : MonoBehaviour {
	
	
	void Start ()
	{
		Debug.Log("Start");
	}
	
	
	/*
	void OnGUI()
	{
		float xx = Screen.width * 0.5f - 100;
		float yy = Screen.height * 0.5f - 100;
		float ww = 200;
		float hh = 200;
		
		if(GUI.Button(new Rect(xx, yy, ww, hh), "Open URL"))
		{
			Application.OpenURL("http://narudesign.com/");
		}
	}
	*/
	
	
	
	public void OnClick()
	{
		Application.OpenURL("http://lla.co.jp:3000/html/pc/html/pc_login.html");
		Debug.Log("Pressed!");
	}
}