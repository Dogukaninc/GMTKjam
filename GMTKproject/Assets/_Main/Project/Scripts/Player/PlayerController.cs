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

    private float horizontalInput;

    private Rigidbody2D _rigidbody;
    private RaycastHit2D _hit2D;

    //Slope System
    /*
    private Vector2 colliderSize;
    private Vector2 slopeNormalPerp;
    private CapsuleCollider2D _collider2D;
    private float slopeDownAngle;
    private float slopeDownAngleOld;

    private bool isOnSlope;
    */

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // _collider2D = GetComponent<CapsuleCollider2D>();

        // colliderSize = _collider2D.size;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpForce);
        }

        // SlopeMovement();
    }

    private void FixedUpdate()
    {
        ControlMovement();
        // SlopeCheck();
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
        // if (IsGrounded() && !isOnSlope)
        // {
        //     _rigidbody.velocity = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, 0f);
        // }
        // else if (IsGrounded() && isOnSlope)
        // {
        //     _rigidbody.velocity = new Vector2(-horizontalInput * movementSpeed * Time.deltaTime, movementSpeed * slopeNormalPerp.y * -horizontalInput);
        // }
        // else if (!IsGrounded())
        // {
        //     _rigidbody.velocity = new Vector2(-horizontalInput * movementSpeed * Time.deltaTime, _rigidbody.velocity.y);
        // }
    }


    // private void SlopeCheck()
    // {
    //     Vector2 checkPos = transform.position - new Vector3(0, colliderSize.y / 2);
    //     SlopeCheckVertical(checkPos);
    // }

    /*
    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, groundLayer);
        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;
            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }
    }
    */

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(groundCheckRadius, groundCheckRadius), groundLayer);
    }

    // private void SlopeMovement()
    // {
    //     _hit2D = Physics2D.Raycast(raycastOrigin.position, Vector2.down, 100f, groundLayer);
    // }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheck.position, new Vector2(groundCheckRadius, groundCheckRadius));
    }
}