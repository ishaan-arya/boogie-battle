using UnityEngine;
using System.Collections.Generic;

public class PlaneSelector : MonoBehaviour
{
    public Light jamesLight;
    public Light kunalLight;
    public Light alexLight;
    public Light ishaanLight;

    private Dictionary<string, Light> planeLightMap;
    private List<string> selectedPlanes = new List<string>();

    void Start()
    {
        // Initialize the mapping between planes and lights
        planeLightMap = new Dictionary<string, Light>
        {
            { "JamesPlane", jamesLight },
            { "KunalPlane", kunalLight },
            { "AlexPlane", alexLight },
            { "IshaanPlane", ishaanLight }
        };
    }

    void OnMouseDown()
    {
        Debug.Log("Plane clicked: " + gameObject.name);
        string planeName = gameObject.name;

        if (selectedPlanes.Contains(planeName))
        {
            // Deselect the plane if it's already selected
            DeselectPlane(planeName);
        }
        else
        {
            // If two planes are already selected, deselect the first one
            if (selectedPlanes.Count >= 2)
            {
                DeselectPlane(selectedPlanes[0]);
            }

            // Select the new plane
            SelectPlane(planeName);
        }
    }

    void SelectPlane(string planeName)
    {
        selectedPlanes.Add(planeName);
        planeLightMap[planeName].color = Color.yellow; // Set the light to yellow
    }

    void DeselectPlane(string planeName)
    {
        selectedPlanes.Remove(planeName);
        planeLightMap[planeName].color = Color.white; // Reset the light color
    }
}
