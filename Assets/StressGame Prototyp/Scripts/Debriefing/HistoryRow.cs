using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoryRow : MonoBehaviour
{
    public TextMeshProUGUI sceneLabel;
    public TextMeshProUGUI deltaLabel;
    public Image qualityDot;

    readonly Color colGood = new(0.11f, 0.62f, 0.46f);
    readonly Color colBad = new(0.89f, 0.29f, 0.29f);
    readonly Color colNeutral = new(0.60f, 0.60f, 0.58f);

    public void Setup(string scene, float delta, string quality)
    {
        sceneLabel.text = scene;
        deltaLabel.text = delta > 0 ? $"+{delta}" : $"{delta}";
        qualityDot.color = quality switch
        {
            "good" => colGood,
            "bad" => colBad,
            _ => colNeutral
        };
    }
}

