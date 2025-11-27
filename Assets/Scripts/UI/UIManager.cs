using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshPro dialogueText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        if (dialoguePanel) dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string text)
    {
        if (dialoguePanel && dialogueText)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = text;
            CancelInvoke(nameof(HideDialogue));
            Invoke(nameof(HideDialogue), 4f); // Auto-hide after 4s for prototype.
        }
    }

    void HideDialogue()
    {
        if (dialoguePanel) dialoguePanel.SetActive(false);
    }
}
