using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem05 : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;

    public static event Action<Vector2> MoveChanged;
    public static event Action JumpPressed;
    public static event Action AttackPressed;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;

    private void Awake()
    {
        var player = actions.FindActionMap("Player", true);
        moveAction = player.FindAction("Move", true);
        jumpAction = player.FindAction("Jump", true);
        attackAction = player.FindAction("Attack", true);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Update()
    {
        MoveChanged?.Invoke(moveAction.ReadValue<Vector2>());

        if(jumpAction.WasPressedThisFrame())
        {
            JumpPressed?.Invoke();
        }

        if (attackAction.WasPressedThisFrame())
        {
            AttackPressed?.Invoke();
        }
    }


}
