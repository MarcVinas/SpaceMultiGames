﻿using UnityEngine;
using System.Collections;

public class logicGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			Application.LoadLevel(0);
		}
	}

    public void goToMenu()
    {
        Application.LoadLevel(0);
    }
}