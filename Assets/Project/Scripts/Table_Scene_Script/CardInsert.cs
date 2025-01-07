using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInsert : MonoBehaviour
{
    public PanelmanagerScript panelM;

    public GameObject fixedCard;

    Rigidbody cardRg;

    public AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        cardRg = GetComponent<Rigidbody>();

        // AudioSource�� �Ҵ���� �ʾҴٸ� ���
        if (myaudio == null)
        {
            Debug.LogWarning("AudioSource�� �Ҵ���� �ʾҽ��ϴ�.");
        }

        fixedCard.SetActive(false);
        if (panelM == null)  // panelM�� �Ҵ���� �ʾҴٸ� ��� �޽��� ���
        {
            Debug.LogWarning("PanelmanagerScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cardRg != null)
        {
            cardRg.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("cardReader")) //ī�尡 ī�帮���⿡ �νĵǸ�
        {

            Debug.Log("ī�尡 ī�� �����⿡ ��ҽ��ϴ�.");

            // ī�� ������ �Ҹ� ���
            if (myaudio != null)
            {
                myaudio.Play();  // ī�� ������ �Ҹ� ���
            }

            // ������ �� �ִ� ī�� �����, ���� ī�� ǥ��
            this.gameObject.SetActive(false);
            fixedCard.SetActive(true);

            // ������ �Ϸ�Ǿ����ϴ� â ǥ��
            if (panelM != null)  // panelM�� null�� �ƴ��� Ȯ��
            {
                // 5�� �ڿ� ShowOrderedPanel �޼��带 ȣ���ϵ��� ����
                Invoke("ShowOrderedPanel", 5.0f);
            }

            //Debug.Log("�ȵǳ�?");
            //// ������ �� �ִ� ī�尡 �������� �����ִ� ī�尡 ǥ��.
            //this.gameObject.SetActive(false);
            //fixedCard.SetActive(true);
            //// ������ �Ϸ�Ǿ����ϴ� â ǥ��.
            //panelM.orderedPanel.SetActive(true);

        }
    }

    // 3�� �Ŀ� ȣ��� �޼���
    void ShowOrderedPanel()
    {
        if (panelM != null && panelM.orderedPanel != null)  // panelM�� orderedPanel�� null�� �ƴ��� Ȯ��
        {
            panelM.orderedPanel.SetActive(true);  // orderedPanel�� Ȱ��ȭ
            Debug.Log("5�� �Ŀ� �г��� ǥ�õǾ����ϴ�.");

        }
    }

    
}
