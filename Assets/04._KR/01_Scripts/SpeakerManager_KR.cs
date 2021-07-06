using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpeakerManager_KR : MonoBehaviourPun
{

    void Start()
    {
        if(photonView.IsMine)
        {
            AudioListener.volume = 1;
        }
        else
        {
            GetComponent<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        
    }
}
