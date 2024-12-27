using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UImanagerScript : MonoBehaviour
{ 
    public GameObject ad_sc; //ù ���۽� ���� ȭ���� �ߵ���
    public GameObject Chicken_sc; //�߰��� ��ư�� �������� �߰��� ȭ���� �ߵ���
    public GameObject Rice_sc; //������ ��ư�� �������� ������ ȭ���� �ߵ���
    public GameObject Side_sc; //���̸޴� ��ư�� �������� ������ ȭ���� �ߵ���
    public GameObject Noodle_sc; //�縮 ��ư�� �������� ������ ȭ���� �ߵ���

    public Image[] cate_chick; // �߰��� ī�װ� ��ư�� ����.
    public Image[] cate_rice; // ������ ī�װ� ��ư�� ����.
    public Image[] cate_side; // ���̸޴� ī�װ� ��ư�� ����.
    public Image[] cate_noodle; // �縮 ī�װ� ��ư�� ����.


    Color changeColor = new Color(0.7490196f, 0.1529412f, 0.1607843f, 1); //������
    Color returnColor = new Color(0, 0, 0, 0); //�����ֱ�.

    public GameObject[] gChicken;
    public GameObject[] fRice;
    public GameObject[] aSide;
    public GameObject[] aNoodle;

    public GameObject[] bar;
    public GameObject gotoAd;

    // Start is called before the first frame update
    void Start()
    {
        ad_sc = GameObject.Find("ad");
        Chicken_sc = GameObject.Find("MainmenuChicken");
        Rice_sc = GameObject.Find("MainmenuFriedrice");
        Side_sc = GameObject.Find("MainmenuSide");
        Noodle_sc = GameObject.Find("MainmenuNoodle");


        //ê����Ƽ
        // Image ������Ʈ�� �� ���� ã�Ƽ� ����
        //gChicken = GameObject.FindGameObjectsWithTag("cateChicken");
        //fRice = GameObject.FindGameObjectsWithTag("cateFriedrice");

            cate_chick[0] = gChicken[0].GetComponent<Image>();
            cate_chick[1] = gChicken[1].GetComponent<Image>();
            cate_chick[2] = gChicken[2].GetComponent<Image>();
            cate_chick[3] = gChicken[3].GetComponent<Image>();

        //if (gChicken != null)
        //{
        //}

            cate_rice[0] = fRice[0].GetComponent<Image>();
            cate_rice[1] = fRice[1].GetComponent<Image>();
            cate_rice[2] = fRice[2].GetComponent<Image>();
            cate_rice[3] = fRice[3].GetComponent<Image>();

        //if (fRice != null)
        //{
        //    //cate_rice = fRice.GetComponent<Image>();

        //}

            cate_side[0] = aSide[0].GetComponent<Image>();
            cate_side[1] = aSide[1].GetComponent<Image>();
            cate_side[2] = aSide[2].GetComponent<Image>();
            cate_side[3] = aSide[3].GetComponent<Image>();

            cate_noodle[0] = aNoodle[0].GetComponent<Image>();
            cate_noodle[1] = aNoodle[1].GetComponent<Image>();
            cate_noodle[2] = aNoodle[2].GetComponent<Image>();
            cate_noodle[3] = aNoodle[3].GetComponent<Image>();

        // �ʱ� ���� ����
        ad_sc.SetActive(true);
            gotoAd.SetActive(false);
            Chicken_sc.SetActive(false);
        if (Rice_sc != null)
        {
            Rice_sc.SetActive(false);
        }
        else
        {
            Debug.LogError("Rice_sc �ν����� â���� assigned�� �ȉѾ��.");
        }
        //Rice_sc.SetActive(false);
            Side_sc.SetActive(false);
            Noodle_sc.SetActive(false);
        bar[0].SetActive(false); //�����ִ� ���� ���
            bar[1].SetActive(false); //���� ���� ���


            cate_chick[0].color = changeColor;
            cate_chick[1].color = changeColor;
            cate_chick[2].color = changeColor;
            cate_chick[3].color = changeColor;

            cate_rice[0].color = returnColor;
            cate_rice[1].color = returnColor;
            cate_rice[2].color = returnColor;
            cate_rice[3].color = returnColor;

            cate_side[0].color = returnColor;
            cate_side[1].color = returnColor;
            cate_side[2].color = returnColor;
            cate_side[3].color = returnColor;

            cate_noodle[0].color = returnColor;
            cate_noodle[1].color = returnColor;
            cate_noodle[2].color = returnColor;
            cate_noodle[3].color = returnColor;


        //if (cate_chick != null && cate_rice != null)
        //{

        //    // �⺻������ �߰��� ��ư�� ����������, ������ ��ư�� ȸ������ ����
        //    //cate_chick[2].color = changeColor;
        //    //cate_chick[3].color = changeColor;

        //    //for (int number = 0; number < cate_rice.Length; number++)
        //    //{
        //    //    cate_rice[number].color = returnColor;
        //    //}

        //    //cate_rice[2].color = returnColor;
        //    //cate_rice[3].color = returnColor;

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickToOrder()
    {
        ad_sc.SetActive(false);
        Chicken_sc.SetActive(true);
        gotoAd.SetActive(true);
        bar[0].SetActive(true); //�����ִ� ���� ���
        bar[1].SetActive(false); //���� ���� ���


        //for (int number = 0; number < cate_chick.Length; number++)
        //{
        //    cate_chick[number].color = changeColor;
        //}
        //for (int number = 0; number < cate_rice.Length; number++)
        //{
        //    cate_rice[number].color = returnColor;
        //}
    }

    public void Chicken_SC()
    {
        Rice_sc.SetActive(false);
        Side_sc.SetActive(false);
        Noodle_sc.SetActive(false);
        Chicken_sc.SetActive(true);

        //ê����Ƽ
        // ��ư ���� ���� (���� ��ư�� ȸ������, ���õ� ��ư�� ����������)
        //if (cate_chick != null && cate_rice != null)
        //{
        //    //for (int number = 0; number < cate_chick.Length; number++)
        //    //{
        //    //    cate_chick[number].color = changeColor;
        //    //}
        //    //for (int number = 0; number < cate_rice.Length; number++)
        //    //{
        //    //    cate_rice[number].color = returnColor;
        //    //}

        //    //cate_chick[2].color = changeColor;
        //    //cate_chick[3].color = changeColor;

        //    //cate_rice[2].color = returnColor;
        //    //cate_rice[3].color = returnColor;
        //    Debug.Log("�ȵǳ�????????");
        //}
            cate_chick[0].color = changeColor;
            cate_chick[1].color = changeColor;
            cate_chick[2].color = changeColor;
            cate_chick[3].color = changeColor;

            cate_rice[0].color = returnColor;
            cate_rice[1].color = returnColor;
            cate_rice[2].color = returnColor;
            cate_rice[3].color = returnColor;

            cate_side[0].color = returnColor;
            cate_side[1].color = returnColor;
            cate_side[2].color = returnColor;
            cate_side[3].color = returnColor;

            cate_noodle[0].color = returnColor;
            cate_noodle[1].color = returnColor;
            cate_noodle[2].color = returnColor;
            cate_noodle[3].color = returnColor;
    }

    public void Rice_SC()
    {
        Chicken_sc.SetActive(false);
        Side_sc.SetActive(false);
        Noodle_sc.SetActive(false);
        Rice_sc.SetActive(true);

        //ê����Ƽ
        // ��ư ���� ���� (���� ��ư�� ȸ������, ���õ� ��ư�� ����������)
        //if (cate_chick != null && cate_rice != null)
        //{
        //    //for (int number = 0; number < cate_chick.Length; number++)
        //    //{
        //    //    cate_rice[number].color = changeColor;
        //    //}
        //    //for (int number = 0; number < cate_rice.Length; number++)
        //    //{
        //    //    cate_chick[number].color = returnColor;
        //    //}

        //    //cate_rice[2].color = changeColor;
        //    //cate_rice[3].color = changeColor;

        //    //cate_chick[2].color = returnColor;
        //    //cate_chick[3].color = returnColor;
        //}
            cate_rice[0].color = changeColor;
            cate_rice[1].color = changeColor;
            cate_rice[2].color = changeColor;
            cate_rice[3].color = changeColor;

            cate_chick[0].color = returnColor;
            cate_chick[1].color = returnColor;
            cate_chick[2].color = returnColor;
            cate_chick[3].color = returnColor;

            cate_side[0].color = returnColor;
            cate_side[1].color = returnColor;
            cate_side[2].color = returnColor;
            cate_side[3].color = returnColor;

            cate_noodle[0].color = returnColor;
            cate_noodle[1].color = returnColor;
            cate_noodle[2].color = returnColor;
            cate_noodle[3].color = returnColor;
    }

    public void Side_SC()
    {
        Chicken_sc.SetActive(false);
        Rice_sc.SetActive(false);
        Noodle_sc.SetActive(false);
        Side_sc.SetActive(true);

        cate_side[0].color = changeColor;
        cate_side[1].color = changeColor;
        cate_side[2].color = changeColor;
        cate_side[3].color = changeColor;

        cate_chick[0].color = returnColor;
        cate_chick[1].color = returnColor;
        cate_chick[2].color = returnColor;
        cate_chick[3].color = returnColor;

        cate_rice[0].color = returnColor;
        cate_rice[1].color = returnColor;
        cate_rice[2].color = returnColor;
        cate_rice[3].color = returnColor;

        cate_noodle[0].color = returnColor;
        cate_noodle[1].color = returnColor;
        cate_noodle[2].color = returnColor;
        cate_noodle[3].color = returnColor;
    }

    public void Noodle_SC()
    {
        Chicken_sc.SetActive(false);
        Rice_sc.SetActive(false);
        Side_sc.SetActive(false);
        Noodle_sc.SetActive(true);

        cate_noodle[0].color = changeColor;
        cate_noodle[1].color = changeColor;
        cate_noodle[2].color = changeColor;
        cate_noodle[3].color = changeColor;

        cate_chick[0].color = returnColor;
        cate_chick[1].color = returnColor;
        cate_chick[2].color = returnColor;
        cate_chick[3].color = returnColor;

        cate_rice[0].color = returnColor;
        cate_rice[1].color = returnColor;
        cate_rice[2].color = returnColor;
        cate_rice[3].color = returnColor;

        cate_side[0].color = returnColor;
        cate_side[1].color = returnColor;
        cate_side[2].color = returnColor;
        cate_side[3].color = returnColor;
    }

    public void Bar()
    {
        if (bar[0].activeSelf)
        {
            bar[0].SetActive(false);
            bar[1].SetActive(true);
        }
        else
        {
            bar[1].SetActive(false);
            bar[0].SetActive(true);
        }
    }

    public void ReturnToAd()
    {
        gotoAd.SetActive(false);

        Debug.Log("�� ����ȭ�����?");

        bar[0].SetActive(false); 
        bar[1].SetActive(false); 

        Chicken_sc.SetActive(false);
        Rice_sc.SetActive(false);
        Side_sc.SetActive(false);
        Noodle_sc.SetActive(false);
        ad_sc.SetActive(true);
    }
}
