using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader02 : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    InputActionMap playerMap;

    InputAction moveAction;
    InputAction jumpAction;
    InputAction attackAction;

    public Vector2 MoveValue {  get; private set; }
    
    public event Action Jump;
    public event Action Attack;

    private void Awake()
    {
        playerMap = inputActions.FindActionMap("Player", throwIfNotFound: true);

        moveAction = inputActions.FindAction("Move", throwIfNotFound: true);
        jumpAction = inputActions.FindAction("Jump", throwIfNotFound: true);
        attackAction = inputActions.FindAction("Attack", throwIfNotFound: true);
    }

    private void OnEnable()
    {
        playerMap.Enable();
    }

    private void OnDisable()
    {
        playerMap.Disable();
    }

   
    private void Update()
    {
        MoveValue = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            Jump?.Invoke();
        }

        if (attackAction.WasPressedThisFrame())
        {
            Attack?.Invoke();        
        }
    }
}
