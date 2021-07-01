using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BtnManager_KR : MonoBehaviourPun
{
    public GameObject[] objFactory;

    List<GameObject> indicators = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void CreateStraightBtn()
    {
        photonView.RPC("CreateIndicator", RpcTarget.All, 0);
    }

    public void CreateBackBtn()
    {
        photonView.RPC("CreateIndicator", RpcTarget.All, 1);
    }
    public void CreateLeftBtn()
    {
        photonView.RPC("CreateIndicator", RpcTarget.All, 2);
    }
    public void CreateRightBtn()
    {
        photonView.RPC("CreateIndicator", RpcTarget.All, 3);
    }

    public void OnClearBtn()
    {
        photonView.RPC("ClearObj", RpcTarget.All);
    }

    [PunRPC]
    void CreateIndicator(int index)
    {
        GameObject Obj = Instantiate(objFactory[index]);
        indicators.Add(Obj);
        Obj.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        Obj.transform.forward = Camera.main.transform.forward;
    }

    void ClearObj()
    {
    } 


}
