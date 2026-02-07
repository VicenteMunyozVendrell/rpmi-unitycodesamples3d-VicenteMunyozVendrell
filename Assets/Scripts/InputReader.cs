using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent] //no permite varios componenetes del mismo tipo en un GameObject.
public class InputReader : MonoBehaviour
{
    [Header("PlayerInput (en el mismo GameObject o asignado)")]
    [SerializeField] private PlayerInput playerInput;

    private const string PLAYER_MAP = "Player";
    private const string UI_MAP = "UI";

    private const string MOVE_ACTION = "Move";
    private const string JUMP_ACTION = "Jump";
    private const string ATTACK_ACTION = "Attack";
    private const string PAUSE_ACTION = "Pause";

    //Eventos
    public event Action<Vector2> Move;
    public event Action Jump;
    public event Action Attack;
    public event Action Pause;

    //Estado
    public Vector2 MoveValue {  get; private set; }
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        if(playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }
    }

    private void OnEnable()
    {
        playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        //Nombre del Action Map Actual
        string map = context.action.actionMap != null
            ? context.action.actionMap.name
            : string.Empty;

        // ===== MOVE (Vector2) =====
        if (map == PLAYER_MAP && context.action.name == MOVE_ACTION)
        {
            if (context.performed || context.canceled)
            {
                MoveValue = context.ReadValue<Vector2>();
                Move?.Invoke(MoveValue);
            }

            return;
        }

        // ===== BOTONES =====
        if (map == PLAYER_MAP && context.performed)
        {
            if (context.action.name == JUMP_ACTION)
            {
                Jump?.Invoke();
                return;
            }

            if (context.action.name == ATTACK_ACTION)
            {
                Attack?.Invoke();
                return;
            }

            if (context.action.name == PAUSE_ACTION)
            {
                Pause?.Invoke();
                return;
            }
        }
    }

    // ===== Cambio de Action Maps =====
    public void SwitchToPlayer()
    {
        IsPaused = false;
        playerInput.SwitchCurrentActionMap(PLAYER_MAP);

        //Cortamos el movimiento
        MoveValue = Vector2.zero;
        Move?.Invoke(MoveValue);
    }

    public void SwitchToUI()
    {
        IsPaused = true;
        playerInput.SwitchCurrentActionMap(UI_MAP);

        //Cortamos el movimiento
        MoveValue = Vector2.zero;
        Move?.Invoke(MoveValue);
    }

    public void TogglePauseMaps()
    {
        if (IsPaused) SwitchToPlayer();
        else SwitchToUI();
    }

}
