using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem02 : MonoBehaviour
{
    InputAction moveAction;

    [SerializeField] float speed;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        
        transform.Translate(moveValue * speed * Time.deltaTime);
    }


}
