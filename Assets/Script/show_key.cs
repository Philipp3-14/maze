﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_key : MonoBehaviour
{
    public int thisKyeNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.kyeNum >= thisKyeNum) 
        {gameObject.GetComponent<Renderer>().enabled = true;}
        else
        { gameObject.GetComponent<Renderer>().enabled = false; }
    }
}
