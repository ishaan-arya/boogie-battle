using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Transform player;  // The player's Transform
    public Text scoreText;    // Reference to the UI Text
    public Vector3 offset;    // Offset from the player's position

    private void Update()
    {
        // Keep the score text above the player
        if (player != null && scoreText != null)
        {
            // Set the position of the text to be above the player with some offset
            scoreText.transform.position = Camera.main.WorldToScreenPoint(player.position + offset);
        }
    }

    // Call this method to update the score text
    public void UpdateScore(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore;
        }
    }
}
