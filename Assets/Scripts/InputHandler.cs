using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH 
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_input;
        public bool attack_Input;
        public bool h_attack_Input;
        public bool defend_Input;

        public bool sprintFlag;
        

        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerInventory playerInventory;

        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake()
        {
            playerAttacker = GetComponent<PlayerAttacker>();
            playerInventory = GetComponent<PlayerInventory>();
        }

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleSprintInput(delta);
            HandleAttackInput(delta);
            HandleDefendInput(delta);
        }
        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleSprintInput(float delta)
        {
            b_input = inputActions.PlayerActions.Sprint.phase == UnityEngine.InputSystem.InputActionPhase.Started;

            if (b_input)
            {
                sprintFlag = true;
            }
        }

        public void HandleAttackInput(float delta)
        {
            inputActions.PlayerActions.Attack.performed += i => attack_Input = true;
            inputActions.PlayerActions.HeavyAttack.performed += i => h_attack_Input = true;
            
            if (attack_Input)
            {
                playerAttacker.HandleLightAttack(playerInventory.rightWeapon);                
            }
            if (h_attack_Input)
            {
                playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);                
            }
        }

        public void HandleDefendInput(float delta)
        {
            inputActions.PlayerActions.Defend.performed += i => defend_Input = true;

            if (defend_Input)
            {
                playerAttacker.HandleDefending(playerInventory.leftShield);
            }
        }
    }

}

