﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SS_Button : MonoBehaviour {
	public int index;
	public SS_LogicGame lg;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		lg.ClickOnButton (index);

			

	}
}
