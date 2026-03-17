using UnityEngine;
using Yarn.Unity;
using System.Collections.Generic;

public class StressManager : MonoBehaviour
{
    public static StressManager Instance { get; private set; }

    [Header("Stress")]
    public float stressLevel = 40f;
    public float minStress = 0f;
    public float maxStress = 100f;

    [Header("Referenzen")]
    public DialogueRunner dialogueRunner;
    public StressBarUI stressBarUI;
    public FeedbackPanel feedbackPanel;

    public List<ChoiceRecord> choiceHistory = new();

    // NEU: aktuellen Node-Namen selbst tracken
    string currentNodeName = "Unbekannt";

    [System.Serializable]
    public struct ChoiceRecord
    {
        public string scene;
        public float delta;
        public string quality;
    }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // onNodeStart abonnieren — wird jedes Mal gefeuert wenn ein Node beginnt
        if (dialogueRunner != null)
            dialogueRunner.onNodeStart.AddListener(OnNodeStart);
    }

    void OnDestroy()
    {
        // Event wieder abmelden — wichtig um Memory Leaks zu vermeiden
        if (dialogueRunner != null)
            dialogueRunner.onNodeStart.RemoveListener(OnNodeStart);
    }

    // Wird von Yarn automatisch aufgerufen wenn ein neuer Node startet
    void OnNodeStart(string nodeName)
    {
        currentNodeName = nodeName;
    }

    [YarnCommand("add_stress")]
    public void AddStress(float amount)
    {
        stressLevel = Mathf.Clamp(stressLevel + amount, minStress, maxStress);
        stressBarUI?.UpdateBar(stressLevel);

        choiceHistory.Add(new ChoiceRecord
        {
            scene = currentNodeName,   // jetzt korrekt getrackt
            delta = amount,
            quality = amount > 0f ? "bad" : amount < 0f ? "good" : "neutral"
        });
    }

    [YarnCommand("show_feedback")]
    public void ShowFeedback(string text, string quality)
    {
        feedbackPanel?.Show(text, quality);
    }

    [YarnCommand("load_debriefing")]
    public void LoadDebriefing()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Debriefing");
    }
}