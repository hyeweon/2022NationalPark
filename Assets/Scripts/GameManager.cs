using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Google.XR.ARCoreExtensions;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace National_Park_AR_Project
{
    public class GameManager : MonoBehaviour
    {
        public AREarthManager earthManager;
        public VpsInitializer initializer;

        public SubtitleData subtitleData;

        public Text output;
        public Text subtitle;

        public double HeadingThreshold = 25;
        public double HorizontalThreshold = 20;

        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Heading;
        public GameObject ContentPrefab;
        GameObject displayObject;
        public ARAnchorManager AnchorManager;

        [SerializeField] private GeospatialPose[] locs;
        [SerializeField] private GameObject[] prefabs;
        private Dictionary<Double, GameObject> spanwedObjects;

        int subNum = 0;
        [SerializeField] private string[] subs;

        // Start is called before the first frame update
        void Start()
        {
            //Invoke("ChangeSubtitle", 5f);
        }

        // Update is called once per frame
        void Update()
        {
            string status = "";

            if (!initializer.IsReady ||
            earthManager.EarthTrackingState != TrackingState.Tracking)
            {
                return;
            }

            GeospatialPose pose = earthManager.CameraGeospatialPose;

            // 정확도
            if (pose.HeadingAccuracy > HeadingThreshold || pose.HorizontalAccuracy > HorizontalThreshold)
            {
                status = "Low Tracking accuracy ";
            }
            else
            {
                status = "High Tracking Accuracy ";
                // 오브젝트 스폰
                if (displayObject == null)
                {
                    Altitude = pose.Altitude - 1.5f;
                    Quaternion quaternion = Quaternion.AngleAxis(180f - (float)Heading, Vector3.up);

                    ARGeospatialAnchor anchor = AnchorManager.AddAnchor(Latitude, Longitude, Altitude, quaternion);

                    if (anchor != null)
                    {
                        displayObject = Instantiate(ContentPrefab, anchor.transform);
                    }
                }

                foreach (GeospatialPose loc in locs)
                {
                    if (spanwedObjects[loc.Latitude] == null)
                    {
                        Altitude = pose.Altitude - 1.5f;
                        Quaternion quaternion = Quaternion.AngleAxis(180f - (float)Heading, Vector3.up);

                        ARGeospatialAnchor anchor = AnchorManager.AddAnchor(Latitude, Longitude, Altitude, quaternion);

                        if (anchor != null)
                        {
                            displayObject = Instantiate(ContentPrefab, anchor.transform);
                        }
                    }
                }
            }

            if(pose.Latitude == Latitude && pose.Longitude == Longitude)
            {
                ChangeSubtitle();
            }

            ShowTrackingInfo(status, pose);

            //OnTouch();
        }

        void OnTouch()
        {
            if (Input.touchCount > 0 && subNum <= subs.Length)
            {
                subNum++;
                //ChangeSubtitle(subs[subNum - 1]);
            }
        }

        void ChangeSubtitle()
        {
            /*
            subNum++;
            subtitle.text = subs[subNum - 1];
            if (subNum == 1)
            {
                Invoke("ChangeSubtitle", 7f);
            }
            else if (subNum < subs.Length)
            {
                Invoke("ChangeSubtitle", 4f);
            }
            */
            
            subtitle.text = subtitleData.GetTalkData(subNum, 1);
        }

        // Geospatial 확인
        void ShowTrackingInfo(string status, GeospatialPose pose)
        {
            output.text = string.Format(
            "Latitude/Longitude: {0}°, {1}°\n" +
            "Horizontal Accuracy: {2}m\n" +
            "Altitude: {3}m\n" +
            "Vertical Accuracy: {4}m\n" +
            "Heading: {5}°\n" +
            "Heading Accuracy: {6} °\n" +
            "{7} \n"
            ,
            pose.Latitude.ToString("F6"),
            pose.Longitude.ToString("F6"),
            pose.HorizontalAccuracy.ToString("F6"),
            pose.Altitude.ToString("F2"),
            pose.VerticalAccuracy.ToString("F2"),
            pose.Heading.ToString("F1"),
            pose.HeadingAccuracy.ToString("F1"),
            status
            );
        }
    }
}


