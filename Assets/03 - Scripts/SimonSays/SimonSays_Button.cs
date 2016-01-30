using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using FSMHelper;


public class SimonSays_Button : MonoBehaviour {
	public int index;
	public SimonSaysBehaviour mSSB;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		mSSB.ClickOnButton (index);

			

	}
}
