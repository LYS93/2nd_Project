using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonemove : MonoBehaviour
{
    public float speed = 1f;  // �����̴� �ӵ�
    public float minX = -0.65f; // �̵� ������ �ּҰ�
    public float maxX = -0.58f; // �̵� ������ �ִ밪

    void Update()
    {
        float range = maxX - minX;
        float offset = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(transform.position.x ,minX + offset, transform.position.z);
    }
}
