using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    ParticleSystem particle;

    R_Hand Rhand;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Play();

        Rhand = GameObject.Find("rightHand").GetComponent<R_Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Rhand.moveIn == true)
        {
            particle.Stop();
        }
    }
}
