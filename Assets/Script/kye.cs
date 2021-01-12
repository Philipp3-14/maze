using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kye : MonoBehaviour
{
    public float Rspeed;
    public float addSpeed;
    private float udSpeed;
    private int liveLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position == new Vector3(player.level * 2 - 2, 0, player.level * 2 - 2))
        {
            transform.position = new Vector3(player.planpos[Random.Range(0, 12)], 1, player.planpos[Random.Range(0, 12)]);
        }
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
