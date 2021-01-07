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
    static public bool OnTrigger;
    private Vector3 point;
    public float M;
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
        H = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        V = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        MX = Input.GetAxis("Mouse X");
        // rb.AddForce(H * speed * Time.deltaTime, 0, V * speed * Time.deltaTime);
        /*
        if (OnTrigger)
        {
            //if (clo.contacts[0].normal.x == -1)
                //transform.Translate(H * speed * Time.deltaTime*M, 0, V * speed * Time.deltaTime*M);
            //OnTrigger = false;
        }
        */
        //if (!OnTrigger)
        //{
           //point = transform.position;
        transform.Translate(H, 0, V);
        //}
        //transform.Translate(H * speed * Time.deltaTime, 0, V * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, MX *Rspeed, 0) * transform.rotation;
        //point = transform.position;
    }

    private void OnTriggerEnter (Collider other)
    {
        
        OnTrigger = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        OnTrigger = false;
    }
    
}
