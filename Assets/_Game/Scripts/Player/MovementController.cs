
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody playerRb;


    Vector3 moveDirection;
    Transform cameraObject;
    public float movementSpeed = 7;
    public float rotationSpeed = 7;
    private void Awake()
    {
        cameraObject = Camera.main.transform;
    }
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRb.velocity = movementVelocity;

    }
    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero) targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    public void StopPlayer()
    {
        movementSpeed = 0;
        rotationSpeed = 0;
    }

}
