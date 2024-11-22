using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Con : MonoBehaviour
{
    Image buttonImage;
    Rigidbody buttonRigi;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.color = Color.gray;
        buttonRigi = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    public void ButtonColor(bool _hit)
    {
        if (!_hit)
        {
            buttonImage.color = Color.gray;
        }
        else
        {
            buttonImage.color = Color.white;
        }
    }
}
