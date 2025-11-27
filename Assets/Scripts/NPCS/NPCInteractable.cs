using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [TextArea(2, 5)]
    [SerializeField] string npcText = "Howdy, Partner!";
    
    public override void Interact(GameObject Interactor)
    {
        // For prototype, just print to console or show it in UI
        Debug.Log("NPC says: " + npcText);
        UIManager.Instance?.ShowDialogue(npcText);
    }

    public override void OnFocus()
    {
        InteractHintController.Instance?.Show();
    }

    public override void OnDefocus()
    {
        InteractHintController.Instance?.Hide();
    }
}
