using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMHelper;

public class SimonSaysBehaviourStateMachine : FSMStateMachine
{
	public GameObject m_GameObject = null;
	public SimonSaysBehaviour m_ssb = null;
	
	public SimonSaysBehaviourStateMachine(GameObject characterObj)
	{
		m_GameObject = characterObj;
		m_ssb = m_GameObject.GetComponent<SimonSaysBehaviour> ();
	}
	
	// here we define the structure of the state machine's first layer
	public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
	{
		// default is an OR-type state
		// the first child added will be the inital state
		children.Add(typeof(SimonSaysState_WaitingToPlay));
		
		children.Add(typeof(SimonSaysState_IncreasingSequence));
		children.Add(typeof(SimonSaysState_PlayingSequence));
		children.Add(typeof(SimonSaysState_UserInputFAIL));
		children.Add(typeof(SimonSaysState_UserInputOK));
		children.Add(typeof(SimonSaysState_WaitingUserInput));
	}
}
