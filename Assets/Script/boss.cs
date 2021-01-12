using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float speed;
    public Transform Player;
    public float udSpeed;
    public float addSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.level > 10)
        {
            GetComponent<Transform>().LookAt(Player);
            transform.Translate(0, 0, speed * Time.deltaTime);
            if (player.levelChang)
            { transform.position = new Vector3(player.planpos[Random.Range(0, (player.level / 2) + 1)], 1, player.planpos[Random.Range(0, (player.level / 2) + 1)]); }
        }
    }
}
