using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;



public class Massage : MonoBehaviourPun
{ 
    public GameObject texts;
    public GameObject pictures;

    string pictureName;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{

        //    pictures.GetComponent<Image>().sprite = Resources.Load("p", typeof(Sprite)) as Sprite;
        //    texts.GetComponent<Text>().text = " 사람들을  이끄는 \n 자유,  1830";

        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{

        //    pictures.GetComponent<Image>().sprite = Resources.Load("sm1", typeof(Sprite)) as Sprite;
        //    texts.GetComponent<Text>().text = "현실주의  예술가";

        //}
        ////if (Input.GetKeyDown(KeyCode.R))
        ////{
        ////    pictures.GetComponent<Image>().sprite = Resources.Load("E", typeof(Sprite)) as Sprite; ;
        ////    texts.GetComponent<Text>().text = " ";

        ////}

    }
    public void t1()
    {
        print("ttttt");
        if (pictureName == "sm1") return;
        photonView.RPC("t2", RpcTarget.All);
    }
    [PunRPC]
    public void t2()
    {
        pictures.GetComponent<Image>().sprite = Resources.Load("sm1", typeof(Sprite)) as Sprite;
        texts.GetComponent<Text>().text = "현실주의  예술가";
        pictureName = "sm1";

    }

    //public void tf1()
    //{
    //    photonView.RPC("tf2", RpcTarget.Others);
    //}
    //[PunRPC]
    //public void tf2()
    //{

    //    pictures.GetComponent<Image>().sprite = Resources.Load("E", typeof(Sprite)) as Sprite; ;
    //    texts.GetComponent<Text>().text = " ";

    //}
    public void Ut1()
    {
        if (pictureName == "p") return;
        photonView.RPC("Ut2", RpcTarget.All);
    }
    [PunRPC]
    public void Ut2()
    {
        print("u2");
        Debug.Log("ss");
        pictures.GetComponent<Image>().sprite = Resources.Load("p", typeof(Sprite)) as Sprite;
        texts.GetComponent<Text>().text = " 사람들을  이끄는 \n 자유,  1830";
        pictureName = "p";
    }
    //public void Uf1()
    //{
    //    photonView.RPC("Uf2", RpcTarget.Others);
    //}
    //[PunRPC]
    //public void Uf2()
    //{

    //    pictures.GetComponent<Image>().sprite = Resources.Load("E", typeof(Sprite)) as Sprite; ;
    //    texts.GetComponent<Text>().text = " ";

    //}




}
