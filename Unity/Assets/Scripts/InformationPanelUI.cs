using UnityEngine;
using TMPro;

public class InformationPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text cpuText;
    [SerializeField] private TMP_Text memoryText;

    public void ShowInformation(InfrastructureObject infrastructure)
    {
        titleText.text = infrastructure.objectName.ToUpper();

        statusText.text = "Status: " + infrastructure.status;

        cpuText.text = "CPU Usage: 45%";

        memoryText.text = "Memory Usage: 62%";
    }
}