using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
