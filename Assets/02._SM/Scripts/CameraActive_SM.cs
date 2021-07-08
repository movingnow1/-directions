using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraActive_SM : MonoBehaviourPun
{
    void Start()
    {
        Debug.Log("adasdsdafasdfasdfasdf"+PhotonNetwork.IsMasterClient);
        if (photonView.IsMine)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
