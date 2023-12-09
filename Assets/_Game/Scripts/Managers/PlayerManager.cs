using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private MovementController movementController;

    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        movementController.HandleAllMovement();
    }

}
