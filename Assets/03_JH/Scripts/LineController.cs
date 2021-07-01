using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LineController : MonoBehaviourPun
{
    public GameObject LinePrefab;
    LineRenderer lr;
    bool use = true;
    public List<GameObject> lrList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
//#if ENABLE_WINMD_SUPPORT
//    Debug.Log("Windows Runtime Support enabled");
//    // Put calls to your custom .winmd API here
//#endif
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            photonView.RPC("ClickDown", RpcTarget.All , pos);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            photonView.RPC("ClickStay", RpcTarget.All , mpos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //if (!use) use = true;
            photonView.RPC("ClickUp", RpcTarget.All);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (lrList.Count == 0) return;
            lrList[lrList.Count - 1].GetComponent<LineRenderer>().positionCount--;
            if (lrList[lrList.Count - 1].GetComponent<LineRenderer>().positionCount <= 1)
            {
                Destroy(lrList[lrList.Count - 1]);
                lrList.RemoveAt(lrList.Count - 1);
            }
        }
    }

    [PunRPC]
    void ClickDown(Vector3 pos)
    {
        //if (pos.x >= 0.6f && pos.y < 10) { use = false; return; }
        GameObject go = Instantiate(LinePrefab);
        lrList.Add(go);
        lr = go.GetComponent<LineRenderer>();
        lr.positionCount = 1;
        lr.SetPosition(0, pos + Camera.main.transform.position + Camera.main.transform.forward * 0.1f);
        LineSetting();
    }
    [PunRPC]
    void ClickStay(Vector3 mpos)
    {
        if (!use) return;
        Vector3 lrpos = lrList[lrList.Count - 1].GetComponent<LineRenderer>().GetPosition(lr.positionCount - 1);
        if (Vector3.Distance(lrpos, mpos) < 0.005f) return;
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, mpos + Camera.main.transform.position + Camera.main.transform.forward * 0.1f);
    }
    [PunRPC]
    void ClickUp()
    {
        if (!use) use = true;
    }

    [PunRPC]
    void SendLine()
    {

    }

    public Color co { get; set; }
    public float width { get; set; }
    void LineSetting()
    {
        lr.SetColors(co, co);
        lr.SetWidth(width, width);
    }
}
