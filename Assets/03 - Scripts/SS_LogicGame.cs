using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SS_LogicGame : MonoBehaviour {
	

	public GameObject[] lights;
	public Text info;
	public AudioClip[] sounds;
	public int buttonPressed;
	public int currentSequenceIndex = 0;

	public List<int> sequence;
	//-------------------------------------
	//-----State Machine info:-------------
	public enum SimonSays_State {
		WaitingToPlay = 0,
		IncreasingSequence,
		PlayingSequence,
		WaitingUserInput,
		UserInputOK,
		UserInputFAIL
	}
	
	public struct StateMachine
	{
		public SimonSays_State m_eState;
		public float m_fTime;
		public bool m_bIsFirstTime;
		
		public void ChangeState (SimonSays_State _state)
		{
			m_eState = _state;
			m_bIsFirstTime = true;
			m_fTime = 0f;
		}
		
		public bool IsFirstTime ()
		{
			bool isFirstTime = m_bIsFirstTime;
			m_bIsFirstTime = false;
			return isFirstTime;
		}
		
		public void Update()
		{
			m_fTime += Time.deltaTime;
		}
	}
	//-----------------------------------
	//-----------------------------------
	
	
	public StateMachine m_SM;
	
	
	void Start()
	{
		//goto waitingtoplay;
		m_SM.ChangeState (SimonSays_State.WaitingToPlay);
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q)){
			PressButton(0);
		}
		
		if(Input.GetKeyDown(KeyCode.W)){
			PressButton(1);
		}
		
		if(Input.GetKeyDown(KeyCode.E)){
			PressButton(2);
		}
		
		if(Input.GetKeyDown(KeyCode.R)){
			PressButton(3);
		}
		UpdateStateMachine ();
	}
	
	void UpdateStateMachine ()
	{
		m_SM.Update ();
		switch(m_SM.m_eState)
		{
			
		case SimonSays_State.WaitingToPlay:
		{
			if (m_SM.IsFirstTime())
			{
				info.text = "Waiting to play, press S to start";
			}  
			
			if (Input.GetKeyDown(KeyCode.S))
			{
				m_SM.ChangeState(SimonSays_State.IncreasingSequence);
				sequence.Clear ();
			}
		}
			break;


			
		case SimonSays_State.IncreasingSequence:
		{
			if (m_SM.IsFirstTime())
			{}    
			int newButton = Random.Range(0,4);
			sequence.Add (newButton);
			m_SM.ChangeState (SimonSays_State.PlayingSequence);
		}
			break;

		case SimonSays_State.PlayingSequence:
		{
			if (m_SM.IsFirstTime())
			{
				info.text = "Playing sequence...";
				currentSequenceIndex = 0;
				PressButton(sequence[currentSequenceIndex]);
			}   
			
			if (m_SM.m_fTime > 2f)
			{
				currentSequenceIndex++;
				if (currentSequenceIndex >= sequence.Count)
				{
					m_SM.ChangeState(SimonSays_State.WaitingUserInput);
				}
				else
				{
					PressButton(sequence[currentSequenceIndex]);
					m_SM.m_fTime = 0f;
				}
			}
			
		}
			break;
			
		case SimonSays_State.WaitingUserInput:
		{   
			if (m_SM.IsFirstTime())
			{   
				//Apagar primer totes les llums:
				foreach(GameObject light in lights)
				{
					light.SetActive(false);
				}
				
				info.text = "It's your turn...";
				buttonPressed = -1;
				currentSequenceIndex = 0;
            }    

            if (buttonPressed != -1)
            {
                PressButton(buttonPressed);
                if (buttonPressed != sequence[currentSequenceIndex])
                {
                    m_SM.ChangeState(SimonSays_State.UserInputFAIL);
                }
                else if (currentSequenceIndex == sequence.Count-1)
                {
                    m_SM.ChangeState(SimonSays_State.UserInputOK);
                }
                else{
                    buttonPressed = -1;
                    currentSequenceIndex++;
                }
            } 
        }
        break;


		case SimonSays_State.UserInputOK:
		{
			if (m_SM.IsFirstTime())
			{
				info.text = "Perfect!!";
			}    
			if (m_SM.m_fTime > 2.0f) {
				m_SM.ChangeState (SimonSays_State.IncreasingSequence);
			}
			
		}
			break;
			
		case SimonSays_State.UserInputFAIL:
		{
			if (m_SM.IsFirstTime())
			{
				info.text = "FAIL!!!!!  :(";
			}    
			
			if (m_SM.m_fTime > 2.0f) {
				m_SM.ChangeState (SimonSays_State.WaitingToPlay);
			}
		}
			break;
		}
	}
	
	void PressButton(int index)
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
