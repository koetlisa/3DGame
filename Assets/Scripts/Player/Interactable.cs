using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Called when the player interacts (presses E).
    public abstract void Interact(GameObject interactor);

    // Called when the player looks at or targets the interactable.
    public virtual void OnFocus(){

    }

    // Optional: called when player stops looking at it.
    public virtual void OnDefocus(){
    
    }
}
