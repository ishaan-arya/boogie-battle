using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void Start()
    {
        foreach (string player in GameData.SelectedPlayers)
        {
            Debug.Log("Selected Player: " + player);
        }
    }
}
