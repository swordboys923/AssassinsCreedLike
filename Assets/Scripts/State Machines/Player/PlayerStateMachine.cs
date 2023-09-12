using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine {

    [SerializeField] private InputReader inputReader;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;
    [SerializeField] private float freeLookMovementSpeed;
    [SerializeField] private float rotationDamping;
    
    private Transform mainCameraTransform;

    private void Start() {
        mainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerFreeLookState(this));
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
    
    public float GetRoatationDamping() {
        return rotationDamping; 
    }

    public Animator GetAnimator() {
        return animator;
    }

    public Transform GetMainCameraTransform() {
        return mainCameraTransform;
    }
}
