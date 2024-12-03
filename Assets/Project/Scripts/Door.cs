using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float openTime;
    float moveD;
    bool openSwitch;

    void Start()
    {
        openSwitch = false;
    }

    
    void Update()
    {
        transform.Translate(Time.deltaTime * moveD, 0, 0);
        openTime += Time.deltaTime;

        if (openTime >= 1f && openTime <2.7f)
        {
            moveD = 1;
        }
        if(openTime >= 2.7f)
        {
            moveD = 0;
        }
    }
}
