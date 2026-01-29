using UnityEngine;
using UnityEngine.InputSystem;

public class TDMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameObject player;
    private Vector3 playerY;
    private Rigidbody2D rb2d;
    private Vector2 _movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    public GameObject parent;


    private int facingDirection = 1;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, _movementInput, ref movementInputSmoothVelocity, 0.35f);
        rb2d.linearVelocity = smoothedMovementInput * speed;
    }

    public void Flip()
    {
        if (smoothedMovementInput.x > 0.1f)
        {
            facingDirection = 1;
        }
        else if(smoothedMovementInput.x < -0.1f)
        {
            facingDirection = -1;
        }
      
        if (facingDirection == 1)
        {
            parent.transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        }
        else if (facingDirection == -1)
        {
            parent.transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

}

