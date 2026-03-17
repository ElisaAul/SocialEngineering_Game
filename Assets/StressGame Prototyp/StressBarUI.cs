using UnityEngine;
using UnityEngine.UI;

public class StressBarUI : MonoBehaviour
{
    public static StressBarUI Instance;
    public Slider stressSlider;
    public Image fillImage;
    public TMPro.TextMeshProUGUI stressLabel;

    // Farben je nach Level
    public Color lowColor = new Color(0.11f, 0.62f, 0.46f); // grün
    public Color medColor = new Color(0.94f, 0.62f, 0.15f); // gelb
    public Color highColor = new Color(0.85f, 0.35f, 0.19f); // orange
    public Color critColor = new Color(0.89f, 0.29f, 0.29f); // rot

    void Awake() { Instance = this; }

    public void UpdateBar(float value)
    {
        // Sanft animieren
        StopAllCoroutines();
        StartCoroutine(AnimateBar(value));
    }

    System.Collections.IEnumerator AnimateBar(float target)
    {
        float start = stressSlider.value;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            float current = Mathf.Lerp(start, target, t);
            stressSlider.value = current / 100f;
            fillImage.color = GetStressColor(current);
            stressLabel.text = $"{Mathf.Round(current)} / 100 — {GetStressLabel(current)}";
            yield return null;
        }
    }

    Color GetStressColor(float v) =>
        v < 35 ? lowColor : v < 60 ? medColor : v < 80 ? highColor : critColor;

    string GetStressLabel(float v) =>
        v < 25 ? "sehr entspannt" : v < 45 ? "ausgeglichen" :
        v < 65 ? "mäßig gestresst" : v < 80 ? "stark gestresst" : "überlastet";
}