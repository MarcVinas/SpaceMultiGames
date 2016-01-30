using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using FSMHelper;
public class SimonSaysState_WaitingUserInput : BaseFSMState
{
	
	public SimonSaysBehaviour ssBeahaviour;
	private SimonSaysBehaviourStateMachine SM;
	public override void Enter()
	{
		SM = (SimonSaysBehaviourStateMachine)GetStateMachine();
		//Apagar primer totes les llums:
		foreach(GameObject light in SM.m_ssb.lights)
		{
			light.SetActive(false);
		}
		
		SM.m_ssb.info.text = "It's your turn...";
		SM.m_ssb.buttonPressed = -1;
		SM.m_ssb.currentSequenceIndex = 0;
		
	}
	
	public override void Exit()
	{
	}
	
	public override void Update()
	{	
		if (SM.m_ssb.buttonPressed != -1)
		{
			SM.m_ssb.PressButton(SM.m_ssb.buttonPressed);
			if (SM.m_ssb.buttonPressed != SM.m_ssb.sequence[SM.m_ssb.currentSequenceIndex])
			{
				DoTransition(typeof(SimonSaysState_UserInputFAIL));
				//SM.m_ssb.ChangeState(SimonSays_State.UserInputFAIL);
			}
			else if (SM.m_ssb.currentSequenceIndex == SM.m_ssb.sequence.Count-1)
			{
				DoTransition(typeof(SimonSaysState_UserInputOK));
				//SM.m_ssb.ChangeState(SimonSays_State.UserInputOK);
			}
			else{
				SM.m_ssb.buttonPressed = -1;
				SM.m_ssb.currentSequenceIndex++;
			}
		} 
	}
}
/*
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
 */