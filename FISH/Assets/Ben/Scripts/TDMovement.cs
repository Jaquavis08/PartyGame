using UnityEngine;
using UnityEngine.InputSystem;

public class TDMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;
    private Vector2 _movementInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = _movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}

