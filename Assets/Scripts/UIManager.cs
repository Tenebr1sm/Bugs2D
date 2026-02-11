using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI timerText;

    void Update()
    {
        // Update Round Display
        roundText.text = "Rounds: " + gameManager.Instance.roundCounter;

        // Update Timer Display (Formatted to 0 decimals)
        float time = gameManager.Instance.timeRemaining;
        timerText.text = "Time: " + Mathf.Ceil(time).ToString() + "s";

        // Optional: Turn timer red when low
        if (time < 10f) timerText.color = Color.red;
        else timerText.color = Color.white;
    }
}
