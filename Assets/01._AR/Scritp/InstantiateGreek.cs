using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class InstantiateGreek : MonoBehaviour
{
    public GameObject instantiateHouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void seeHouse()
    {
        GameObject house=Instantiate(instantiateHouse);
        house.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
=======
using Photon.Pun;

public class InstantiateGreek : MonoBehaviourPun
{
    public GameObject temple;
    public GameObject templeExe;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void CreateTemple()
    {
        photonView.RPC("seeHouse", RpcTarget.All);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            seeHouse();
        }
    }
    [PunRPC]
    // Update is called once per frame
    public void seeHouse()
    {
        //부품
        GameObject house=Instantiate(templeExe);
        Vector3 dir = Camera.main.transform.position + Camera.main.transform.forward;
        dir.y = Camera.main.transform.position.y - 1;
        house.transform.position = dir;
        house.transform.rotation = new Quaternion(0, Camera.main.transform.position.y, 0 ,1);

        //큰거
        house = Instantiate(temple);
        dir += Camera.main.transform.right*2;
        dir.y = Camera.main.transform.position.y - 1;
        house.transform.position = dir;
        house.transform.rotation = new Quaternion(0, Camera.main.transform.position.y, 0, 1);
>>>>>>> CJH
    }
}
