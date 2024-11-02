using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private bool isFacingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool jumpPressed;

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(movement.x));

        // Handle jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpPressed = true;
        }

        // Flip character direction
        if (movement.x > 0 && isFacingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Move the player using velocity
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (jumpPressed)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpPressed = false; // Reset jumpPressed after jumping
        }

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Flip()
    {
        // Flip the player when direction changes
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        // Visualize ground check radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
