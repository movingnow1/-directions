using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class SpeakerManager_KR : MonoBehaviourPun
{
    public KeyCode pushBtn = KeyCode.P;
    public Recorder voiceRecorder;
    PhotonView view;

    void Start()
    {
        view = photonView;
        voiceRecorder.TransmitEnabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(pushBtn))
        {
            if(view.IsMine)
            {
                voiceRecorder.TransmitEnabled = true;
            }
        }
        else if(Input.GetKeyUp(pushBtn))
        {
            if (view.IsMine)
            {
                voiceRecorder.TransmitEnabled = false;
            }
        }
    }
}
