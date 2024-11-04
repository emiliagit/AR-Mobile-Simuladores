using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CouchPrefab : MonoBehaviour
{
    [SerializeField] private GameObject couchPRefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject couch;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            couch = Instantiate(couchPRefab, image.transform);
            couch.transform.position += prefabOffset;
        }
    }
}
