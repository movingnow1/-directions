using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTrans_KR : MonoBehaviour
{
    //public GameObject exampleObj;

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

            //other.gameObject.SetActive(false);
            //exampleObj.SetActive(true);

        }

    }
}
