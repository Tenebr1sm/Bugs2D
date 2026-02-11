using UnityEngine;

public class bugJump : MonoBehaviour
{
    public float jumpForce = 18f; //how high the buges jump
    public float jumpInterval = 2f; //time inbetween jumps
    public float jumpTimeOffset = 0f; //time offest before enemy starts jumping

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float jumpTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval + jumpTimeOffset;
    }

    void Update()
    {
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0f && isGrounded)
        {
            Jump();
            jumpTimer = jumpInterval;
        }
    }

    void Jump()
    {
        // bugs move faster after round 5
        if (gameManager.Instance.roundCounter >= 10)
        {
            rb.gravityScale = 6f; // Pulls them down faster
            jumpForce = 37f;      // Pushes them up harder to fight the gravity
            jumpInterval = 1.5f; //shortens the time in between jumps
        }

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
}
