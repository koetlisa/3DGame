using UnityEngine;

public class InteractHintController : MonoBehaviour
{
    public static InteractHintController Instance;
    [SerializeField] private GameObject hint;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        /*hint = gameObject;
        hint.SetActive(false);*/

        if (hint != null)
            hint.SetActive(false);
    }

    public void Show()
    {
        if (hint != null)
            hint.SetActive(true);
    }
    
    public void Hide()
    {
        if (hint != null)
            hint.SetActive(false);
    }
}
