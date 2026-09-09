using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARObjectPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToPlace;

    [SerializeField]
    private ARRaycastManager raycastManager;

    private GameObject spawnedObject;

    private static readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(
            touch.position,
            hits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(
                    objectToPlace,
                    hitPose.position,
                    hitPose.rotation
                );
            }
            else
            {
                spawnedObject.transform.SetPositionAndRotation(
                    hitPose.position,
                    hitPose.rotation
                );
            }
        }
    }
}