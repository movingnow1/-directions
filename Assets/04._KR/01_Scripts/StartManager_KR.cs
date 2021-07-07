using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartManager_KR : MonoBehaviour
{


    void Start()
    {
        PhotonNetwork.Instantiate("Speaker", new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
