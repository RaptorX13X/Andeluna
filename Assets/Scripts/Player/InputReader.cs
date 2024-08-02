using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public event Action JumpEvent;

    public Vector2 MovementValue { get; private set; }

    private InputSystem_Actions controls;

    [SerializeField] private PlayerController player;

    private void Start()
    {
        controls = new InputSystem_Actions();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed || player.inAir) return;
        JumpEvent?.Invoke();
    }
}
