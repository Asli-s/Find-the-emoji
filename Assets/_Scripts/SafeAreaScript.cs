using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeAreaScript : MonoBehaviour
{
    private CanvasScaler canvasScaler;
    private float bottomUnits, topUnits;
    void Start()
    {
        canvasScaler = FindObjectOfType<CanvasScaler>();
        ApplyVerticalSafeArea();
    }


    public void ApplyVerticalSafeArea()
    {
        var bottomPixels = Screen.safeArea.y;
        var topPixel = Screen.currentResolution.height - (Screen.safeArea.y + Screen.safeArea.height);

        var bottomRatio = bottomPixels / Screen.currentResolution.height;
        var topRatio = topPixel / Screen.currentResolution.height;

        var referenceResolution = canvasScaler.referenceResolution;
        bottomUnits = referenceResolution.y * bottomRatio;
        topUnits = referenceResolution.y * topRatio;

        var rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, bottomUnits);
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -topUnits);
    }
}
