using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ButtonResummon : MonoBehaviour
{
    private MultipleImageTracker multipleImageTracker;
    private ARTrackedImage trackedImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPushed()
    {
        Transform parent = gameObject.transform.parent.transform;
        gameObject.transform.SetParent(null);
        gameObject.SetActive(false);
        multipleImageTracker.OnPushResummonButton(trackedImage);
        Destroy(this);
    }
    internal void InitializeResummon(MultipleImageTracker multipleImageTracker, ARTrackedImage trackedImage)
    {
        this.multipleImageTracker = multipleImageTracker;
        this.trackedImage = trackedImage;
    }
}
