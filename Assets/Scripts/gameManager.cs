using UnityEngine;

public class gameManager : MonoBehaviour
{
    // The singleton instance that other scripts can talk to
    public static gameManager Instance { get; private set; }

    public int roundCounter = 0;

    private void Awake()
    {
        // Ensure there is only ever one GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // Optional: Makes the counter persist even if you switch scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Round Counter that is called by portalBehavior
    public void IncrementRound()
    {
        roundCounter++;
        Debug.Log("Current Round: " + roundCounter);
    }

    // Resets when character dies
    public void ResetGame()
    {
        roundCounter = 0;
        Debug.Log("Game Reset! Round Counter is now 0.");
        //TODO: Timer
    }
}
