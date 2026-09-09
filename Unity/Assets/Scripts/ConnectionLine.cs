using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class ConnectionLine : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private Transform endPoint;

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        if (startPoint == null || endPoint == null)
            return;

        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}