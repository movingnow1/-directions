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
        if (Input.GetKeyDown(KeyCode.T))
        {

            pictures.GetComponent<Image>().sprite = Resources.Load("p", typeof(Sprite)) as Sprite;
            texts.GetComponent<Text>().text = " 사람들을  이끄는 자유,  1830  \n \n \n 고전적 피라미드 구성으로 제작 \n \n  소총을 든 남자는 브루주아를 \n 상징 \n ";


        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            pictures.GetComponent<Image>().sprite = Resources.Load("sm1", typeof(Sprite)) as Sprite;
            texts.GetComponent<Text>().text = "현실주의  예술가 \n \n \n 뉴옥 국립 디자인 아카데미 \n 초대회장 \n \n 자연물의 재생산으로 상상력을 \n  자극하는 것이 그림의 목적";

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            pictures.GetComponent<Image>().sprite = Resources.Load("E", typeof(Sprite)) as Sprite; ;
           
        }

    }
    public void SamuelPhoton()
    {
        print("ttttt");
        if (pictureName == "sm1") return;
        photonView.RPC("Samuel", RpcTarget.All);
    }
    [PunRPC]
    public void Samuel()
    {
        pictures.GetComponent<Image>().sprite = Resources.Load("sm1", typeof(Sprite)) as Sprite;
        texts.GetComponent<Text>().text = "현실주의  예술가 \n \n \n 뉴옥 국립 디자인 아카데미 \n 초대회장 \n \n 자연물의 재생산으로 상상력을 \n  자극하는 것이 그림의 목적";

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
    public void EugencePhoton()
    {
        if (pictureName == "p") return;
        photonView.RPC("Eugene", RpcTarget.All);
    }
    [PunRPC]
    public void Eugene()
    {
        print("u2");
        Debug.Log("ss");
        pictures.GetComponent<Image>().sprite = Resources.Load("p", typeof(Sprite)) as Sprite;
        texts.GetComponent<Text>().text = " 사람들을  이끄는 자유,  1830  \n \n \n 고전적 피라미드 구성으로 제작 \n \n  소총을 든 남자는 브루주아를 \n 상징 \n ";

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
