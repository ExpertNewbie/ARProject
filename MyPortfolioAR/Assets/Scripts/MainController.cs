using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] TextAsset csvText;
    public static List<DataClass> dataList;
    // Start is called before the first frame update
    void Start()
    {
        dataList = DataLorder.LordData(csvText);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hitInfo;
                if(Physics.Raycast(ray, out hitInfo))
                {
                    ButtonController bc = hitInfo.transform.parent.GetComponent<ButtonController>();
                    ButtonResummon br   = hitInfo.transform.parent.GetComponent<ButtonResummon>();
                    if(bc != null)
                    {
                        bc.SendObjectData();
                    }
                    if(br != null)
                    {
                        br.OnPushed();
                    }
                }
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
