using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kye : MonoBehaviour
{
    public float Rspeed;
    public float addSpeed;
    private float udSpeed;
    private int liveLevel;
    //int[] planpos=new int [13];
    //int i,j;
    // Start is called before the first frame update
    void Start()
    {
        /*
        j = 0;
        for(i=-24;i<=24;i=i+4)
        {
            planpos[j] = i;
            j++;
        }
        transform.position = new Vector3(planpos[Random.Range(0, 12)], 1, planpos[Random.Range(0, 12)]);
        */
        liveLevel = player.level;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Rspeed*Time.deltaTime, 0) * transform.rotation;
        if (transform.position.y >= 1)
        {
            if (transform.position.y < 1.1 || udSpeed < 0)
            { transform.Translate(0, udSpeed * Time.deltaTime, 0); }
            udSpeed -= addSpeed*Time.deltaTime;
        }
        if (transform.position.y <= 1)
        {
            if (transform.position.y > 0.9 || udSpeed > 0)
            { transform.Translate(0, udSpeed * Time.deltaTime, 0); }
            udSpeed += addSpeed*Time.deltaTime;
        }
        if (player.level != liveLevel)
        {Destroy(gameObject); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {Destroy(gameObject); }
    }
}
