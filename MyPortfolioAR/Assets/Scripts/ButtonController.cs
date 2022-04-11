using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string SerialName { get; set; }
    GameObject panel;
    ButtonScript buttonScript;
    string ARName;
    // Start is called before the first frame update
    void Start()
    {
        buttonScript = panel.GetComponent<ButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SendObjectData()
    {
        panel.SetActive(true);
        buttonScript.SetNameText(ARName);
        buttonScript.arObject = gameObject;
        buttonScript.anim = gameObject.GetComponentInChildren<Animator>();
    }
    public void TrackedButtonController(GameObject panel, string serialName)
    {
        this.panel = panel;
        foreach(DataClass data in MainController.dataList)
        {
            if(data.SerialName == serialName)
            {
                SerialName = serialName;
                ARName = data.ARName;
                break;
            }
        }
    }
}
