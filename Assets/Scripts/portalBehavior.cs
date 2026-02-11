using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    public Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that hit us is the Player
        if (collision.gameObject.CompareTag("player"))
        {
            Teleport(collision.gameObject);
        }
    }

    void Teleport(GameObject player)
    {
        // 1. Move the player
        player.transform.position = spawnPoint.position;

        // 2. Tell the Global Manager to increment the round
        gameManager.Instance.IncrementRound();
    }
}
