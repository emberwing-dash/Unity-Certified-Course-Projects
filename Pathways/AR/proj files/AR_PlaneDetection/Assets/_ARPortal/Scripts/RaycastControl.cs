using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Only if using the new Input System

public class RaycastControl : MonoBehaviour
{
    [SerializeField] private ARRaycastManager arRayManage;
    [SerializeField] Text txt;

    private Vector3 pos;
    private Quaternion rot;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        pos = new Vector3();
        rot = Quaternion.identity;
    }

    void Update()
    {
        // Check for touch (Input.touchCount for old input system)
#if UNITY_ANDROID || UNITY_IOS
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // Perform AR raycast
            if (arRayManage.Raycast(touchPosition, hits, TrackableType.Planes))
            {
                // Hit detected on a plane
                var hitPose = hits[0].pose;
                pos = hitPose.position;
                rot = hitPose.rotation;

                txt.text = "Hit a plane: TRUE";
            }
            else
            {
                txt.text = "Did not hit a plane: FALSE";
            }
        }
#endif
    }
}
