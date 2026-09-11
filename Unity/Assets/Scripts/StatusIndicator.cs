using UnityEngine;

public class StatusIndicator : MonoBehaviour
{
    [SerializeField]
    private InfrastructureObject infrastructureObject;

    [SerializeField]
    private Renderer indicatorRenderer;

    void Start()
    {
        UpdateIndicator();
    }

    public void UpdateIndicator()
    {
        if (infrastructureObject == null)
            return;

        if (indicatorRenderer == null)
            indicatorRenderer = GetComponent<Renderer>();

        string currentStatus =
            infrastructureObject.status.ToLower();

        if (currentStatus == "online" ||
            currentStatus == "running")
        {
            indicatorRenderer.material.color = Color.green;
        }
        else if (currentStatus == "offline" ||
                 currentStatus == "failed")
        {
            indicatorRenderer.material.color = Color.red;
        }
        else
        {
            indicatorRenderer.material.color = Color.yellow;
        }
    }
}