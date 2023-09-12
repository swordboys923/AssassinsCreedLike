using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions {

    public event Action OnJumpEvent;
    public event Action OnDodgeEvent;

    private Vector2 movementValue;
    private Controls controls;
    private void Start() {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy() {
        controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context) {
        if(!context.performed) return;
        OnJumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context) {
        if(!context.performed) return;
        OnDodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context){
        movementValue = context.ReadValue<Vector2>();
    }

    public Vector2 GetMovementValue() {
        return movementValue;
    }

    public void OnLook(InputAction.CallbackContext context){
        
    }
}
