using UnityEngine;

public class bugJump : MonoBehaviour
{
    public float jumpForce = 18f;
    public float jumpInterval = 2f;
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
