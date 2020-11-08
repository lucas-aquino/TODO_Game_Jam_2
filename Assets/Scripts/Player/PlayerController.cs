using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    [Header("Player Input")]
    [SerializeField] PlayerInput playerControl;
    
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
        playerRb.velocity = new Vector2(movement.x * playerSpeed, playerRb.velocity.y);

        Debug.Log($"{isGrounded}");
    }


    public void OnMove(InputValue valor)
    {
        Vector2 dir = valor.Get<Vector2>();
        movement = new Vector2(dir.x, 0);
    }

    public void OnJump(InputValue valor)
    {
        float dir =  valor.Get<float>();

        if(isGrounded)
            playerRb.AddForce(Vector2.up * playerJumpForce);
    }

    private void OnDrawGizmos()
    {
        Color gizmoWireSphereColor = new Color(0.9f, 0.5f, 0.5f, 0.5f);
        Gizmos.color = gizmoWireSphereColor;
        Gizmos.DrawWireSphere(groundCheckPoint.position, overlapRadius);
    }
}
