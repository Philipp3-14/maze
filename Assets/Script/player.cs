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
    //private Vector3 point;
    public float M;
    static public int kyeNum=0;
    public GameObject Kye;
    static public int[] planpos = new int[13];
    int i, j;
    static public int level=5;
    static public bool levelChang;
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 1, 0);
        j = 0;
        for (i = 0; i < 2 * player.level; i+=4)
        {
            planpos[j] = i;
            j++;
        }
        for (i = 0; i <(level/10)+1; i++)
        { Instantiate(Kye, new Vector3(planpos[Random.Range(0, (level/2)+1)], 1, planpos[Random.Range(0, (level / 2) + 1)]), transform.rotation); }
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
        if (other.gameObject.tag == "Wall")
        { OnTrigger = true; }
        if (other.gameObject.tag == "Key")
        { kyeNum++;}
        if (other.gameObject.tag == "boss")
        { 
            kyeNum--;
            Instantiate(Kye, new Vector3(planpos[Random.Range(0, (level / 2) + 1)], 1, planpos[Random.Range(0, (level / 2) + 1)]), transform.rotation);
        }
        if (other.gameObject.tag == "gate" && kyeNum>=1)
        {
            transform.position = new Vector3(0, 1, 0);
            for (i = 0; i < (level / 10) + 1; i++)
            { Instantiate(Kye, new Vector3(planpos[Random.Range(0, (level / 2) + 1)], 1, planpos[Random.Range(0, (level / 2) + 1)]), transform.rotation); }
            kyeNum = 0;
            level+=2;
            levelChang = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        OnTrigger =false;
    }
}
