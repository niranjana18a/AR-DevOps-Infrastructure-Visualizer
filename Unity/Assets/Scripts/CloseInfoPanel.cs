using UnityEngine;

public class CloseInfoPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;

    public void ClosePanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}