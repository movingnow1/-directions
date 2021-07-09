using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTrans_KR : MonoBehaviour
{
    //public GameObject exampleObj;
    public bool locate = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Peaces")
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            other.transform.GetComponent<ObjectManipulator>().enabled = false;
            //other.transform.gameObject.GetComponent<BoxCollider>().
            //other.gameObject.SetActive(false);
            //exampleObj.SetActive(true);
        }

    }
}
