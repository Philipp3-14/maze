using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float Rspeed;
    private float H;
    private float V;
    private float MX;
    private bool OnTrigger;
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(-24, 1, -24);
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        MX = Input.GetAxis("Mouse X");
        // rb.AddForce(H * speed * Time.deltaTime, 0, V * speed * Time.deltaTime);
        if(!OnTrigger)
        { transform.Translate(H * speed * Time.deltaTime, 0, V * speed * Time.deltaTime); }        
        transform.rotation = Quaternion.Euler(0, MX *Rspeed, 0) * transform.rotation;
    }
    private void OnCollisionrEnter(Collider other)
    {
        OnTrigger = true;
    }
    private void OnCollisionExit(Collider other)
    {
        OnTrigger = false;
    }
}
