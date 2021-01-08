using System.Collections;
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

    }

    // Update is called once per frame
    void Update()
    {
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
}
