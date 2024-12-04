using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVR_Con : MonoBehaviour
{
    private R_Hand Rhand;

    // 고정할 기준 회전값
    private Quaternion fixedRotation;

    void Start()
    {
        Rhand = GameObject.Find("rightHand").GetComponent<R_Hand>();

        // 트래킹 비활성화
        OVRManager.instance.usePositionTracking = false;
        OVRManager.instance.useRotationTracking = false;

        // 초기 회전값 저장 (필요 시 설정 가능)
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (Rhand.moveIn == true)
        {
            // 트래킹 활성화
            OVRManager.instance.usePositionTracking = true;
            OVRManager.instance.useRotationTracking = true;
        }
        else
        {
            // 카메라 회전을 고정
            transform.rotation = fixedRotation;
        }
    }
}
