using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
using System.Collections.Generic;
using FSMHelper;
public class SimonSaysState_IncreasingSequence : BaseFSMState
{

	public SimonSaysBehaviour ssBeahaviour;

	private SimonSaysBehaviourStateMachine SM;
	public override void Enter()
	{
		SM = (SimonSaysBehaviourStateMachine)GetStateMachine();
	}
	
	public override void Exit()
	{

	}
	
	public override void Update()
	{
		    
		int newButton = Random.Range(0,4);
		SM.m_ssb.sequence.Add (newButton);
		DoTransition(typeof(SimonSaysState_PlayingSequence));
	}
}