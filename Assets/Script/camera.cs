﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.OnTrigger)
        { transform.position = Player.transform.position; }
        transform.rotation = Player.transform.rotation;
    }
}
