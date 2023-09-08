using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine {

    [SerializeField] private InputReader inputReader;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float freeLookMovementSpeed;

    private void Start() {
        SwitchState(new PlayerTestState(this));
    }

    public InputReader GetInputReader() {
        return inputReader;
    }

    public CharacterController GetCharacterController(){
        return characterController;
    }

    public float GetFreeLookMovementSpeed() {
        return freeLookMovementSpeed;
    }
}
