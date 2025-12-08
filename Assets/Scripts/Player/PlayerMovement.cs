using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rb;

    [Header("Player Moving Details")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Input Details")]
    [SerializeField] private float moveInput;
    [SerializeField] private float turnInput;
    [SerializeField] private float jumpVelocity;

    [Header("Ground Details")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask whatIsGround;
    private void Awake()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        if(col == null )
            col = GetComponent<Collider>();

    }
    private void Update()
    {
        HandleInput();
        HandleMovement();
        CheckForGround();
    }
    private void HandleMovement()
    {
        Movement();
    }
    private void Movement()
    {
        HandleJump();

        Vector3 move = new Vector3(turnInput, jumpVelocity, moveInput);
        move.Normalize();

        move *= moveSpeed * Time.deltaTime;
        rb.transform.Translate(move);
    }
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpVelocity = jumpForce;
        }
        else if(jumpVelocity>0)
            jumpVelocity -= 10f*Time.deltaTime;
        else             jumpVelocity = 0;
    }
    private void CheckForGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance,whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
