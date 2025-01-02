using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float openTime;
    float moveD;
    bool openSwitch;
    bool stopSwitch;

    L_Hand Lhand;

    void Start()
    {
        Lhand = GameObject.Find("leftHand").GetComponent<L_Hand>();
        openSwitch = false;
    }

    
    void Update()
    {
        if (openSwitch == false)
        {
            transform.Translate(Time.deltaTime * moveD, 0, 0);
            openTime += Time.deltaTime;

            if (openTime >= 1f && openTime < 3.3f)
            {
                moveD = 1;
            }
            if (openTime >= 3.3f)
            {
                moveD = 0;
                openSwitch = true;
                openTime = 0;
            }
        }
        if(Lhand.moveIn == true && stopSwitch == false)
        {
            transform.Translate(Time.deltaTime * moveD, 0, 0);
            openTime += Time.deltaTime;

            if (openTime >= 1f && openTime < 3.3f)
            {
                moveD = -1;
            }
            if (openTime >= 3.3f)
            {
                moveD = 0;
                openTime = 0;
                stopSwitch = true;
            }
        }
    }
}
