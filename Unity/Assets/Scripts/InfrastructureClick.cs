using UnityEngine;
using UnityEngine.InputSystem;

public class InfrastructureClick : MonoBehaviour
{
    private InfrastructureObject infrastructureObject;
    private Camera mainCamera;

    [SerializeField]
    private GameObject infoPanel;

    void Start()
    {
        infrastructureObject = GetComponent<InfrastructureObject>();
        mainCamera = Camera.main;

        Debug.Log("InfrastructureClick ready on: " + gameObject.name);
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("CLICK DETECTED: " + gameObject.name);

                if (infrastructureObject != null)
                {
                    infrastructureObject.ShowInformation();
                }

                if (infoPanel != null)
                {
                    InformationPanelUI panelUI =
                        infoPanel.GetComponent<InformationPanelUI>();

                    if (panelUI != null && infrastructureObject != null)
                    {
                        panelUI.ShowInformation(infrastructureObject);
                    }

                    infoPanel.SetActive(true);
                }
            }
        }
    }
}