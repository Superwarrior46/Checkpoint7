using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField]private float speed = 5.0f;
    [SerializeField]private float jumpForce = 100.0f;
    public bool toRight = true;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
        Vector2 movement = new Vector2(movementInput.x, 0) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
        if (movementInput.x > 0)
        {
            toRight = true;
        }
        else if (movementInput.x < 0)
        {
            toRight = false;
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }
}
