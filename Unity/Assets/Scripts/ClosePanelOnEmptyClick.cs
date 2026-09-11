using UnityEngine;
using UnityEngine.InputSystem;

public class ClosePanelOnEmptyClick : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;

    [SerializeField]
    private Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        Vector2 inputPosition;
        bool inputPressed = false;

        // -----------------------------------------
        // MOUSE INPUT - Unity Editor
        // -----------------------------------------
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            inputPosition =
                Mouse.current.position.ReadValue();

            inputPressed = true;
        }
        // -----------------------------------------
        // TOUCH INPUT - Android
        // -----------------------------------------
        else if (Touchscreen.current != null &&
                 Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            inputPosition =
                Touchscreen.current.primaryTouch.position.ReadValue();

            inputPressed = true;
        }
        else
        {
            return;
        }

        if (!inputPressed || mainCamera == null)
            return;

        Ray ray =
            mainCamera.ScreenPointToRay(inputPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InfrastructureClick clickedObject =
                hit.collider.GetComponentInParent<InfrastructureClick>();

            // An infrastructure object was clicked/tapped.
            // Let InfrastructureClick handle it.
            if (clickedObject != null)
                return;
        }

        // Empty space was clicked/tapped.
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}