using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float speed;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.planpos[Random.Range(0, (player.level / 2) + 1)], 1, player.planpos[Random.Range(0, (player.level / 2) + 1)]);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().LookAt(Player);
        transform.Translate(0,0,speed * Time.deltaTime);
        if (player.level>15)
        { gameObject.SetActive(false); }
        else
        { gameObject.SetActive(true); }
    }
}
