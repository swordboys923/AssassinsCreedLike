using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) {

    }

    public override void Enter() {
        stateMachine.GetInputReader().OnTargetEvent += InputReader_OnTarget;
    }



    public override void Tick(float deltaTime) {
    }

    public override void Exit() {
        stateMachine.GetInputReader().OnTargetEvent -= InputReader_OnTarget;
    }

    private void InputReader_OnTarget() {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }
}
