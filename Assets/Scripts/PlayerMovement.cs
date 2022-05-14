using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction fireAction;
    
    private float moveSpeed = 6f;

    public void Init()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        transform.localPosition = new Vector3(0, 0.5f, 0);
        
        moveAction = playerInput.currentActionMap.FindAction("Move");
    }
    public void ManualUpdate(float timeStep)
    {
        if (controller == null) return;

        var rawInput = moveAction.ReadValue<Vector2>();
        var direction = IsometricVector(new Vector3(rawInput.x, 0, rawInput.y));

        controller.Move(direction * (moveSpeed * timeStep));
    }

    private Vector3 IsometricVector(Vector3 vector)
    {
        var isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45f, 0));
        var res = isoMatrix.MultiplyPoint3x4(vector);

        return res;
    }
}