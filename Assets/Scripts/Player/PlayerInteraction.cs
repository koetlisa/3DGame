using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] float interactRadius = 1.5f;      // How far player can interact.
    [SerializeField] Vector3 interactOffset = new Vector3(0, 0, 1f); // Forward offset from player centre.
    [SerializeField] LayerMask interactLayer;          // Set to layer(s) with interactables.
    [SerializeField] KeyCode interactKey = KeyCode.E;

    private Interactable focusedInteractable;

    void Update()
    {
        DetectInteractable();

        if (focusedInteractable != null && Input.GetKeyDown(interactKey))
        {
            focusedInteractable.Interact(gameObject);
        }
    }

    void DetectInteractable()
    {
        // World position to check.
        Vector3 checkPos = transform.position + transform.TransformDirection(interactOffset);

        // Find colliders overlapping the small sphere.
        Collider[] hits = Physics.OverlapSphere(checkPos, interactRadius, interactLayer);

        Interactable nearest = null;
        float nearestDist = float.MaxValue;

        foreach (Collider hit in hits)
        {
            Interactable inter = hit.GetComponentInParent<Interactable>();
            if (inter == null) continue;

            float d = Vector3.Distance(transform.position, inter.transform.position);
            if (d < nearestDist)
            {
                nearestDist = d;
                nearest = inter;
            }
        }

        if (nearest != focusedInteractable)
        {
            if (focusedInteractable != null) focusedInteractable.OnDefocus();
            focusedInteractable = nearest;
            if (focusedInteractable != null) focusedInteractable.OnFocus();
        }
    }

    // Debug gizmo so you can see the interact check area in the Scene view.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 checkPos = transform.position + transform.TransformDirection(interactOffset);
        Gizmos.DrawWireSphere(checkPos, interactRadius);
    }
}
