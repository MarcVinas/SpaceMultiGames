using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using FSMHelper;


public class SimonSaysBehaviour : MonoBehaviour {
	
	// keep an instance of our state machine
	private SimonSaysBehaviourStateMachine m_SimonSaysSM = null;
	
	//Public variables_Unity Editor:
	public GameObject[] lights;
	public AudioClip[] sounds;
	public Text info;
	
	
	[HideInInspector]
	public List<int> sequence = new List<int>();
	[HideInInspector]
	public int currentSequenceIndex = 0;
	[HideInInspector]
	public int buttonPressed;
	public float m_fTime; 
	
	
	void Start ()
	{
		// create the state machine and start it
		m_SimonSaysSM = new SimonSaysBehaviourStateMachine(this.gameObject);
		m_SimonSaysSM.StartSM();
		m_fTime = 0.0f;
	}
	
	void Update ()
	{
		// update the state machine very frame
		m_SimonSaysSM.UpdateSM();
		
		// this is how you can print the current active state tree to the log for debugging
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_SimonSaysSM.PrintActiveStateTree();
		}
		m_fTime += Time.deltaTime;
	}
	
	void OnDestroy()
	{
		// stop the state machine to ensure all the Exit() gets called
		if (m_SimonSaysSM != null)
		{
			m_SimonSaysSM.StopSM();
			m_SimonSaysSM = null;
		}
	}
	
	public void PressButton(int index)
	{
		if (index >= lights.Length) {
			Debug.LogError("PressButton: index("+index+") mes gran que el nombre de butons");
			return;
		}
		//Apagar primer totes les llums:
		foreach(GameObject light in lights)
		{
			light.SetActive(false);
		}
		lights [index].SetActive (true);
		GetComponent<AudioSource>().PlayOneShot (sounds [index]);
	}
	
	public void ClickOnButton (int index)
	{
		if (index >= lights.Length) {
			Debug.LogError("PressButton: index("+index+") mes gran que el nombre de butons");
			return;
		}
		buttonPressed = index;
	}
}