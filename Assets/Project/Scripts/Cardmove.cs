using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardmove : MonoBehaviour
{
    public float speed = 0.05f;  // 움직이는 속도
    public float minX = 1.5f; // 이동 범위의 최소값
    public float maxX = 1.6f; // 이동 범위의 최대값

    void Update()
    {
        // PingPong을 사용하여 1.5에서 1.6 사이의 값을 계산
        float range = maxX - minX;
        float offset = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(minX + offset, transform.position.y, transform.position.z);
    }
}
