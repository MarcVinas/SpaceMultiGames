using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using FSMHelper;
public class SimonSaysState_WaitingToPlay : BaseFSMState
{
	
	public SimonSaysBehaviour ssBeahaviour;
	private SimonSaysBehaviourStateMachine SM;
	public override void Enter()
	{
		SM = (SimonSaysBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.info.text = "Waiting to play, press S to start";
		SM.m_ssb.m_fTime = 0f;
	}
	
	public override void Exit()
	{
	}
	
	public override void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			DoTransition(typeof(SimonSaysState_IncreasingSequence));
			SM.m_ssb.sequence.Clear ();
		}
		
	}
}
/*
if (m_SM.IsFirstTime())
			{
				info.text = "Waiting to play, press S to start";
			}  
			
			if (Input.GetKeyDown(KeyCode.S))
			{
				m_SM.ChangeState(SimonSays_State.IncreasingSequence);
				sequence.Clear ();
			}
 */