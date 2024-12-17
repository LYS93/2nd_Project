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
        buttonImage.color = Color.gray; //각각 버튼들이 선택되지 않았을때 회색
        //buttonRigi = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    public void ButtonColor(bool _hit) //버튼 색을 바꾸는 유니티이벤트용
    {
        if (!_hit) //선택상태가 아닐때
        {
            buttonImage.color = Color.gray; //살짝 어두워짐
        }
        else //선택상태일때
        {
            buttonImage.color = Color.white; //원래 색으로 밝게 돌아옴
        }
    }
}
