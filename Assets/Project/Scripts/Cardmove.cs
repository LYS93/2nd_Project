using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardmove : MonoBehaviour
{
    public float speed = 1f;  // �����̴� �ӵ�
    public float minX = 1.5f; // �̵� ������ �ּҰ�
    public float maxX = 1.6f; // �̵� ������ �ִ밪

    void Update()
    {
        float range = maxX - minX;
        float offset = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(minX + offset, transform.position.y, transform.position.z);
    }
}
