using UnityEngine;

public class InfrastructureObject : MonoBehaviour
{
    [Header("Infrastructure Information")]
    public string objectName = "Cloud";
    public string objectType = "Cloud Infrastructure";
    public string status = "Online";

    public void ShowInformation()
    {
        Debug.Log(
            "Infrastructure Object: " + objectName +
            "\nType: " + objectType +
            "\nStatus: " + status
        );
    }
}