using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneClickToScene : MonoBehaviour
{
    // The name of the scene you want to load
    public string sceneName = "MainDanceFloor";

    void OnMouseDown()
    {
        // Load the specified scene when the plane is clicked
        SceneManager.LoadScene(sceneName);
    }
}
