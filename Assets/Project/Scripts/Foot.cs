using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    ParticleSystem particle;

    L_Hand Lhand;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Play();

        Lhand = GameObject.Find("leftHand").GetComponent<L_Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Lhand.moveIn == true)
        {
            particle.Stop();
        }
    }
}
