using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DanceFloorPanel : MonoBehaviour
{
    // List of colors specified in Hex format
    private List<Color> colors = new List<Color>
    {
        new Color32(0x26, 0x6C, 0xDD, 0xFF), // #266CDD
        new Color32(0x2B, 0x20, 0xBC, 0xFF), // #2B20BC
        new Color32(0xFF, 0xCC, 0x33, 0xFF), // #FFCC33
        new Color32(0xA0, 0x1C, 0xA3, 0xFF), // #A01CA3
        new Color32(0xFA, 0x10, 0x85, 0xFF)  // #FA1085
    };

    public float changeInterval = 0.1f;
    public float transitionDuration = 0.05f;

    private Renderer panelRenderer;
    private Color currentColor;
    private Color targetColor;

    void Start()
    {
        panelRenderer = GetComponent<Renderer>();
        currentColor = panelRenderer.material.color;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            targetColor = colors[Random.Range(0, colors.Count)];

            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime / transitionDuration;
                panelRenderer.material.color = Color.Lerp(currentColor, targetColor, t);
                yield return null;
            }

            currentColor = targetColor;

            yield return new WaitForSeconds(changeInterval);
        }
    }
}
