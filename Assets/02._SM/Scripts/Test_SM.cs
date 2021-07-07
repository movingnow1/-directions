using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Test_SM : MonoBehaviour
{
    private void Awake()
    {
        //gameObject.SetActive(false);
    }

    void Start()
    {
        //PC버전
#if UNITY_STANDALONE_WIN
        print("standalone");
        gameObject.SetActive(false);
#endif
    }

    void Update()
    {

    }

}
