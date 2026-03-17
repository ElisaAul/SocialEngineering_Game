using UnityEngine;
using TMPro;
using Yarn.Unity;

public class SceneLabel : MonoBehaviour
{
    public TextMeshProUGUI label;

    // <<set_scene_label "Montag, 8:30 Uhr — Büro">>
    [YarnCommand("set_scene_label")]
    public void SetLabel(string text)
    {
        if (label != null) label.text = text;
    }
}