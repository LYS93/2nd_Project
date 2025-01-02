using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonemove : MonoBehaviour
{
    public float speed = 1f;  // 움직이는 속도
    public float minX = -0.65f; // 이동 범위의 최소값
    public float maxX = -0.58f; // 이동 범위의 최대값

    void Update()
    {
        float range = maxX - minX;
        float offset = Mathf.PingPong(Time.time * speed, range);
        transform.position = new Vector3(transform.position.x ,minX + offset, transform.position.z);
    }
}
