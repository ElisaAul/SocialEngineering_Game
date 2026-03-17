using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DebriefingUI : MonoBehaviour
{
    [Header("Metriken")]
    public TextMeshProUGUI finalStressText;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI goodCountText;
    public TextMeshProUGUI badCountText;
    public TextMeshProUGUI overallText;

    [Header("Verlauf")]
    public Transform historyContainer;
    public GameObject historyRowPrefab;

    [Header("Restart")]
    public Button restartButton;

    public void Populate(StressManager sm)
    {
        float stress = sm.stressLevel;
        int good = sm.choiceHistory.FindAll(c => c.quality == "good").Count;
        int bad = sm.choiceHistory.FindAll(c => c.quality == "bad").Count;
        int total = sm.choiceHistory.Count;

        finalStressText.text = $"{Mathf.Round(stress)} / 100";
        statusText.text = GetStatusLabel(stress);
        goodCountText.text = $"{good} / {total}";
        badCountText.text = $"{bad} / {total}";
        overallText.text = GetOverallText(stress);

        foreach (var record in sm.choiceHistory)
        {
            var row = Instantiate(historyRowPrefab, historyContainer);
            row.GetComponent<HistoryRow>().Setup(record.scene, record.delta, record.quality);
        }

        restartButton.onClick.AddListener(Restart);
    }

    void Restart()
    {
        Destroy(StressManager.Instance.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    string GetStatusLabel(float v) =>
        v < 25 ? "sehr entspannt" :
        v < 45 ? "ausgeglichen" :
        v < 65 ? "mäßig gestresst" :
        v < 80 ? "stark gestresst" : "überlastet";

    string GetOverallText(float v) =>
        v < 35 ? "Du hast die Woche sehr gut gemeistert. Starke Stressmanagement-Kompetenz!" :
        v < 60 ? "Solide Woche mit einzelnen Lernmomenten. Weiter üben!" :
                 "Du bist stark unter Druck geraten. Die gute Nachricht: Stressmanagement ist lernbar!";
}