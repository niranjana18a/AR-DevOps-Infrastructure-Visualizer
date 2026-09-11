using UnityEngine;

public class ObjectSelectionHighlight : MonoBehaviour
{
    [SerializeField]
    private Renderer targetRenderer;

    private Color originalColor;

    [SerializeField]
    private Color highlightColor = Color.yellow;

    void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }

        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    public void Highlight()
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color = highlightColor;
        }
    }

    public void RemoveHighlight()
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color = originalColor;
        }
    }
}