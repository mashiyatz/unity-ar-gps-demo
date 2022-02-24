using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ARLocation;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceLandmark: MonoBehaviour
{

    // Consider making this a second app? 
    // Key Functions:
    // 0. Add menu option for creating new object. Prompt user for object name. 
    // 1. Generate object by tapping. 
    // 2. Add object details to library, so that it can be accessed later.  
    // 3. Allow user to adjust object placement. 

    public GameObject markerPrefab;

    private GameObject markerObject;
    private ARRaycastManager arRayCastManager;
    private Vector2 touchPosition;
    private bool isDisplayOn;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRayCastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            // What happens if touch is in front of UI? 
            // Solution: Only allow touch placement when UI is closed. 
            touchPosition = Input.GetTouch(0).position;
            return true;
        } else
        {
            touchPosition = default;
            return false;
        }
    }

    void Update()
    {
        if(isDisplayOn) { return; }
        if(!TryGetTouchPosition(out touchPosition)) { return; }        
        if(arRayCastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if (markerObject == null)
            {
                markerObject = Instantiate(markerPrefab, hitPose.position, hitPose.rotation);
            } else
            {
                markerObject.transform.position = hitPose.position;
            }

            // save location data as latitude and longitude 
            // Location location = ARLocationProvider.Instance.GetLocationForWorldPosition(hitPose.position);
        }
    }
}
