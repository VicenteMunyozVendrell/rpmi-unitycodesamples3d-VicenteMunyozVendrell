using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem04 : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionAsset actions;

    [Header("UI")]
    [SerializeField] private GameObject pausePanel; //UI menu de pausa

    private InputActionMap playerMap;
    private InputActionMap uiMap;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction pauseAction;
    private InputAction submitAction;
    private InputAction cancelAction;

    private bool isPaused;


    private void Awake()
    {
        //encontrar los action maps
        playerMap = actions.FindActionMap("Player", throwIfNotFound: true);
        uiMap = actions.FindActionMap("UI", throwIfNotFound: true);

        //encontrar las acciones
        moveAction = playerMap.FindAction("Move", throwIfNotFound: true);
        jumpAction = playerMap.FindAction("Jump", throwIfNotFound: true);
        attackAction = playerMap.FindAction("Attack", throwIfNotFound: true);
        pauseAction = playerMap.FindAction("Pause", throwIfNotFound: true);
        submitAction = uiMap.FindAction("Submit", throwIfNotFound: true);
        cancelAction = uiMap.FindAction("Cancel", throwIfNotFound:  false);

        SetPaused(false);

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
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (!isPaused)
        {
            transform.Translate(moveValue * 10 * Time.deltaTime);

            if (jumpAction.WasPressedThisFrame())
            {
                Debug.Log("Boing");
            }

            if (attackAction.WasPressedThisFrame())
            {
                Debug.Log("Pew");
            }

            if (pauseAction.WasPressedThisFrame())
            {
                SetPaused(true);
                return;
            }
        }

        if (isPaused)
        {
            if(submitAction.WasPressedThisFrame())
            {
                SetPaused(false);
            }
        }
 
    }

    private void SetPaused(bool paused)
    {
        isPaused = paused;

        if (pausePanel != null)
        {
            pausePanel.SetActive(paused);
        }

        Time.timeScale = paused ? 0f : 1f;

        if (paused)
        {
            playerMap.Disable();
            uiMap.Enable();
        }

        else
        {
            uiMap.Disable();
            playerMap.Enable();
        }
    }

}
