using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    ARTrackedImageManager imageManager;
    public GameObject panelUI;
    ButtonController bc;
    [SerializeField] GameObject buttonPrefab;
    List<ARTrackedImage> trackList = new List<ARTrackedImage>();
    // Start is called before the first frame update
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
        imageManager.trackedImagesChanged += OnTrackedImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTrackedImage(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage trackedImage in args.added)
        {
            trackList.Add(trackedImage);
            InstantiateTrackObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in args.updated)
        {
            if(trackedImage.transform.childCount > 0)
            {
                trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
                trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
            }
            else
            {
                if(trackList.Contains(trackedImage))
                {
                    InstantiateTrackResummonButton(trackedImage);
                }
            }
        }
    }
    private void InstantiateTrackObject(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;
        GameObject imagePrefab = Resources.Load<GameObject>(imageName);
        if(imagePrefab != null)
        {
            if(trackedImage.transform.childCount < 1)
            {
                GameObject go
                    = Instantiate(  imagePrefab,
                                    trackedImage.transform.position,
                                    trackedImage.transform.rotation);
                go.transform.SetParent(trackedImage.transform);
                /////////////////// Button Controller Setting
                bc = go.AddComponent<ButtonController>();
                bc.TrackedButtonController(panelUI, imageName);
                /////////////////// Button Controller Setting End
            }
        }
    }
    private void InstantiateTrackResummonButton(ARTrackedImage trackedImage)
    {
        if(buttonPrefab != null)
        {
            if(trackedImage.transform.childCount < 1)
            {
                GameObject go
                    = Instantiate(  buttonPrefab,
                                    trackedImage.transform.position,
                                    trackedImage.transform.rotation);
                go.transform.SetParent(trackedImage.transform);
                /////////////////// Button Resummon Setting
                ButtonResummon br = go.AddComponent<ButtonResummon>();
                br.InitializeResummon(this, trackedImage);
                /////////////////// Button Resummon Setting End
            }
        }
    }
    public void OnPushResummonButton(ARTrackedImage trackedImage)
    {
        InstantiateTrackObject(trackedImage);
    }
}
