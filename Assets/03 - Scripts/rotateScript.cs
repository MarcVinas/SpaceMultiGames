﻿using UnityEngine;
using System.Collections;

public class rotateScript: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rot = new Vector3 (0,5,0);
		transform.Rotate (rot);
	
	}
}
