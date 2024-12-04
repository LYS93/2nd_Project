using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVR_Con : MonoBehaviour
{
    private R_Hand Rhand;

    // ������ ���� ȸ����
    private Quaternion fixedRotation;

    void Start()
    {
        Rhand = GameObject.Find("rightHand").GetComponent<R_Hand>();

        // Ʈ��ŷ ��Ȱ��ȭ
        OVRManager.instance.usePositionTracking = false;
        OVRManager.instance.useRotationTracking = false;

        // �ʱ� ȸ���� ���� (�ʿ� �� ���� ����)
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (Rhand.moveIn == true)
        {
            // Ʈ��ŷ Ȱ��ȭ
            OVRManager.instance.usePositionTracking = true;
            OVRManager.instance.useRotationTracking = true;
        }
        else
        {
            // ī�޶� ȸ���� ����
            transform.rotation = fixedRotation;
        }
    }
}
