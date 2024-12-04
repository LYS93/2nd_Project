using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVR_Con : MonoBehaviour
{
    R_Hand Rhand;
    
    void Start()
    {
        Rhand = GameObject.Find("rightHand").GetComponent<R_Hand>();

        OVRManager.instance.usePositionTracking = false;
        OVRManager.instance.useRotationTracking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rhand.moveIn == true)
        {
            OVRManager.instance.usePositionTracking = true;
            OVRManager.instance.useRotationTracking = true;
        }
    }
}
