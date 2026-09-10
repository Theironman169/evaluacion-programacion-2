using UnityEngine;
public class MovementHorizontal : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private Rigidbody2D rb;
    private float moveX;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private bool isGrounded;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        salto();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
    private void salto()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position, 0.1f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity =
                new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
