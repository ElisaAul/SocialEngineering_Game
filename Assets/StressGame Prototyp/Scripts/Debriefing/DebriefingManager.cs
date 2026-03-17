using UnityEngine;

public class DebriefingManager : MonoBehaviour
{
    public DebriefingUI ui;

    void Start()
    {
        if (StressManager.Instance == null)
        {
            Debug.LogWarning("Kein StressManager gefunden.");
            return;
        }
        ui.Populate(StressManager.Instance);
    }
}