using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
   [SerializeField] private PlayerAnimationController _playerAnimatorController;
    public Vector2 movementInput;

    public float verticalInput;
    public float horizontalInput;

    private float moveAmount;

    private void OnEnable()
    {
        if (playerControls==null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInputs() 
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        _playerAnimatorController.UpdateAnimatorValues(0, moveAmount);
    }
}
