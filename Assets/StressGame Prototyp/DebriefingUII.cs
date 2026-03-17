using UnityEngine;
using TMPro;

/*public class DebriefingUI : MonoBehaviour
{
    public TextMeshProUGUI finalStressText;
    public TextMeshProUGUI summaryText;
    public Transform historyContainer;
    public GameObject historyRowPrefab;

    void Start()
    {
        var sm = StressManager.Instance;
        if (sm == null) return;

        float stress = sm.stressLevel;
        finalStressText.text = $"Finales Stresslevel: {Mathf.Round(stress)} / 100";

        int goodCount = sm.choiceHistory.FindAll(c => c.quality == "good").Count;
        int total = sm.choiceHistory.Count;
        summaryText.text = $"{goodCount} von {total} Entscheidungen waren hilfreich.";

        foreach (var record in sm.choiceHistory)
        {
            var row = Instantiate(historyRowPrefab, historyContainer);
            row.GetComponent<HistoryRow>().Setup(record.scene, record.delta, record.quality);
        }
    }
}
*/