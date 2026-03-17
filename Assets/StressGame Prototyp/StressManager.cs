using UnityEngine;
using Yarn.Unity;
using System.Collections.Generic;

/*public class StressManager : MonoBehaviour
{
    public static StressManager Instance;

    [Header("Stress Settings")]
    public float stressLevel = 40f;
    public float minStress = 0f;
    public float maxStress = 100f;

    // Für das Debriefing
    public List<ChoiceRecord> choiceHistory = new();

    [System.Serializable]
    public struct ChoiceRecord
    {
        public string scene;
        public float delta;
        public string quality; // "good", "bad", "neutral"
    }

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    // Yarn Command: <<add_stress 25>>
    [YarnCommand("add_stress")]
    public void AddStress(float amount)
    {
        stressLevel = Mathf.Clamp(stressLevel + amount, minStress, maxStress);
        StressBarUI.Instance?.UpdateBar(stressLevel);

        // Für Debriefing merken
        choiceHistory.Add(new ChoiceRecord
        {
            scene = DialogueRunner.Instance?.CurrentNode ?? "Unbekannt",
            delta = amount,
            quality = amount > 0 ? "bad" : amount < 0 ? "good" : "neutral"
        });
    }

    // Yarn Command: <<show_feedback "Text" "good">>
    [YarnCommand("show_feedback")]
    public void ShowFeedback(string text, string quality)
    {
        FeedbackPanel.Instance?.Show(text, quality);
    }

    // Yarn Command: <<start_debriefing>>
    [YarnCommand("start_debriefing")]
    public void StartDebriefing()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Debriefing");
    }
}
*/