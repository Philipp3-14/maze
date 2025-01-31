﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public float Rspeed;
    public float addSpeed;
    private float udSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.level * 2 - 2, 0, player.level * 2 - 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.kyeNum >=1)
        { gameObject.GetComponent<Renderer>().enabled = true; }
        else
        { gameObject.GetComponent<Renderer>().enabled = false; }
        transform.rotation = Quaternion.Euler(0, Rspeed * Time.deltaTime, 0) * transform.rotation;
        if (transform.position.y >= 1)
        {
            if (transform.position.y < 1.1 || udSpeed < 0)
            { transform.Translate(0, udSpeed * Time.deltaTime, 0); }
            udSpeed -= addSpeed * Time.deltaTime;
        }
        if (transform.position.y <= 1)
        {
            if (transform.position.y > 0.9 || udSpeed > 0)
            { transform.Translate(0, udSpeed * Time.deltaTime, 0); }
            udSpeed += addSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" && player.kyeNum >= 1)
        { transform.position = new Vector3(player.level * 2+2 , 0, player.level * 2+2); }
    }
}
