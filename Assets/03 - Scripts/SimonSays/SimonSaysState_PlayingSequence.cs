using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using FSMHelper;
public class SimonSaysState_PlayingSequence : BaseFSMState
{

	//public SimonSaysBehaviour ssBeahaviour;
	private SimonSaysBehaviourStateMachine SM;
	public override void Enter()
	{
		Debug.Log("SimonSaysState_PlayingSequence - >Enter()");
		SM = (SimonSaysBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.info.text = "Playing sequence...";
		SM.m_ssb.currentSequenceIndex = 0;
		SM.m_ssb.PressButton(SM.m_ssb.sequence[SM.m_ssb.currentSequenceIndex]);
		SM.m_ssb.m_fTime = 0f;
		

	}
	
	public override void Exit()
	{

	}
	
	public override void Update()
	{
		Debug.Log("SimonSaysState_PlayingSequence - >Update()");

		if (SM.m_ssb.m_fTime > 2f)
		{

			SM.m_ssb.currentSequenceIndex++;
			if (SM.m_ssb.currentSequenceIndex >= SM.m_ssb.sequence.Count)
			{
				DoTransition(typeof(SimonSaysState_WaitingUserInput));
				//m_SM.ChangeState(SimonSays_State.WaitingUserInput);
			}
			else
			{
				SM.m_ssb.PressButton(SM.m_ssb.sequence[SM.m_ssb.currentSequenceIndex]);
				SM.m_ssb.m_fTime = 0f;
			}
		}

	}
}
/*
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
*/