using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    [Header("Game Stats")]
    public int roundCounter = 0;
    public float timeRemaining = 120f; //countdown starts at this number (seconds)
    public bool isGameActive = true;


    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    void Update()
    {
        if (isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isGameActive = false;
                Debug.Log("Game Over!");
            }
        }
    }

    public void IncrementRound() => roundCounter++;
    public void ResetGame() => roundCounter = 0;
}
