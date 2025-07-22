using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeGlass : MonoBehaviour
{
    private ARFaceManager arFaceManager;
    private ARFace trackedFace;

    void Start()
    {
        arFaceManager = FindAnyObjectByType<ARFaceManager>();
        arFaceManager.facesChanged += OnFacesChanged;
    }

    private void OnDestroy()
    {
        if (arFaceManager != null)
            arFaceManager.facesChanged -= OnFacesChanged;
    }

    private void OnFacesChanged(ARFacesChangedEventArgs args)
    {
        // Store reference to first tracked face
        if (args.added.Count > 0 && trackedFace == null)
        {
            trackedFace = args.added[0];
        }
    }

    public void monocle()
    {
        if (trackedFace == null) return;

        trackedFace.transform.GetChild(0).gameObject.SetActive(true);
        trackedFace.transform.GetChild(1).gameObject.SetActive(false);
        trackedFace.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void cat()
    {
        if (trackedFace == null) return;

        trackedFace.transform.GetChild(0).gameObject.SetActive(false);
        trackedFace.transform.GetChild(1).gameObject.SetActive(false);
        trackedFace.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void simple()
    {
        if (trackedFace == null) return;

        trackedFace.transform.GetChild(0).gameObject.SetActive(false);
        trackedFace.transform.GetChild(1).gameObject.SetActive(true);
        trackedFace.transform.GetChild(2).gameObject.SetActive(false);
    }
}
