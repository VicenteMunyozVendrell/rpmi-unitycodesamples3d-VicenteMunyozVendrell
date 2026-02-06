using UnityEngine;
using UnityEngine.InputSystem;

//Este script requiere de un Player Input Component
public class InputSystem03 : MonoBehaviour
{
    Vector2 moveValue;

    public void OnJump()
    {
        Debug.Log("Boing");
    }

    public void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
        Debug.Log(moveValue);
    }

    private void Update()
    {
        transform.Translate(moveValue * 10 * Time.deltaTime);
    }

}
