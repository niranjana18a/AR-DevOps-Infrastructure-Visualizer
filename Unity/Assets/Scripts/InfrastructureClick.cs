using UnityEngine;
using UnityEngine.InputSystem;

public class InfrastructureClick : MonoBehaviour
{
    private InfrastructureObject infrastructureObject;
    private Camera mainCamera;

    [SerializeField]
    private GameObject infoPanel;

    [SerializeField]
    private ObjectSelectionHighlight selectionHighlight;

    private static ObjectSelectionHighlight currentlySelected;

    void Start()
    {
        infrastructureObject = GetComponent<InfrastructureObject>();
        mainCamera = Camera.main;

        if (selectionHighlight == null)
        {
            selectionHighlight =
                GetComponentInChildren<ObjectSelectionHighlight>();
        }

        Debug.Log("InfrastructureClick ready on: " + gameObject.name);
    }

    void Update()
    {
        Vector2 inputPosition;

        // -----------------------------------------
        // MOUSE INPUT - Unity Editor testing
        // -----------------------------------------
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            inputPosition =
                Mouse.current.position.ReadValue();

            CheckObjectClick(inputPosition);
        }

        // -----------------------------------------
        // TOUCH INPUT - Android AR
        // -----------------------------------------
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            inputPosition =
                Touchscreen.current.primaryTouch.position.ReadValue();

            CheckObjectClick(inputPosition);
        }
    }

    private void CheckObjectClick(Vector2 inputPosition)
    {
        if (mainCamera == null)
            return;

        Ray ray =
            mainCamera.ScreenPointToRay(inputPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InfrastructureClick clickedObject =
                hit.collider.GetComponentInParent<InfrastructureClick>();

            if (clickedObject == this)
            {
                SelectObject();
            }
        }
    }

    private void SelectObject()
    {
        Debug.Log("CLICK/TAP DETECTED: " + gameObject.name);

        // Remove highlight from previously selected object
        if (currentlySelected != null &&
            currentlySelected != selectionHighlight)
        {
            currentlySelected.RemoveHighlight();
        }

        // Highlight selected object
        if (selectionHighlight != null)
        {
            selectionHighlight.Highlight();
            currentlySelected = selectionHighlight;
        }

        // Show infrastructure information
        if (infrastructureObject != null)
        {
            infrastructureObject.ShowInformation();
        }

        // Show information panel
        if (infoPanel != null)
        {
            InformationPanelUI panelUI =
                infoPanel.GetComponent<InformationPanelUI>();

            if (panelUI != null &&
                infrastructureObject != null)
            {
                panelUI.ShowInformation(infrastructureObject);
            }

            // Move panel above selected object
            infoPanel.transform.position =
                transform.position +
                new Vector3(0f, 1.5f, 0f);

            infoPanel.SetActive(true);
        }
    }
}