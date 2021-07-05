using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LineController : MonoBehaviourPun
{
    public GameObject LinePrefab;
    LineRenderer lr;
    public bool use = true;
    public List<GameObject> lrList = new List<GameObject>();
    public List<Color> lrColor = new List<Color>();
    // Update is called once per frame
    void Update()
    {
        //if (!photonView.IsMine) return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            if ((int)(pos.x * 10) > 2 && (int)(pos.y * 10) < 0)
            {
                use = false;
                return;
            }
            photonView.RPC("ClickDown", RpcTarget.All , pos , co.r , co.g , co.b , co.a  , width);
            ClickDown(pos, co.r, co.g, co.b, co.a, width);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            photonView.RPC("ClickStay", RpcTarget.All , mpos);
            ClickStay(mpos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            use = true;
            //photonView.RPC("ClickUp", RpcTarget.All);
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            OnClickSend();
        }
    }
    [PunRPC]
    void SetUse()
    {
        use = false;
    }
    [PunRPC]
    void ClickDown(Vector3 pos, float r, float g, float b, float a, float width)
    {
        if (!use) return;
        GameObject go = Instantiate(LinePrefab);
        lr = go.GetComponent<LineRenderer>();
        lr.positionCount = 1;
        LineSetting(new Color(r, g, b, a), width);
        lrColor.Add(new Color(r, g, b, a));
        lrList.Add(go);
        lr.SetPosition(0, pos /*+ Camera.main.transform.position + Camera.main.transform.forward * 0.1f*/);
    }
    [PunRPC]
    void ClickStay(Vector3 mpos)
    {
        if (!use) return;
        Vector3 lrpos = lrList[lrList.Count - 1].GetComponent<LineRenderer>().GetPosition(lr.positionCount - 1);
        if (Vector3.Distance(lrpos, mpos) < 0.005f) return;
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, mpos /*+ Camera.main.transform.position + Camera.main.transform.forward * 0.1f*/);
    }
    void ClickUp()
    {
        use = true;
    }

    public void SendLineTest()
    {
        if (lrList.Count == 0) return;
        //CreateLine();
        LineRenderer line = lrList[lrList.Count - 1].GetComponent<LineRenderer>();
        for (int i = 0; i < line.positionCount; i++)
        {
            lr.positionCount++;
            lr.SetPosition(i, line.GetPosition(i) + Camera.main.transform.position);
        }
    }

    public void OnClickSend()
    {
        //if (!photonView.IsMine) return;
        if (lrList.Count == 0) return;
        for (int i = 0; i < lrList.Count; i++)
        {
            photonView.RPC("CreateLine", RpcTarget.Others , lrColor[i].r , lrColor[i].g , lrColor[i].b , lrColor[i].a);
            LineRenderer line = lrList[i].GetComponent<LineRenderer>();
            for (int j = 0; j < line.positionCount; j++)
                photonView.RPC("SetLinePos", RpcTarget.Others, line.GetPosition(j), j);
        }
    }
    [PunRPC]
    void SetLinePos(Vector3 pos, int i)
    {
        lr.positionCount++;
        lr.SetPosition(i, pos + Camera.main.transform.position + Camera.main.transform.forward * 0.1f);
    }
    [PunRPC]
    //라인 생성
    void CreateLine(float r , float g , float b , float a)
    {
        GameObject go = Instantiate(LinePrefab);
        lr = go.GetComponent<LineRenderer>();
        lr.SetColors(new Color(r , g , b , a) , new Color(r , g , b , a));
    }

    public Color co { get; set; }
    public float width { get; set; }

    void LineSetting(Color color, float width)
    {
        lr.SetColors(color, color);
        lr.SetWidth(width, width);
    }
}
