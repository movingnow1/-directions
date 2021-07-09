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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            photonView.RPC("ClickDown", RpcTarget.All, pos, co.r, co.g, co.b, co.a, width);
            //ClickDown(pos, co.r, co.g, co.b, co.a, width);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);

            photonView.RPC("ClickStay", RpcTarget.All, mpos);
            //ClickStay(mpos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
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
                lrColor.RemoveAt(lrColor.Count - 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            OnClickSend();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            photonView.RPC("StartDraw", RpcTarget.All);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            photonView.RPC("EndDraw", RpcTarget.All);
        }
    }

    [PunRPC]
    void StartDraw()
    {
        Camera.main.transform.GetComponent<PhotonTransformView>().enabled = false;
    }

    [PunRPC]
    void EndDraw()
    {
        Camera.main.transform.GetComponent<PhotonTransformView>().enabled = true;
    }
    [PunRPC]
    void ClickDown(Vector3 pos, float r, float g, float b, float a, float width)
    {
        if ((int)(pos.x * 10) > 1)
        {
            use = false;
            return;
        }
        if (!use) return;
        GameObject go = Instantiate(LinePrefab);
        lr = go.GetComponent<LineRenderer>();
        lr.positionCount = 1;
        LineSetting(new Color(r, g, b, a), width);
        lrColor.Add(new Color(r, g, b, a));
        lrList.Add(go);
        lr.SetPosition(0, pos);
    }
    [PunRPC]
    void ClickStay(Vector3 mpos)
    {
        if (!use) return;
        Vector3 lrpos = lrList[lrList.Count - 1].GetComponent<LineRenderer>().GetPosition(lr.positionCount - 1);
        if (Vector3.Distance(lrpos, mpos) < 0.005f) return;
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, mpos);
    }
    [PunRPC]
    void ClickUp()
    {
        use = true;
    }
    [PunRPC]
    public void OnClickSend()
    {
        if (lrList.Count == 0) return;
        for (int i = 0; i < lrList.Count; i++)
        {
            photonView.RPC("CreateLine", RpcTarget.Others , lrColor[i].r , lrColor[i].g , lrColor[i].b , lrColor[i].a , width);
            LineRenderer line = lrList[i].GetComponent<LineRenderer>();
            for (int j = 0; j < line.positionCount; j++)
                photonView.RPC("SetLinePos", RpcTarget.Others, line.GetPosition(j), j);
        }

        for(int i = 0; i< lrList.Count; i++)
            Destroy(lrList[i]);

        lrList.Clear();
        lrColor.Clear();
    }

    [PunRPC]
    void SetLinePos(Vector3 pos, int i)
    {
        lr.positionCount++;
        lr.SetPosition(i, pos);
        lr.transform.position = Camera.main.transform.position;
        lr.transform.forward = Camera.main.transform.forward;
    }
    [PunRPC]
    //라인 생성
    void CreateLine(float r, float g, float b, float a, float width)
    {
        GameObject go = Instantiate(LinePrefab);
        lr = go.GetComponent<LineRenderer>();
        LineSetting(new Color(r, g, b, a), width);
    }

    public Color co { get; set; }
    public float width { get; set; }

    void LineSetting(Color color, float width)
    {
        lr.SetColors(color, color);
        lr.SetWidth(width, width);
    }
}
