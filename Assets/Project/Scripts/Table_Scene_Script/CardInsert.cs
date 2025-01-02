using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInsert : MonoBehaviour
{
    public PanelmanagerScript panelM;

    public GameObject fixedCard;

    // Start is called before the first frame update
    void Start()
    {
        fixedCard.SetActive(false);
        if (panelM == null)  // panelM�� �Ҵ���� �ʾҴٸ� ��� �޽��� ���
        {
            Debug.LogWarning("PanelmanagerScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("cardReader")) //ī�尡 ī�帮���⿡ �νĵǸ�
        {

            Debug.Log("ī�尡 ī�� �����⿡ ��ҽ��ϴ�.");

            // ������ �� �ִ� ī�� �����, ���� ī�� ǥ��
            this.gameObject.SetActive(false);
            fixedCard.SetActive(true);

            // ������ �Ϸ�Ǿ����ϴ� â ǥ��
            if (panelM != null)  // panelM�� null�� �ƴ��� Ȯ��
            {
                panelM.orderedPanel.SetActive(true);
            }


            //Debug.Log("�ȵǳ�?");
            //// ������ �� �ִ� ī�尡 �������� �����ִ� ī�尡 ǥ��.
            //this.gameObject.SetActive(false);
            //fixedCard.SetActive(true);
            //// ������ �Ϸ�Ǿ����ϴ� â ǥ��.
            //panelM.orderedPanel.SetActive(true);
            
        }
    }
}
