using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction moveAction;
    
    private float moveSpeed = 6f;

    public void Init()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        
        moveAction = playerInput.currentActionMap.FindAction("Move");
    }
    private void Update()
    {
        if (controller == null) return;

        var rawInput = moveAction.ReadValue<Vector2>();
        var direction = IsometricVector(new Vector3(rawInput.x, 0, rawInput.y));

        controller.Move(direction * (moveSpeed * Time.deltaTime));
    }

    private Vector3 IsometricVector(Vector3 vector)
    {
        var isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45f, 0));
        var res = isoMatrix.MultiplyPoint3x4(vector);

        return res;
    }
}