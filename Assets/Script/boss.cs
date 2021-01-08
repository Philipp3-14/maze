using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    int[] planpos = new int[13];
    int i, j;
    public float speed;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        j = 0;
        for (i = -24; i <= 24; i = i + 4)
        {
            planpos[j] = i;
            j++;
        }
        transform.position = new Vector3(planpos[Random.Range(0, 12)], 1, planpos[Random.Range(0, 12)]);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().LookAt(player);
        transform.Translate(0,0,speed * Time.deltaTime);
    }
}
