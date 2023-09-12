using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState {

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) {

    }

    private readonly int FreelookSpeedHash = Animator.StringToHash("FreeLookSpeed");

    private const float AnimatorDampTime = 0.1f;

    public override void Enter() {
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.GetCharacterController().Move(
            deltaTime * stateMachine.GetFreeLookMovementSpeed() * movement
        );

        if (stateMachine.GetInputReader().GetMovementValue() == Vector2.zero)
        {
            stateMachine.GetAnimator().SetFloat(FreelookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.GetAnimator().SetFloat(FreelookSpeedHash, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movement, deltaTime);
    }

    public override void Exit() {
    }

    private Vector3 CalculateMovement() {
        Vector3 forward = stateMachine.GetMainCameraTransform().forward;
        Vector3 right = stateMachine.GetMainCameraTransform().right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.GetInputReader().GetMovementValue().y +
            right * stateMachine.GetInputReader().GetMovementValue().x;
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime) {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.GetRoatationDamping());
    }
}
