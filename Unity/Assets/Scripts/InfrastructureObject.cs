using UnityEngine;

public class InfrastructureObject : MonoBehaviour
{
    [Header("Infrastructure Information")]
    public string objectName = "Cloud";
    public string objectType = "Cloud Infrastructure";
    public string status = "Online";

    [Header("Resource Monitoring")]
    [Range(0, 100)]
    public float cpuUsage = 45f;

    [Range(0, 100)]
    public float memoryUsage = 62f;

    public void ShowInformation()
    {
        Debug.Log(
            "Infrastructure Object: " + objectName +
            "\nType: " + objectType +
            "\nStatus: " + status +
            "\nCPU Usage: " + cpuUsage + "%" +
            "\nMemory Usage: " + memoryUsage + "%"
        );
    }
}