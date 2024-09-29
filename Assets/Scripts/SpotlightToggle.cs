using UnityEngine;

public class SpotlightToggle : MonoBehaviour
{
    public Light spotlight; // Assign your spotlight in the inspector
    public float interval = 0.05f; // Time in seconds between toggles

    private bool isOn = true;

    void Start()
    {
        if (spotlight == null)
        {
            spotlight = GetComponent<Light>();
        }

        InvokeRepeating("ToggleLight", interval, interval);
    }

    void ToggleLight()
    {
        isOn = !isOn;
        spotlight.enabled = isOn;
    }
}
