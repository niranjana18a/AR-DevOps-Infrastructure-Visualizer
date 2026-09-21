using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class MonitoringDashboard : MonoBehaviour
{
    [Header("FastAPI")]
    [SerializeField]
    private string apiUrl = "http://localhost:8001/api/monitoring/prometheus";

    [Header("Dashboard Text")]
    [SerializeField] private TMP_Text cpuText;
    [SerializeField] private TMP_Text memoryText;
    [SerializeField] private TMP_Text networkText;
    [SerializeField] private TMP_Text diskText;

    [Header("Dashboard Bars")]
    [SerializeField] private Slider cpuBar;
    [SerializeField] private Slider memoryBar;
    [SerializeField] private Slider networkBar;
    [SerializeField] private Slider diskBar;

    [Header("System Status")]
    [SerializeField] private TMP_Text systemStatusText;
    [SerializeField] private TMP_Text alertText;
    [SerializeField] private UnityEngine.UI.Image statusIndicator;

    [Header("Alert Panel")]
    [SerializeField] private GameObject alertPanel;
    [SerializeField] private TMP_Text alertTitle;
    [SerializeField] private TMP_Text alertDetails;

    [Header("Refresh")]
    [SerializeField] private float refreshInterval = 5f;

    private void Start()
    {
        StartCoroutine(UpdateMonitoringData());
    }

    private IEnumerator UpdateMonitoringData()
    {
        while (true)
        {
            yield return StartCoroutine(GetMonitoringData());

            yield return new WaitForSeconds(refreshInterval);
        }
    }

    private IEnumerator GetMonitoringData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(
                    "Monitoring API Error: " + request.error
                );

                yield break;
            }

            string json = request.downloadHandler.text;

            MonitoringData data =
                JsonUtility.FromJson<MonitoringData>(json);

            UpdateDashboard(data);
        }
    }

    private void UpdateDashboard(MonitoringData data)
    {
        float cpu = data.cpu;
        float memory = data.memory;
        float network = data.network;
        float disk = data.disk;

        // Update monitoring text
        cpuText.text = "CPU Usage: " + cpu.ToString("F0") + "%";
        memoryText.text = "Memory Usage: " + memory.ToString("F0") + "%";
        networkText.text = "Network Usage: " + network.ToString("F0") + "%";
        diskText.text = "Disk Usage: " + disk.ToString("F0") + "%";

        // Update monitoring bars
        cpuBar.value = cpu;
        memoryBar.value = memory;
        networkBar.value = network;
        diskBar.value = disk;

        // Update system status and alerts
        UpdateSystemStatus(cpu, memory, network, disk);

        // Console output
        Debug.Log(
            "Monitoring Updated | " +
            "CPU: " + cpu +
            "% | Memory: " + memory +
            "% | Network: " + network +
            "% | Disk: " + disk + "%"
        );
    }

    private void UpdateSystemStatus(
        float cpu,
        float memory,
        float network,
        float disk)
{
        float highestUsage = Mathf.Max(
        cpu,
        memory,
        network,
        disk
        );

    // CRITICAL
        if (highestUsage >= 85f)
       {
            systemStatusText.text = "SYSTEM STATUS: CRITICAL";
            systemStatusText.color = Color.red;

            alertText.text = "Critical resource usage detected";
            alertText.color = Color.red;

            statusIndicator.color = Color.red;

            alertPanel.SetActive(true);

            alertTitle.text = "CRITICAL ALERT";
            alertTitle.color = Color.red;

            alertDetails.text =
             "Critical resource usage detected";
            alertDetails.color = Color.red;
        }

    // WARNING
        else if (highestUsage >= 70f)
       {
         systemStatusText.text = "SYSTEM STATUS: WARNING";
         systemStatusText.color = Color.yellow;

         alertText.text = "High resource usage detected";
         alertText.color = Color.yellow;

         statusIndicator.color = Color.yellow;

         alertPanel.SetActive(true);

         alertTitle.text = "WARNING";
         alertTitle.color = Color.yellow;

         alertDetails.text =
            "High resource usage detected";
         alertDetails.color = Color.yellow;
        }

    // HEALTHY
        else
       {
         systemStatusText.text = "SYSTEM STATUS: HEALTHY";
         systemStatusText.color = Color.green;

         alertText.text = "No active alerts";
         alertText.color = Color.green;

         statusIndicator.color = Color.green;

         alertPanel.SetActive(false);
        }
        
}
    public void CloseDashboard()
   {
     gameObject.SetActive(false);
    }
    public void ShowDashboard()
   {
     gameObject.SetActive(true);
    }
}

[System.Serializable]
public class MonitoringData
{
    public string source;

    public float cpu;
    public float memory;
    public float network;
    public float disk;
}