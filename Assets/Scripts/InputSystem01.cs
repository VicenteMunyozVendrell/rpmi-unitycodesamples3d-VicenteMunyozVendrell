using UnityEngine;
using UnityEngine.InputSystem;


public class InputSystem01 : MonoBehaviour
{
    //Input Action Map references
    InputActionMap playerActionMap;
    InputActionMap uiActionMap;

    //Input Actions references
    InputAction moveAction;
    InputAction jumpAction;
    InputAction submitAction;

    private void Start()
    {
        //Store Input Action Map references
        playerActionMap = InputSystem.actions.FindActionMap("Player");
        uiActionMap = InputSystem.actions.FindActionMap("UI");

        //Store Input Actions references
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        submitAction = InputSystem.actions.FindAction("Submit");

        //Enable default Action Map
        playerActionMap.Enable();
        uiActionMap.Disable();
    }

    private void Update()
    {
        //Read current input and store in variables
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool jumpValue = jumpAction.IsPressed();
        bool submitValue = submitAction.IsPressed();

        //Switch between Action Maps based on input
        if (jumpValue == true)
        {
            Debug.Log("Jump pressed");
            playerActionMap.Disable();
            uiActionMap.Enable();
            Debug.Log("uiActionMap enabled");
        }

        if (submitValue == true)
        {
            Debug.Log("Submit pressed");
            uiActionMap.Disable();
            playerActionMap.Enable();
            Debug.Log("playerActionMap enabled");
        }
    }

}
