using UnityEngine;

public class death : MonoBehaviour
{
    public Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");

        // Moves the player back to the start
        Teleport();

        // Tell the Manager to reset the round counter to 0
        gameManager.Instance.ResetGame();
    }

    void Teleport()
    {
        // We move 'transform' (this player) to the spawn point's position
        transform.position = spawnPoint.position;

        // Reset player's velocity so they don't keep flying after teleporting.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
