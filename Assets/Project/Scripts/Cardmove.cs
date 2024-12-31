using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardmove : MonoBehaviour
{
    public float speed = 0.05f;  // �����̴� �ӵ�
    public float minX = 1.5f; // �̵� ������ �ּҰ�
    public float maxX = 1.6f; // �̵� ������ �ִ밪

    void Update()
    {
        // PingPong�� ����Ͽ� 1.5���� 1.6 ������ ���� ���
        float range = maxX - minX;
        float offset = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(minX + offset, transform.position.y, transform.position.z);
    }
}
