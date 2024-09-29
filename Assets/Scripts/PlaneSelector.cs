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
            DeselectPlane(planeName);
        }
        else
        {
            if (selectedPlanes.Count >= 2)
            {
                DeselectPlane(selectedPlanes[0]);
            }

            SelectPlane(planeName);
        }
    }

    void SelectPlane(string planeName)
    {
        selectedPlanes.Add(planeName);
        GameData.SelectedPlayers.Add(planeName);
        planeLightMap[planeName].color = Color.yellow;
    }

    void DeselectPlane(string planeName)
    {
        selectedPlanes.Remove(planeName);
        GameData.SelectedPlayers.Remove(planeName);
        planeLightMap[planeName].color = Color.white;
    }
}
