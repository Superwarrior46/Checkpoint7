using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField]private float speed = 5.0f;
    [SerializeField]private float jumpForce = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        //moveAction = playerInput.Actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
        Vector2 movement = new Vector2(movementInput.x, 0) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }
}
