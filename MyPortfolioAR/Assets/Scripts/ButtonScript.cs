using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ButtonScript : MonoBehaviour
{
    public GameObject arObject;
    public GameObject effectObj;
    public Text nameText;
    int count = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonDefaultAnimation()
    {
        anim.SetTrigger("Default");
    }
    public void ButtonAttack()
    {
        anim.SetTrigger("Attack");
    }
    public void ButtonFlight()
    {
        anim.SetTrigger("Flight");
    }
    public void ButtonDelete()
    {
        /////////////////// Effect Remove
        Instantiate(effectObj, arObject.transform.position, arObject.transform.rotation);
        /////////////////// Effect Remove End
        Transform pra = arObject.transform.parent.transform;
        arObject.transform.SetParent(null);
        Destroy(arObject);
        gameObject.SetActive(false);
    }
    public void SetNameText(string nameString)
    {
        nameText.text = nameString;
    }
}
