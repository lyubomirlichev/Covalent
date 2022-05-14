using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{
    private InputAction fireAction;

    public void Init(Action<InputAction.CallbackContext> onFire)
    {
        var playerInput = GetComponent<PlayerInput>();

        fireAction = playerInput.currentActionMap.FindAction("Fire");
        fireAction.performed += onFire;
    }
}
