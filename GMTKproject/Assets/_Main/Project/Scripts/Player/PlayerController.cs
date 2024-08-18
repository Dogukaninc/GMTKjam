using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")] [SerializeField]
    private float movementSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private Transform playerFeetPosition;
    [SerializeField] private float slopeCheckDistance;

    [SerializeField] private float slowDownMultiplier;

    private float horizontalInput;

    private Rigidbody2D _rigidbody;
    private RaycastHit2D _hit2D;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpForce);
        }

        if (!IsGrounded())
        {
            _rigidbody.velocity -= new Vector2(0, 1 * slowDownMultiplier * Time.deltaTime);
        }

        Debug.Log(IsGrounded());
    }

    private void FixedUpdate()
    {
        ControlMovement();
    }

    private void ControlMovement()
    {
        _rigidbody.velocity = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, _rigidbody.velocity.y);
        if (horizontalInput > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, -180, transform.rotation.z);
        }
    }

    public bool IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapBox(groundCheck.position, new Vector2(groundCheckRadius, groundCheckRadius), 0f, groundLayer);
        return collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheck.position, new Vector2(groundCheckRadius, groundCheckRadius));
    }
}