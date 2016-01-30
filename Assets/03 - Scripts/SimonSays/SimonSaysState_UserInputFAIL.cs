using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using FSMHelper;
public class SimonSaysState_UserInputFAIL : BaseFSMState
{
	
	//public SimonSaysBehaviour ssBeahaviour;
	private SimonSaysBehaviourStateMachine SM;
	public override void Enter()
	{
		SM = (SimonSaysBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.info.text = "FAIL!!!!!  :(";
		SM.m_ssb.m_fTime = 0f;
	}
	
	public override void Exit()
	{
	}
	
	public override void Update()
	{
		
		if (SM.m_ssb.m_fTime > 2.0f) {
			DoTransition(typeof(SimonSaysState_WaitingToPlay));
		}

	}
}/*
if (m_SM.IsFirstTime())
{
	info.text = "FAIL!!!!!  :(";
}    

if (m_SM.m_fTime > 2.0f) {
	m_SM.ChangeState (SimonSays_State.WaitingToPlay);
}*/