using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StressBarUI : MonoBehaviour
{
    [Header("UI Elemente")]
    public Slider slider;
    public Image fillImage;
    public TextMeshProUGUI valueLabel;
    public TextMeshProUGUI statusLabel;

    readonly Color colLow = new(0.11f, 0.62f, 0.46f);
    readonly Color colMed = new(0.94f, 0.62f, 0.15f);
    readonly Color colHigh = new(0.85f, 0.35f, 0.19f);
    readonly Color colCrit = new(0.89f, 0.29f, 0.29f);

    void Start() => UpdateBar(StressManager.Instance != null
        ? StressManager.Instance.stressLevel : 40f);

    public void UpdateBar(float value)
    {
        StopAllCoroutines();
        StartCoroutine(Animate(value));
    }

    IEnumerator Animate(float target)
    {
        float start = slider.value * 100f;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2.5f;
            float cur = Mathf.Lerp(start, target, Mathf.SmoothStep(0f, 1f, t));
            slider.value = cur / 100f;
            fillImage.color = GetColor(cur);
            valueLabel.text = $"{Mathf.Round(cur)} / 100";
            statusLabel.text = GetLabel(cur);
            yield return null;
        }
    }

    Color GetColor(float v) =>
        v < 35 ? colLow : v < 60 ? colMed : v < 80 ? colHigh : colCrit;

    string GetLabel(float v) =>
        v < 25 ? "sehr entspannt" :
        v < 45 ? "ausgeglichen" :
        v < 65 ? "mäßig gestresst" :
        v < 80 ? "stark gestresst" : "überlastet";
}