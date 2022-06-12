using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastController : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject newObject;
    private GameObject spawnobject;

    public Text subtitle;
    public GameObject sun;

    // Update is called once per frame
    void Update()
    {
        OnTouch();
    }

    void ObjectToCenter()
    {
        Vector3 center = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(center, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose newPose = hits[0].pose;
            newObject.transform.SetPositionAndRotation(newPose.position, newPose.rotation);
            newObject.SetActive(true);
        }
    }

    void OnTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if(raycastManager.Raycast(touch.position, hits, TrackableType.FeaturePoint))
            {
                Pose newPose = hits[0].pose;
                if (!spawnobject)
                {
                    spawnobject = Instantiate(newObject, newPose.position, newPose.rotation);
                    Invoke("OnFire", 5f);
                }
                else
                {
                    spawnobject.transform.position = newPose.position;
                    //spawnobject.transform.rotation = newPose.rotation;
                }
            }
        }
    }

    void OnFire()
    {
        sun.SetActive(true);
        subtitle.text = "햇빛을 찾았습니다!";
    }
}
