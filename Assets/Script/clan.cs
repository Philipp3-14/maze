using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clan : MonoBehaviour
{
    private int liveLevel;
    // Start is called before the first frame update
    void Start()
    {
        liveLevel = player.level;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.level!= liveLevel)
        { Destroy(gameObject); }
    }
}
