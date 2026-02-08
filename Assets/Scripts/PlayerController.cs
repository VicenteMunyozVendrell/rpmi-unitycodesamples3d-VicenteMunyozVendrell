using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader02 inputReader;

 
    private void OnEnable()
    {
        inputReader.Jump += Jump;
    }
    private void OnDisable()
    {
        inputReader.Jump -= Jump;
    }

    private void Update()
    {
        Move(inputReader.MoveValue);
    }

    private void Move(Vector2 moveValue)
    {
        Vector2 direction = new Vector3(moveValue.x, 0, 0);
        transform.Translate(direction * 10 * Time.deltaTime);
    }

    private void Jump()
    {
        Debug.Log("Boing");
    }
}
