﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    public GameObject menu;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void TargetOn()
    {
        print("focus");
        menu.SetActive(true);
    }
}
