using UnityEngine;
using UnityEngine.InputSystem;

public class TDMovement : MonoBehaviour
{
    public float walkSpeed = 5f;

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        rb2d.linearVelocity = ctx.ReadValue<Vector2>() * walkSpeed;
    }
}

