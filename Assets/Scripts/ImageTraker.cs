using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTraker : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;

    [SerializeField] private GameObject[] prefabs;
    private Dictionary<string, GameObject> spanwedObjects;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        spanwedObjects = new Dictionary<string, GameObject>();
        int i = 0;

        foreach(GameObject item in prefabs)
        {
            i++;
            GameObject temp = Instantiate(item);
            temp.name = "puzzle" + i.ToString();
            temp.SetActive(false);

            spanwedObjects.Add(temp.name, temp);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisabled()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage item in args.added)
        {
            UpdateObject(item);
        }
        foreach (ARTrackedImage item in args.updated)
        {
            UpdateObject(item);
        }
        foreach (ARTrackedImage item in args.removed)
        {
            spanwedObjects[item.name].SetActive(false);
        }
    }

    void UpdateObject(ARTrackedImage image)
    {
        string imageName = image.referenceImage.name;
        spanwedObjects[imageName].transform.position = image.transform.position;
        spanwedObjects[imageName].transform.rotation = image.transform.rotation;
        spanwedObjects[imageName].SetActive(true);
    }
}
