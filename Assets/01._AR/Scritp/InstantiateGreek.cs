using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGreek : MonoBehaviour
{
    public GameObject temple;
    public GameObject templeExe;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void seeHouse()
    {
        GameObject house=Instantiate(templeExe);
        Vector3 dir = Camera.main.transform.position + Camera.main.transform.forward * 2;
        dir.y = Camera.main.transform.position.y - 1;
        house.transform.position = dir;
        house.transform.forward = Camera.main.transform.forward;

        //큰거
        house = Instantiate(temple);
        dir -= Camera.main.transform.forward;
        dir.y = 0;
        house.transform.position = dir;
        house.transform.forward = Camera.main.transform.forward;
    }
}
