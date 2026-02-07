using UnityEngine;

public class PlayerMove01 : MonoBehaviour
{
    [Header ("Referencias")]
    [SerializeField] private InputReader input;

    [Header("Movimiento")]
    [SerializeField] private float speed = 10f;

    private Vector2 moveInput;
    private void OnEnable()
    {
        input.Move += OnMove;
    }
    private void OnDisable()
    {
        input.Move -= OnMove;
    }

    private void OnMove(Vector2 value)
    {
        moveInput = value;
    }

    private void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
