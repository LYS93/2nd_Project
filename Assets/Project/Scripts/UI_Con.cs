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
        buttonImage.color = Color.gray; //���� ��ư���� ���õ��� �ʾ����� ȸ��
        //buttonRigi = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    public void ButtonColor(bool _hit) //��ư ���� �ٲٴ� ����Ƽ�̺�Ʈ��
    {
        if (!_hit) //���û��°� �ƴҶ�
        {
            buttonImage.color = Color.gray; //��¦ ��ο���
        }
        else //���û����϶�
        {
            buttonImage.color = Color.white; //���� ������ ��� ���ƿ�
        }
    }
}
