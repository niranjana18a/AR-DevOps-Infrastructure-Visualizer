using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformationPanelUI : MonoBehaviour
{
    [Header("Text References")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text typeText;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text cpuText;
    [SerializeField] private TMP_Text memoryText;

    [Header("Monitoring Bars")]
    [SerializeField] private Slider cpuBar;
    [SerializeField] private Slider memoryBar;

    public void ShowInformation(InfrastructureObject infrastructure)
    {
        // Object name
        titleText.text = infrastructure.objectName.ToUpper();

        // Object type
        if (typeText != null)
        {
            typeText.text = "Type: " + infrastructure.objectType;
        }

        // Status
        statusText.text = "Status: " + infrastructure.status;

        // CPU usage
        cpuText.text = "CPU Usage: " +
                       infrastructure.cpuUsage.ToString("F0") + "%";

        // Memory usage
        memoryText.text = "Memory Usage: " +
                          infrastructure.memoryUsage.ToString("F0") + "%";

        // CPU progress bar
        if (cpuBar != null)
        {
            cpuBar.value = infrastructure.cpuUsage;
        }

        // Memory progress bar
        if (memoryBar != null)
        {
            memoryBar.value = infrastructure.memoryUsage;
        }

        // Status color
        string currentStatus = infrastructure.status.ToLower();

        if (currentStatus == "online" || currentStatus == "running")
        {
            statusText.color = Color.green;
        }
        else if (currentStatus == "offline" || currentStatus == "failed")
        {
            statusText.color = Color.red;
        }
        else
        {
            statusText.color = Color.yellow;
        }
    }
}