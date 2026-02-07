using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector2 move;

    private void OnEnable()
    {
        InputSystem05.MoveChanged += OnMoveChanged;
        InputSystem05.JumpPressed += OnJumpPressed;
        InputSystem05.AttackPressed += OnAttackPressed;

    }

    private void OnDisable()
    {
        InputSystem05.MoveChanged -= OnMoveChanged;
        InputSystem05.JumpPressed -= OnJumpPressed;
        InputSystem05.AttackPressed -= OnAttackPressed;
    }

    private void OnMoveChanged(Vector2 v)
    {
        move = v;
    }

    private void Update()
    {
        Vector3 dir = new Vector3(move.x, 0f, move.y);
        transform.Translate(dir * speed *  Time.deltaTime); 
    }

    private void OnJumpPressed()
    {
        Debug.Log("Boing");
    }

    private void OnAttackPressed()
    {
        Debug.Log("Peew");
    }
}
