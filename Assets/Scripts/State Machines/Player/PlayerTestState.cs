using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerTestState : PlayerBaseState {

    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {

    }

    public override void Enter() {
    }

    public override void Tick(float deltaTime) {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.GetInputReader().GetMovementValue().x;
        movement.y = 0;
        movement.z = stateMachine.GetInputReader().GetMovementValue().y;

        stateMachine.GetCharacterController().Move(
            deltaTime * stateMachine.GetFreeLookMovementSpeed() * movement
        );

        if(stateMachine.GetInputReader().GetMovementValue() == Vector2.zero) return;

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }

    public override void Exit() {
    }

}
