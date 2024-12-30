using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    public GameObject Screen;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(Screen,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
