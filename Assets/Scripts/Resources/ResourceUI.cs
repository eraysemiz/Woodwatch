using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    public TMP_Text woodText;
    public TMP_Text stoneText;

    void Start()
    {
        UpdateUI(); // Baþlangýçta bir kere güncelle

        ResourceManager.Instance.OnResourceChanged += UpdateUI;
    }

    void OnDestroy()
    {
        if (ResourceManager.Instance != null)
            ResourceManager.Instance.OnResourceChanged -= UpdateUI;
    }

    void UpdateUI()
    {
        woodText.text = $"Odun: {ResourceManager.Instance.GetResource("Wood")}";
        stoneText.text = $"Taþ: {ResourceManager.Instance.GetResource("Stone")}";
    }
}
