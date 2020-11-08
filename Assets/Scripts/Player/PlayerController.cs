using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float playerSpeed = 200;
    [SerializeField] float playerJumpForce = 200;

    [Header("Ground Check")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField, Range(0, 6)] float overlapRadius;
    [SerializeField] Transform groundCheckPoint;

    
    private bool isGrounded => Physics2D.OverlapCircle(groundCheckPoint.position, overlapRadius, groundLayer);

    
    Rigidbody2D playerRb;

    Vector2 movement;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
    }

    private void OnDrawGizmos()
    {
        Color gizmoWireSphereColor = new Color(0.9f, 0.5f, 0.5f, 0.5f);
        Gizmos.color = gizmoWireSphereColor;
        Gizmos.DrawWireSphere(groundCheckPoint.position, overlapRadius);
    }
}
