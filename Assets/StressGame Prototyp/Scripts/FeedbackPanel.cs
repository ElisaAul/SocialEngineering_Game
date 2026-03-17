using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FeedbackPanel : MonoBehaviour
{
    [Header("UI Elemente")]
    public GameObject panel;
    public TextMeshProUGUI feedbackText;
    public Image background;

    [Header("Farben")]
    public Color goodColor = new(0.58f, 0.80f, 0.35f, 0.95f);
    public Color badColor = new(0.94f, 0.36f, 0.36f, 0.95f);
    public Color neutralColor = new(0.80f, 0.80f, 0.78f, 0.95f);

    public void Show(string text, string quality)
    {
        feedbackText.text = text;
        background.color = quality switch
        {
            "good" => goodColor,
            "bad" => badColor,
            _ => neutralColor
        };
        panel.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideAfter(3.5f));
    }

    IEnumerator HideAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        panel.SetActive(false);
    }
}