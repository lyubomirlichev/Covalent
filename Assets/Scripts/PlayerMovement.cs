using System.Collections;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using EasyButtons;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private PlayerInput playerInput;
    private SphereGenerator generator;
    private InputAction moveAction;
    private float moveSpeed = 6f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        generator = GetComponent<SphereGenerator>();
        //GameObject core = generator.CreateSphereGameObject();
        
        moveAction = playerInput.currentActionMap.FindAction("Move");
    }

    [Button]
    private void GenerateSphere()
    {
        generator.CreateSphereGameObject();
    }
    private void Update()
    {
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
