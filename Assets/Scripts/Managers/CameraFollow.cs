using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;

    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!target) return;
        transform.position = target.transform.position + new Vector3(0, yOffset, zOffset);
    }
}
