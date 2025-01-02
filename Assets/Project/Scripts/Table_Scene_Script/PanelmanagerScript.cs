using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelmanagerScript : MonoBehaviour
{
    UImanagerScript barCon; //��ũ��Ʈ ����.
    
    // �޴� Ŭ���� ��ٱ��Ͽ� ��� �г�.
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel9;
    public GameObject panel10;
    public GameObject panel11;
    public GameObject panel12;
    public GameObject panel13;
    public GameObject panel14;
    public GameObject panel15;
    public GameObject panel16;
    public GameObject panel17;
    public GameObject panel18;
    public GameObject panel19;
    public GameObject panel20;
    public GameObject panel21;

    // �г��� RectTransform.
    private RectTransform panel1Rect;
    private RectTransform panel2Rect;
    private RectTransform panel3Rect;
    private RectTransform panel4Rect;
    private RectTransform panel5Rect;
    private RectTransform panel6Rect;
    private RectTransform panel7Rect;
    private RectTransform panel8Rect;
    private RectTransform panel9Rect;
    private RectTransform panel10Rect;
    private RectTransform panel11Rect;
    private RectTransform panel12Rect;
    private RectTransform panel13Rect;
    private RectTransform panel14Rect;
    private RectTransform panel15Rect;
    private RectTransform panel16Rect;
    private RectTransform panel17Rect;
    private RectTransform panel18Rect;
    private RectTransform panel19Rect;
    private RectTransform panel20Rect;
    private RectTransform panel21Rect;
    

    float spacing = 0.03f; // �г� ����

    // �гξ��� ������ ǥ���� �ؽ�Ʈ.
    public Text quantity1;
    public Text quantity2;
    public Text quantity3;
    public Text quantity4;
    public Text quantity5;
    public Text quantity6;
    public Text quantity7;
    public Text quantity8;
    public Text quantity9;
    public Text quantity10;
    public Text quantity11;
    public Text quantity12;
    public Text quantity13;
    public Text quantity14;
    public Text quantity15;
    public Text quantity16;
    public Text quantity17;
    public Text quantity18;
    public Text quantity19;
    public Text quantity20;
    public Text quantity21;


    public Text totalQuantity; // �� �հ� ǥ��

    public Text totalPriceText; // �� ���� ǥ��

    public Text confirmQuantity; // �ֹ����� Ȯ��â �� �հ� ǥ��

    public Text confirmPriceText; // �ֹ����� Ȯ��â �� ���� ǥ��

    public Text paymentPrice; // ����ȭ�� �� ���� ǥ��

    public Text errorMessage; // ���� �޽��� ǥ�� (�г� ���� ���� �ʰ� ��)

    public GameObject errormessagePanel; // �����޼��� �ڿ� ��� �г�.


    int[] quan = new int[21];

    float[] price = new float[21]; // �� �г��� ������ ���� (��: panel1 = 10, panel2 = 20, panel3 = 30)

    // �г��� ������ ���θ� �����ϴ� ����Ʈ (�ִ� 2�������� Ȱ��ȭ ����)
    List<bool> isPanelCreated = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    // �гε��� Ȱ��ȭ�� ������� ����
    List<GameObject> activePanels = new List<GameObject>();

    public GameObject confirmPanel; //�ֹ����� Ȯ�γ��� �ǳ�.

    // ���ο� UI Text �߰�: ����� ���� ǥ�ÿ�
    public Text savedNameText; // ����� ������ ǥ���� UI Text

    // ���ο� UI Text �߰�: ����� ���� ǥ�ÿ�
    public Text savedQuantityText; // ����� ������ ǥ���� UI Text

    // ���ο� UI Text �߰�: ����� �ݾ� ǥ�ÿ�
    public Text savedPriceText; // ����� �ݾ��� ǥ���� UI Text

    // �ִ� ���� ������ �г� ��
    public int maxPanels = 8;

    public GameObject paymentPanel; //����ȭ�� �ǳ�

    public BoxCollider[] boxC; // ��ư�� �ڽ� �ݶ��̴� setActive �����״�.

    public GameObject creditCard; // �ſ�ī�� ������Ʈ
    public GameObject fixedcreditCard; // ������ �ſ�ī�� ������Ʈ

    public GameObject orderedPanel; // ������ �Ϸ�� �ǳ�

    public GameObject timerText; // �ð��� ǥ���� ������Ʈ
    float time = 10.0f;


    // Start is called before the first frame update
    void Start()
    {

        panel1Rect = panel1.GetComponent<RectTransform>();
        panel2Rect = panel2.GetComponent<RectTransform>();
        panel3Rect = panel3.GetComponent<RectTransform>();
        panel4Rect = panel4.GetComponent<RectTransform>();
        panel5Rect = panel5.GetComponent<RectTransform>();
        panel6Rect = panel6.GetComponent<RectTransform>();
        panel7Rect = panel7.GetComponent<RectTransform>();
        panel8Rect = panel8.GetComponent<RectTransform>();
        panel9Rect = panel9.GetComponent<RectTransform>();
        panel10Rect = panel10.GetComponent<RectTransform>();
        panel11Rect = panel11.GetComponent<RectTransform>();
        panel12Rect = panel12.GetComponent<RectTransform>();
        panel13Rect = panel13.GetComponent<RectTransform>();
        panel14Rect = panel14.GetComponent<RectTransform>();
        panel15Rect = panel15.GetComponent<RectTransform>();
        panel16Rect = panel16.GetComponent<RectTransform>();
        panel17Rect = panel17.GetComponent<RectTransform>();
        panel18Rect = panel18.GetComponent<RectTransform>();
        panel19Rect = panel19.GetComponent<RectTransform>();
        panel20Rect = panel20.GetComponent<RectTransform>();
        panel21Rect = panel21.GetComponent<RectTransform>();

        // �г� ��Ȱ��ȭ
        panelSetfalse();

        //// �г� ��Ȱ��ȭ
        //panel1.SetActive(false);
        //panel2.SetActive(false);
        //panel3.SetActive(false);
        //panel4.SetActive(false);
        //panel5.SetActive(false);
        //panel6.SetActive(false);
        //panel7.SetActive(false);
        //panel8.SetActive(false);
        //panel9.SetActive(false);
        //panel10.SetActive(false);
        //panel11.SetActive(false);
        //panel12.SetActive(false);
        //panel13.SetActive(false);
        //panel14.SetActive(false);
        //panel15.SetActive(false);
        //panel16.SetActive(false);
        //panel17.SetActive(false);
        //panel18.SetActive(false);
        //panel19.SetActive(false);
        //panel20.SetActive(false);
        //panel21.SetActive(false);

        //// �г� �ʱ�ȭ
        //panelToZero();

        confirmPanel.SetActive(false);
        paymentPanel.SetActive(false);
        orderedPanel.SetActive(false);
        creditCard.SetActive(false);
        fixedcreditCard.SetActive(false);

        //boxC[0] = GetComponent<BoxCollider>();
        //boxC[1] = GetComponent<BoxCollider>();

        price[0] = 9000f; // panel1 ���� //�߰��� �޴�
        price[1] = 23000f; // panel2 ����
        price[2] = 23000f; // panel3 ����
        price[3] = 10000f;
        price[4] = 6500f; // ������ �޴�
        price[5] = 6500f;
        price[6] = 7000f;
        price[7] = 3000f;
        price[8] = 4000f;
        price[9] = 7000f; // ���̸޴�
        price[10] = 7000f;
        price[11] = 6000f;
        price[12] = 4500f;
        price[13] = 3500f;
        price[14] = 4500f; // �縮�޴�
        price[15] = 3000f;
        price[16] = 2000f;
        price[17] = 2000f;
        price[18] = 2000f;
        price[19] = 2000f;
        price[20] = 1000f;

        errormessagePanel.SetActive(false); // ���� �޽��� �г� �ʱ⿡�� ����
        errorMessage.gameObject.SetActive(false); // ���� �޽��� �ʱ⿡�� ����

        // ���� ���� �� PlayerPrefs �ʱ�ȭ
        P_PrefsDelete();

        // ����� �� �ҷ�����
        LoadPanelValues();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePanel2Position();
        quantity1.text = quan[0].ToString();
        quantity2.text = quan[1].ToString();
        quantity3.text = quan[2].ToString();
        quantity4.text = quan[3].ToString();
        quantity5.text = quan[4].ToString();
        quantity6.text = quan[5].ToString();
        quantity7.text = quan[6].ToString();
        quantity8.text = quan[7].ToString();
        quantity9.text = quan[8].ToString();
        quantity10.text = quan[9].ToString();
        quantity11.text = quan[10].ToString();
        quantity12.text = quan[11].ToString();
        quantity13.text = quan[12].ToString();
        quantity14.text = quan[13].ToString();
        quantity15.text = quan[14].ToString();
        quantity16.text = quan[15].ToString();
        quantity17.text = quan[16].ToString();
        quantity18.text = quan[17].ToString();
        quantity19.text = quan[18].ToString();
        quantity20.text = quan[19].ToString();
        quantity21.text = quan[20].ToString();

        // �հ踦 ����Ͽ� totalQuantity�� ǥ��
        int total = quan[0] + quan[1] + quan[2] + quan[3] + quan[4] + quan[5] + quan[6] + quan[7] + quan[8] + quan[9] + quan[10] + quan[11] + quan[12] + quan[13] + quan[14] + quan[15] + quan[16] + quan[17] + quan[18] + quan[19] + quan[20];
        totalQuantity.text = "�� ����: " + total.ToString() + "��"; // �հ踦 �ؽ�Ʈ�� ǥ��
        confirmQuantity.text = "�ֹ� ���� " + total.ToString() + " ��";

        // ������ ����Ͽ� totalPriceText�� ǥ��
        float totalPrice = (quan[0] * price[0]) + (quan[1] * price[1]) + (quan[2] * price[2]) + (quan[3] * price[3]) + (quan[4] * price[4]) + (quan[5] * price[5]) + (quan[6] * price[6]) + (quan[7] * price[7]) + (quan[8] * price[8]) + (quan[9] * price[9])
            + (quan[10] * price[10]) + (quan[11] * price[11]) + (quan[12] * price[12]) + (quan[13] * price[13]) + (quan[14] * price[14]) + (quan[15] * price[15]) + (quan[16] * price[16]) + (quan[17] * price[17]) + (quan[18] * price[18]) + (quan[19] * price[19]) + (quan[20] * price[20]);
        totalPriceText.text = "�� �����ݾ�: " + totalPrice.ToString() + "��"; // �� ���� ǥ��
        confirmPriceText.text = "�� �ֹ� �ݾ�: " + totalPrice.ToString() + " ��";
        paymentPrice.text = totalPrice.ToString();

        if (orderedPanel.activeSelf)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timerText.GetComponent<Text>().text = time.ToString("F0") + "�� �ڿ� �������� �Ѿ�ϴ�";
            }
            else
            {
                SceneManager.LoadScene("ENDScene");
            }
        }
        else
        {
            time = 10.0f;
        }
        
    }

    // 1�� ��ư Ŭ�� �� ȣ��
    public void OnButton1Click()
    {
        if (!isPanelCreated[0]) // panel1�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[0] = 1;
                quantity1.text = quan[0].ToString(); // ���� ������Ʈ
                panel1.SetActive(true); // panel1 Ȱ��ȭ
                activePanels.Add(panel1); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[0] = true; // panel1 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel1�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[0]++;
            quantity1.text = quan[0].ToString();
        }

        UpdatePanel2Position();
    }

    // 2�� ��ư Ŭ�� �� ȣ��
    public void OnButton2Click()
    {
        if (!isPanelCreated[1]) // panel2�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[1] = 1;
                quantity2.text = quan[1].ToString();
                panel2.SetActive(true); // panel2 Ȱ��ȭ
                activePanels.Add(panel2); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[1] = true; // panel2 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel2�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[1]++;
            quantity2.text = quan[1].ToString();
        }

        UpdatePanel2Position();
    }

    // 3�� ��ư Ŭ�� �� ȣ��
    public void OnButton3Click()
    {
        if (!isPanelCreated[2]) // panel3�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[2] = 1;
                quantity3.text = quan[2].ToString();
                panel3.SetActive(true); // panel3 Ȱ��ȭ
                activePanels.Add(panel3); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[2] = true; // panel3 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel3�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[2]++;
            quantity3.text = quan[2].ToString();
        }

        UpdatePanel2Position();
    }

    // 4�� ��ư Ŭ�� �� ȣ��
    public void OnButton4Click()
    {
        if (!isPanelCreated[3]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[3] = 1;
                quantity4.text = quan[3].ToString(); // ���� ������Ʈ
                panel4.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel4); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[3] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[3]++;
            quantity4.text = quan[3].ToString();
        }

        UpdatePanel2Position();
    }

    // 5�� ��ư Ŭ�� �� ȣ��
    public void OnButton5Click()
    {
        if (!isPanelCreated[4]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[4] = 1;
                quantity5.text = quan[4].ToString(); // ���� ������Ʈ
                panel5.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel5); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[4] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[4]++;
            quantity5.text = quan[4].ToString();
        }

        UpdatePanel2Position();
    }

    // 6�� ��ư Ŭ�� �� ȣ��
    public void OnButton6Click()
    {
        if (!isPanelCreated[5]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[5] = 1;
                quantity6.text = quan[5].ToString(); // ���� ������Ʈ
                panel6.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel6); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[5] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[5]++;
            quantity6.text = quan[5].ToString();
        }

        UpdatePanel2Position();
    }

    // 7�� ��ư Ŭ�� �� ȣ��
    public void OnButton7Click()
    {
        if (!isPanelCreated[6]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[6] = 1;
                quantity7.text = quan[6].ToString(); // ���� ������Ʈ
                panel7.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel7); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[6] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[6]++;
            quantity7.text = quan[6].ToString();
        }

        UpdatePanel2Position();
    }

    // 8�� ��ư Ŭ�� �� ȣ��
    public void OnButton8Click()
    {
        if (!isPanelCreated[7]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[7] = 1;
                quantity8.text = quan[7].ToString(); // ���� ������Ʈ
                panel8.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel8); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[7] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[7]++;
            quantity8.text = quan[7].ToString();
        }

        UpdatePanel2Position();
    }

    // 9�� ��ư Ŭ�� �� ȣ��
    public void OnButton9Click()
    {
        if (!isPanelCreated[8]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[8] = 1;
                quantity9.text = quan[8].ToString(); // ���� ������Ʈ
                panel9.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel9); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[8] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[8]++;
            quantity9.text = quan[8].ToString();
        }

        UpdatePanel2Position();
    }

    // 10�� ��ư Ŭ�� �� ȣ��
    public void OnButton10Click()
    {
        if (!isPanelCreated[9]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[9] = 1;
                quantity10.text = quan[9].ToString(); // ���� ������Ʈ
                panel10.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel10); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[9] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[9]++;
            quantity10.text = quan[9].ToString();
        }

        UpdatePanel2Position();
    }

    // 11�� ��ư Ŭ�� �� ȣ��
    public void OnButton11Click()
    {
        if (!isPanelCreated[10]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[10] = 1;
                quantity11.text = quan[10].ToString(); // ���� ������Ʈ
                panel11.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel11); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[10] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[10]++;
            quantity11.text = quan[10].ToString();
        }

        UpdatePanel2Position();
    }

    // 12�� ��ư Ŭ�� �� ȣ��
    public void OnButton12Click()
    {
        if (!isPanelCreated[11]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[11] = 1;
                quantity12.text = quan[11].ToString(); // ���� ������Ʈ
                panel12.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel12); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[11] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[11]++;
            quantity12.text = quan[11].ToString();
        }

        UpdatePanel2Position();
    }

    // 13�� ��ư Ŭ�� �� ȣ��
    public void OnButton13Click()
    {
        if (!isPanelCreated[12]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[12] = 1;
                quantity13.text = quan[12].ToString(); // ���� ������Ʈ
                panel13.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel13); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[12] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[12]++;
            quantity13.text = quan[12].ToString();
        }

        UpdatePanel2Position();
    }

    // 14�� ��ư Ŭ�� �� ȣ��
    public void OnButton14Click()
    {
        if (!isPanelCreated[13]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[13] = 1;
                quantity14.text = quan[13].ToString(); // ���� ������Ʈ
                panel14.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel14); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[13] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[13]++;
            quantity14.text = quan[13].ToString();
        }

        UpdatePanel2Position();
    }

    // 15�� ��ư Ŭ�� �� ȣ��
    public void OnButton15Click()
    {
        if (!isPanelCreated[14]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[14] = 1;
                quantity15.text = quan[14].ToString(); // ���� ������Ʈ
                panel15.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel15); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[14] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[14]++;
            quantity15.text = quan[14].ToString();
        }

        UpdatePanel2Position();
    }

    // 16�� ��ư Ŭ�� �� ȣ��
    public void OnButton16Click()
    {
        if (!isPanelCreated[15]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[15] = 1;
                quantity16.text = quan[15].ToString(); // ���� ������Ʈ
                panel16.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel16); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[15] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[15]++;
            quantity16.text = quan[15].ToString();
        }

        UpdatePanel2Position();
    }

    // 17�� ��ư Ŭ�� �� ȣ��
    public void OnButton17Click()
    {
        if (!isPanelCreated[16]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[16] = 1;
                quantity17.text = quan[16].ToString(); // ���� ������Ʈ
                panel17.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel17); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[16] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[16]++;
            quantity17.text = quan[16].ToString();
        }

        UpdatePanel2Position();
    }

    // 18�� ��ư Ŭ�� �� ȣ��
    public void OnButton18Click()
    {
        if (!isPanelCreated[17]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[17] = 1;
                quantity18.text = quan[17].ToString(); // ���� ������Ʈ
                panel18.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel18); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[17] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[17]++;
            quantity18.text = quan[17].ToString();
        }

        UpdatePanel2Position();
    }

    // 19�� ��ư Ŭ�� �� ȣ��
    public void OnButton19Click()
    {
        if (!isPanelCreated[18]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[18] = 1;
                quantity19.text = quan[18].ToString(); // ���� ������Ʈ
                panel19.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel19); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[18] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[18]++;
            quantity19.text = quan[18].ToString();
        }

        UpdatePanel2Position();
    }

    // 20�� ��ư Ŭ�� �� ȣ��
    public void OnButton20Click()
    {
        if (!isPanelCreated[19]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[19] = 1;
                quantity20.text = quan[19].ToString(); // ���� ������Ʈ
                panel20.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel20); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[19] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[19]++;
            quantity20.text = quan[19].ToString();
        }

        UpdatePanel2Position();
    }

    // 21�� ��ư Ŭ�� �� ȣ��
    public void OnButton21Click()
    {
        if (!isPanelCreated[20]) // panel4�� ���� �������� �ʾ��� ���
        {
            if (activePanels.Count < maxPanels) // ������ �г��� 8�� �̸��� ���� �г� �߰� ����
            {
                quan[20] = 1;
                quantity21.text = quan[20].ToString(); // ���� ������Ʈ
                panel21.SetActive(true); // panel4 Ȱ��ȭ
                activePanels.Add(panel21); // Ȱ��ȭ�� �г� ��Ͽ� �߰�
                isPanelCreated[20] = true; // panel4 ������ ���·� ǥ��
            }
            else
            {
                ShowErrorMessage("��ٱ��Ͽ� " + maxPanels + " �� ǰ�� ���� �� �ֽ��ϴ�.");
                return;
            }
        }
        else // �̹� panel4�� �����Ǿ� �ִٸ� ������ ����
        {
            quan[20]++;
            quantity21.text = quan[20].ToString();
        }

        UpdatePanel2Position();
    }


    // �г� ��ġ ������Ʈ
    public void UpdatePanel2Position()
    {

        // �гε��� Ȱ��ȭ�� ������� ��ġ ������Ʈ
        float yOffset = 0.167805f; // �ʱ� Y ��ǥ

        foreach (var panel in activePanels)
        {
            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchoredPosition = new Vector2(panelRect.anchoredPosition.x, yOffset); // Y ��ǥ ������Ʈ

            yOffset -= spacing; // ������ �ΰ� �Ʒ��� ��ġ
        }

    }

    // -��ư -> ��������
    public void DecreaseClick00() //�̰��� �߰��� -��ư
    {
        if (quan[0] > 1)
        {
            quan[0]--;
            quantity1.text = quan[0].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick01()
    {
        if (quan[1] > 1)
        {
            quan[1]--;
            quantity2.text = quan[1].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick02()
    {
        if (quan[2] > 1)
        {
            quan[2]--;
            quantity3.text = quan[2].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick03()
    {
        if (quan[3] > 1)
        {
            quan[3]--;
            quantity4.text = quan[3].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick04()
    {
        if (quan[4] > 1)
        {
            quan[4]--;
            quantity5.text = quan[4].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick05()
    {
        if (quan[5] > 1)
        {
            quan[5]--;
            quantity6.text = quan[5].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick06()
    {
        if (quan[6] > 1)
        {
            quan[6]--;
            quantity7.text = quan[6].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick07()
    {
        if (quan[7] > 1)
        {
            quan[7]--;
            quantity8.text = quan[7].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick08()
    {
        if (quan[8] > 1)
        {
            quan[8]--;
            quantity9.text = quan[8].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick09()
    {
        if (quan[9] > 1)
        {
            quan[9]--;
            quantity10.text = quan[9].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick10()
    {
        if (quan[10] > 1)
        {
            quan[10]--;
            quantity11.text = quan[10].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick11()
    {
        if (quan[11] > 1)
        {
            quan[11]--;
            quantity12.text = quan[11].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick12()
    {
        if (quan[12] > 1)
        {
            quan[12]--;
            quantity13.text = quan[12].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick13()
    {
        if (quan[13] > 1)
        {
            quan[13]--;
            quantity14.text = quan[13].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick14()
    {
        if (quan[14] > 1)
        {
            quan[14]--;
            quantity15.text = quan[14].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick15()
    {
        if (quan[15] > 1)
        {
            quan[15]--;
            quantity16.text = quan[15].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick16()
    {
        if (quan[16] > 1)
        {
            quan[16]--;
            quantity17.text = quan[16].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick17()
    {
        if (quan[17] > 1)
        {
            quan[17]--;
            quantity18.text = quan[17].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick18()
    {
        if (quan[18] > 1)
        {
            quan[18]--;
            quantity19.text = quan[18].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick19()
    {
        if (quan[19] > 1)
        {
            quan[19]--;
            quantity20.text = quan[19].ToString(); // ���� ������Ʈ
        }
    }
    public void DecreaseClick20()
    {
        if (quan[20] > 1)
        {
            quan[20]--;
            quantity21.text = quan[20].ToString(); // ���� ������Ʈ
        }
    }

    // +��ư -> ��������
    public void IncreaseClick00() //�̰��� �߰��� +��ư
    {
        quan[0]++;
        quantity1.text = quan[0].ToString(); // ���� ������Ʈ
    }

    public void IncreaseClick01()
    {
        quan[1]++;
        quantity2.text = quan[1].ToString(); // ���� ������Ʈ
    }

    public void IncreaseClick02()
    {
        quan[2]++;
        quantity3.text = quan[2].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick03()
    {
        quan[3]++;
        quantity4.text = quan[3].ToString(); // ���� ������Ʈ        
    }
    public void IncreaseClick04()
    {
        quan[4]++;
        quantity5.text = quan[4].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick05()
    {
        quan[5]++;
        quantity6.text = quan[5].ToString(); // ���� ������Ʈ        
    }
    public void IncreaseClick06()
    {
        quan[6]++;
        quantity7.text = quan[6].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick07()
    {
        quan[7]++;
        quantity8.text = quan[7].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick08()
    {
        quan[8]++;
        quantity9.text = quan[8].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick09()
    {
        quan[9]++;
        quantity10.text = quan[9].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick10()
    {
        quan[10]++;
        quantity11.text = quan[10].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick11()
    {
        quan[11]++;
        quantity12.text = quan[11].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick12()
    {
        quan[12]++;
        quantity13.text = quan[12].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick13()
    {
        quan[13]++;
        quantity14.text = quan[13].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick14()
    {
        quan[14]++;
        quantity15.text = quan[14].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick15()
    {
        quan[15]++;
        quantity16.text = quan[15].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick16()
    {
        quan[16]++;
        quantity17.text = quan[16].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick17()
    {
        quan[17]++;
        quantity18.text = quan[17].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick18()
    {
        quan[18]++;
        quantity19.text = quan[18].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick19()
    {
        quan[19]++;
        quantity20.text = quan[19].ToString(); // ���� ������Ʈ
    }
    public void IncreaseClick20()
    {
        quan[20]++;
        quantity21.text = quan[20].ToString(); // ���� ������Ʈ
    }

    // X��ư -> �׸����
    public void XbuttonClick00(GameObject panel) //�̰��� �߰��� X��ư
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[0] = 0; // quantity�� 0���� ����
            quantity1.text = quan[0].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[0] = false; // �ش� �г� ���� ���¸� false�� ����

        activePanels.Remove(panel);
        UpdatePanel2Position();
    }

    public void XbuttonClick01(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[1] = 0; // quantity�� 0���� ����
            quantity2.text = quan[1].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[1] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }

    public void XbuttonClick02(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[2] = 0; // quantity�� 0���� ����
            quantity3.text = quan[2].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[2] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick03(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[3] = 0; // quantity�� 0���� ����
            quantity4.text = quan[3].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[3] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick04(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[4] = 0; // quantity�� 0���� ����
            quantity5.text = quan[4].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[4] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick05(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[5] = 0; // quantity�� 0���� ����
            quantity6.text = quan[5].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[5] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick06(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[6] = 0; // quantity�� 0���� ����
            quantity7.text = quan[6].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[6] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick07(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[7] = 0; // quantity�� 0���� ����
            quantity8.text = quan[7].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[7] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick08(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[8] = 0; // quantity�� 0���� ����
            quantity9.text = quan[8].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[8] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick09(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[9] = 0; // quantity�� 0���� ����
            quantity10.text = quan[9].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[9] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick10(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[10] = 0; // quantity�� 0���� ����
            quantity11.text = quan[10].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[10] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick11(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[11] = 0; // quantity�� 0���� ����
            quantity12.text = quan[11].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[11] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick12(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[12] = 0; // quantity�� 0���� ����
            quantity13.text = quan[12].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[12] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick13(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[13] = 0; // quantity�� 0���� ����
            quantity14.text = quan[13].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[13] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick14(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[14] = 0; // quantity�� 0���� ����
            quantity15.text = quan[14].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[14] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick15(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[15] = 0; // quantity�� 0���� ����
            quantity16.text = quan[15].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[15] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick16(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[16] = 0; // quantity�� 0���� ����
            quantity17.text = quan[16].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[16] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick17(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[17] = 0; // quantity�� 0���� ����
            quantity18.text = quan[17].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[17] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick18(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[18] = 0; // quantity�� 0���� ����
            quantity19.text = quan[18].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[18] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick19(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[19] = 0; // quantity�� 0���� ����
            quantity20.text = quan[19].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[19] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick20(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // ��Ȱ��ȭ �� ���
        {
            quan[20] = 0; // quantity�� 0���� ����
            quantity21.text = quan[20].ToString(); // UI �ؽ�Ʈ ������Ʈ
        }

        isPanelCreated[20] = false; // �ش� �г� ���� ���¸� false�� ����
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }

    // ���� �޽����� ǥ���ϴ� �Լ�
    private void ShowErrorMessage(string message)
    {
        errormessagePanel.SetActive(true);
        errorMessage.text = message;
        errorMessage.gameObject.SetActive(true); // ���� �޽����� ȭ�鿡 ǥ��
        Invoke("HideErrorMessage", 2f); // 2�� �Ŀ� ���� �޽����� ����
    }

    // ���� �޽����� ����� �Լ�
    private void HideErrorMessage()
    {
        errormessagePanel.SetActive(false);
        errorMessage.gameObject.SetActive(false);
    }

    // �ֹ��ϱ� ��ư Ŭ�� �� ȣ��
    public void OnOrderButtonClick()
    {
        // �г��� ������ ����
        PlayerPrefs.SetInt("Panel1Quantity", quan[0]);
        PlayerPrefs.SetInt("Panel2Quantity", quan[1]);
        PlayerPrefs.SetInt("Panel3Quantity", quan[2]);
        PlayerPrefs.SetInt("Panel4Quantity", quan[3]);
        PlayerPrefs.SetInt("Panel5Quantity", quan[4]);
        PlayerPrefs.SetInt("Panel6Quantity", quan[5]);
        PlayerPrefs.SetInt("Panel7Quantity", quan[6]);
        PlayerPrefs.SetInt("Panel8Quantity", quan[7]);
        PlayerPrefs.SetInt("Panel9Quantity", quan[8]);
        PlayerPrefs.SetInt("Panel10Quantity", quan[9]);
        PlayerPrefs.SetInt("Panel11Quantity", quan[10]);
        PlayerPrefs.SetInt("Panel12Quantity", quan[11]);
        PlayerPrefs.SetInt("Panel13Quantity", quan[12]);
        PlayerPrefs.SetInt("Panel14Quantity", quan[13]);
        PlayerPrefs.SetInt("Panel15Quantity", quan[14]);
        PlayerPrefs.SetInt("Panel16Quantity", quan[15]);
        PlayerPrefs.SetInt("Panel17Quantity", quan[16]);
        PlayerPrefs.SetInt("Panel18Quantity", quan[17]);
        PlayerPrefs.SetInt("Panel19Quantity", quan[18]);
        PlayerPrefs.SetInt("Panel20Quantity", quan[19]);
        PlayerPrefs.SetInt("Panel21Quantity", quan[20]);
        PlayerPrefs.SetFloat("Panel1Price", price[0]);
        PlayerPrefs.SetFloat("Panel2Price", price[1]);
        PlayerPrefs.SetFloat("Panel3Price", price[2]);
        PlayerPrefs.SetFloat("Panel4Price", price[3]);
        PlayerPrefs.SetFloat("Panel5Price", price[4]);
        PlayerPrefs.SetFloat("Panel6Price", price[5]);
        PlayerPrefs.SetFloat("Panel7Price", price[6]);
        PlayerPrefs.SetFloat("Panel8Price", price[7]);
        PlayerPrefs.SetFloat("Panel9Price", price[8]);
        PlayerPrefs.SetFloat("Panel10Price", price[9]);
        PlayerPrefs.SetFloat("Panel11Price", price[10]);
        PlayerPrefs.SetFloat("Panel12Price", price[11]);
        PlayerPrefs.SetFloat("Panel13Price", price[12]);
        PlayerPrefs.SetFloat("Panel14Price", price[13]);
        PlayerPrefs.SetFloat("Panel15Price", price[14]);
        PlayerPrefs.SetFloat("Panel16Price", price[15]);
        PlayerPrefs.SetFloat("Panel17Price", price[16]);
        PlayerPrefs.SetFloat("Panel18Price", price[17]);
        PlayerPrefs.SetFloat("Panel19Price", price[18]);
        PlayerPrefs.SetFloat("Panel20Price", price[19]);
        PlayerPrefs.SetFloat("Panel21Price", price[20]);
        PlayerPrefs.Save(); // �����ϱ�
        Debug.Log("Order saved!");

        confirmPanel.SetActive(true);
        
        // ����� ���� �� UI Text�� ǥ��
        DisplaySavedQuantities();

    }

    // �ֹ� ���γ��� �ݱ� X��ư Ŭ����
    public void CloseConfirmClick()
    {
        confirmPanel.SetActive(false);
    }

    // ����� ���� �� UI Text�� ǥ��
    public void DisplaySavedQuantities()
    {
        // ����� ���� �� �ҷ�����
        int panel1Quantity = PlayerPrefs.GetInt("Panel1Quantity", 0);
        int panel2Quantity = PlayerPrefs.GetInt("Panel2Quantity", 0);
        int panel3Quantity = PlayerPrefs.GetInt("Panel3Quantity", 0);
        int panel4Quantity = PlayerPrefs.GetInt("Panel4Quantity", 0);
        int panel5Quantity = PlayerPrefs.GetInt("Panel5Quantity", 0);
        int panel6Quantity = PlayerPrefs.GetInt("Panel6Quantity", 0);
        int panel7Quantity = PlayerPrefs.GetInt("Panel7Quantity", 0);
        int panel8Quantity = PlayerPrefs.GetInt("Panel8Quantity", 0);
        int panel9Quantity = PlayerPrefs.GetInt("Panel9Quantity", 0);
        int panel10Quantity = PlayerPrefs.GetInt("Panel10Quantity", 0);
        int panel11Quantity = PlayerPrefs.GetInt("Panel11Quantity", 0);
        int panel12Quantity = PlayerPrefs.GetInt("Panel12Quantity", 0);
        int panel13Quantity = PlayerPrefs.GetInt("Panel13Quantity", 0);
        int panel14Quantity = PlayerPrefs.GetInt("Panel14Quantity", 0);
        int panel15Quantity = PlayerPrefs.GetInt("Panel15Quantity", 0);
        int panel16Quantity = PlayerPrefs.GetInt("Panel16Quantity", 0);
        int panel17Quantity = PlayerPrefs.GetInt("Panel17Quantity", 0);
        int panel18Quantity = PlayerPrefs.GetInt("Panel18Quantity", 0);
        int panel19Quantity = PlayerPrefs.GetInt("Panel19Quantity", 0);
        int panel20Quantity = PlayerPrefs.GetInt("Panel20Quantity", 0);
        int panel21Quantity = PlayerPrefs.GetInt("Panel21Quantity", 0);

        float panel1Price = PlayerPrefs.GetFloat("Panel1Price", 0);
        float panel2Price = PlayerPrefs.GetFloat("Panel2Price", 0);
        float panel3Price = PlayerPrefs.GetFloat("Panel3Price", 0);
        float panel4Price = PlayerPrefs.GetFloat("Panel4Price", 0);
        float panel5Price = PlayerPrefs.GetFloat("Panel5Price", 0);
        float panel6Price = PlayerPrefs.GetFloat("Panel6Price", 0);
        float panel7Price = PlayerPrefs.GetFloat("Panel7Price", 0);
        float panel8Price = PlayerPrefs.GetFloat("Panel8Price", 0);
        float panel9Price = PlayerPrefs.GetFloat("Panel9Price", 0);
        float panel10Price = PlayerPrefs.GetFloat("Panel10Price", 0);
        float panel11Price = PlayerPrefs.GetFloat("Panel11Price", 0);
        float panel12Price = PlayerPrefs.GetFloat("Panel12Price", 0);
        float panel13Price = PlayerPrefs.GetFloat("Panel13Price", 0);
        float panel14Price = PlayerPrefs.GetFloat("Panel14Price", 0);
        float panel15Price = PlayerPrefs.GetFloat("Panel15Price", 0);
        float panel16Price = PlayerPrefs.GetFloat("Panel16Price", 0);
        float panel17Price = PlayerPrefs.GetFloat("Panel17Price", 0);
        float panel18Price = PlayerPrefs.GetFloat("Panel18Price", 0);
        float panel19Price = PlayerPrefs.GetFloat("Panel19Price", 0);
        float panel20Price = PlayerPrefs.GetFloat("Panel20Price", 0);
        float panel21Price = PlayerPrefs.GetFloat("Panel21Price", 0);

        // ������ ������ ������ �ؽ�Ʈ ����
        string nameResultText = "";
        string quantityResultText = "";
        string priceResultText = "";


        // panel1�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel1Quantity > 0)
        {
            nameResultText += "�̰��� �߰���" + "\n";
            quantityResultText += panel1Quantity + "��" + "\n";
            priceResultText += panel1Quantity * panel1Price + "��" + "\n";
        }

        // panel2�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel2Quantity > 0)
        {
            nameResultText += "ġ��߰���" + "\n";
            quantityResultText += panel2Quantity + "��" + "\n";
            priceResultText += panel2Quantity * panel2Price + "��" + "\n";
        }

        // panel3�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel3Quantity > 0)
        {
            nameResultText += "�����߰���" + "\n";
            quantityResultText += panel3Quantity + "��" + "\n";
            priceResultText += panel3Quantity * panel3Price + "��" + "\n";
        }

        // panel4�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel4Quantity > 0)
        {
            nameResultText += "�޲ٹ̴߰���" + "\n";
            quantityResultText += panel4Quantity + "��" + "\n";
            priceResultText += panel4Quantity * panel4Price + "��" + "\n";
        }
        // panel5�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel5Quantity > 0)
        {
            nameResultText += "�߰���ö�Ǻ�����" + "\n";
            quantityResultText += panel5Quantity + "��" + "\n";
            priceResultText += panel5Quantity * panel5Price + "��" + "\n";
        }
        // panel6�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel6Quantity > 0)
        {
            nameResultText += "�߾�äö�Ǻ�����" + "\n";
            quantityResultText += panel6Quantity + "��" + "\n";
            priceResultText += panel6Quantity * panel6Price + "��" + "\n";
        }
        // panel7�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel7Quantity > 0)
        {
            nameResultText += "ġ��ö�Ǻ�����" + "\n";
            quantityResultText += panel7Quantity + "��" + "\n";
            priceResultText += panel7Quantity * panel7Price + "��" + "\n";
        }
        // panel8�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel8Quantity > 0)
        {
            nameResultText += "��������" + "\n";
            quantityResultText += panel8Quantity + "��" + "\n";
            priceResultText += panel8Quantity * panel8Price + "��" + "\n";
        }
        // panel9�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel9Quantity > 0)
        {
            nameResultText += "��ġ�˺�������" + "\n";
            quantityResultText += panel9Quantity + "��" + "\n";
            priceResultText += panel9Quantity * panel9Price + "��" + "\n";
        }
        // panel10�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel10Quantity > 0)
        {
            nameResultText += "��������" + "\n";
            quantityResultText += panel10Quantity + "��" + "\n";
            priceResultText += panel10Quantity * panel10Price + "��" + "\n";
        }
        // panel11�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel11Quantity > 0)
        {
            nameResultText += "�����������" + "\n";
            quantityResultText += panel11Quantity + "��" + "\n";
            priceResultText += panel11Quantity * panel11Price + "��" + "\n";
        }
        // panel12�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel12Quantity > 0)
        {
            nameResultText += "����̸�" + "\n";
            quantityResultText += panel12Quantity + "��" + "\n";
            priceResultText += panel12Quantity * panel12Price + "��" + "\n";
        }
        // panel13�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel13Quantity > 0)
        {
            nameResultText += "�����ָԹ�" + "\n";
            quantityResultText += panel13Quantity + "��" + "\n";
            priceResultText += panel13Quantity * panel13Price + "��" + "\n";
        }
        // panel14�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel14Quantity > 0)
        {
            nameResultText += "�����" + "\n";
            quantityResultText += panel14Quantity + "��" + "\n";
            priceResultText += panel14Quantity * panel14Price + "��" + "\n";
        }
        // panel15�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel15Quantity > 0)
        {
            nameResultText += "��һ縮" + "\n";
            quantityResultText += panel15Quantity + "��" + "\n";
            priceResultText += panel15Quantity * panel15Price + "��" + "\n";
        }
        // panel16�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel16Quantity > 0)
        {
            nameResultText += "��¥����ġ��" + "\n";
            quantityResultText += panel16Quantity + "��" + "\n";
            priceResultText += panel16Quantity * panel16Price + "��" + "\n";
        }
        // panel17�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel17Quantity > 0)
        {
            nameResultText += "���縮" + "\n";
            quantityResultText += panel17Quantity + "��" + "\n";
            priceResultText += panel17Quantity * panel17Price + "��" + "\n";
        }
        // panel18�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel18Quantity > 0)
        {
            nameResultText += "�쵿�縮" + "\n";
            quantityResultText += panel18Quantity + "��" + "\n";
            priceResultText += panel18Quantity * panel18Price + "��" + "\n";
        }
        // panel19�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel19Quantity > 0)
        {
            nameResultText += "�����̶�" + "\n";
            quantityResultText += panel19Quantity + "��" + "\n";
            priceResultText += panel19Quantity * panel19Price + "��" + "\n";
        }
        // panel20�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel20Quantity > 0)
        {
            nameResultText += "ġ�" + "\n";
            quantityResultText += panel20Quantity + "��" + "\n";
            priceResultText += panel20Quantity * panel20Price + "��" + "\n";
        }
        // panel21�� ������ 0�� �ƴϸ� ��� �ؽ�Ʈ�� �߰�
        if (panel21Quantity > 0)
        {
            nameResultText += "�����" + "\n";
            quantityResultText += panel21Quantity + "��" + "\n";
            priceResultText += panel21Quantity * panel21Price + "��" + "\n";
        }

        // ��� �ؽ�Ʈ�� ��� ���� ������, ����� ������ �ؽ�Ʈ UI�� ���
        if (!string.IsNullOrEmpty(quantityResultText))
        {
            savedNameText.text = nameResultText;
            savedQuantityText.text = quantityResultText;
            savedPriceText.text = priceResultText;
        }
        else
        {
            savedNameText.text = "�ֹ��� �������� �����ϴ�.";
            savedQuantityText.text = " ";
            savedPriceText.text = " ";
        }

    }

    // ����� �� �ҷ�����
    public void LoadPanelValues()
    {
        // ���� �ҷ�����
        if (PlayerPrefs.HasKey("Panel1Quantity"))
        {
            quan[0] = PlayerPrefs.GetInt("Panel1Quantity");
            quantity1.text = quan[0].ToString();
        }

        if (PlayerPrefs.HasKey("Panel2Quantity"))
        {
            quan[1] = PlayerPrefs.GetInt("Panel2Quantity");
            quantity2.text = quan[1].ToString();
        }

        if (PlayerPrefs.HasKey("Panel3Quantity"))
        {
            quan[2] = PlayerPrefs.GetInt("Panel3Quantity");
            quantity3.text = quan[2].ToString();
        }

        if (PlayerPrefs.HasKey("Panel4Quantity"))
        {
            quan[3] = PlayerPrefs.GetInt("Panel4Quantity");
            quantity4.text = quan[3].ToString();
        }
        if (PlayerPrefs.HasKey("Panel5Quantity"))
        {
            quan[4] = PlayerPrefs.GetInt("Panel5Quantity");
            quantity5.text = quan[4].ToString();
        }
        if (PlayerPrefs.HasKey("Panel6Quantity"))
        {
            quan[5] = PlayerPrefs.GetInt("Panel6Quantity");
            quantity6.text = quan[5].ToString();
        }
        if (PlayerPrefs.HasKey("Panel7Quantity"))
        {
            quan[6] = PlayerPrefs.GetInt("Panel7Quantity");
            quantity7.text = quan[6].ToString();
        }
        if (PlayerPrefs.HasKey("Panel8Quantity"))
        {
            quan[7] = PlayerPrefs.GetInt("Panel8Quantity");
            quantity8.text = quan[7].ToString();
        }
        if (PlayerPrefs.HasKey("Panel9Quantity"))
        {
            quan[8] = PlayerPrefs.GetInt("Panel9Quantity");
            quantity9.text = quan[8].ToString();
        }
        if (PlayerPrefs.HasKey("Panel10Quantity"))
        {
            quan[9] = PlayerPrefs.GetInt("Panel10Quantity");
            quantity10.text = quan[9].ToString();
        }
        if (PlayerPrefs.HasKey("Panel11Quantity"))
        {
            quan[10] = PlayerPrefs.GetInt("Panel11Quantity");
            quantity11.text = quan[10].ToString();
        }
        if (PlayerPrefs.HasKey("Panel12Quantity"))
        {
            quan[11] = PlayerPrefs.GetInt("Panel12Quantity");
            quantity12.text = quan[11].ToString();
        }
        if (PlayerPrefs.HasKey("Panel13Quantity"))
        {
            quan[12] = PlayerPrefs.GetInt("Panel13Quantity");
            quantity13.text = quan[12].ToString();
        }
        if (PlayerPrefs.HasKey("Panel14Quantity"))
        {
            quan[13] = PlayerPrefs.GetInt("Panel14Quantity");
            quantity14.text = quan[13].ToString();
        }
        if (PlayerPrefs.HasKey("Panel15Quantity"))
        {
            quan[14] = PlayerPrefs.GetInt("Panel15Quantity");
            quantity15.text = quan[14].ToString();
        }
        if (PlayerPrefs.HasKey("Panel16Quantity"))
        {
            quan[15] = PlayerPrefs.GetInt("Panel16Quantity");
            quantity16.text = quan[15].ToString();
        }
        if (PlayerPrefs.HasKey("Panel17Quantity"))
        {
            quan[16] = PlayerPrefs.GetInt("Panel17Quantity");
            quantity17.text = quan[16].ToString();
        }
        if (PlayerPrefs.HasKey("Panel18Quantity"))
        {
            quan[17] = PlayerPrefs.GetInt("Panel18Quantity");
            quantity18.text = quan[17].ToString();
        }
        if (PlayerPrefs.HasKey("Panel19Quantity"))
        {
            quan[18] = PlayerPrefs.GetInt("Panel19Quantity");
            quantity19.text = quan[18].ToString();
        }
        if (PlayerPrefs.HasKey("Panel20Quantity"))
        {
            quan[19] = PlayerPrefs.GetInt("Panel20Quantity");
            quantity20.text = quan[19].ToString();
        }
        if (PlayerPrefs.HasKey("Panel21Quantity"))
        {
            quan[20] = PlayerPrefs.GetInt("Panel21Quantity");
            quantity21.text = quan[20].ToString();
        }

        // ���� �ҷ�����
        if (PlayerPrefs.HasKey("Panel1Price"))
        {
            price[0] = PlayerPrefs.GetFloat("Panel1Price");
        }

        if (PlayerPrefs.HasKey("Panel2Price"))
        {
            price[1] = PlayerPrefs.GetFloat("Panel2Price");
        }

        if (PlayerPrefs.HasKey("Panel3Price"))
        {
            price[2] = PlayerPrefs.GetFloat("Panel3Price");
        }

        if (PlayerPrefs.HasKey("Panel4Price"))
        {
            price[3] = PlayerPrefs.GetFloat("Panel4Price");
        }
        if (PlayerPrefs.HasKey("Panel5Price"))
        {
            price[4] = PlayerPrefs.GetFloat("Panel5Price");
        }
        if (PlayerPrefs.HasKey("Panel6Price"))
        {
            price[5] = PlayerPrefs.GetFloat("Panel6Price");
        }
        if (PlayerPrefs.HasKey("Panel7Price"))
        {
            price[6] = PlayerPrefs.GetFloat("Panel7Price");
        }
        if (PlayerPrefs.HasKey("Panel8Price"))
        {
            price[7] = PlayerPrefs.GetFloat("Panel8Price");
        }
        if (PlayerPrefs.HasKey("Panel9Price"))
        {
            price[8] = PlayerPrefs.GetFloat("Panel9Price");
        }
        if (PlayerPrefs.HasKey("Panel10Price"))
        {
            price[9] = PlayerPrefs.GetFloat("Panel10Price");
        }
        if (PlayerPrefs.HasKey("Panel11Price"))
        {
            price[10] = PlayerPrefs.GetFloat("Panel11Price");
        }
        if (PlayerPrefs.HasKey("Panel12Price"))
        {
            price[11] = PlayerPrefs.GetFloat("Panel12Price");
        }
        if (PlayerPrefs.HasKey("Panel13Price"))
        {
            price[12] = PlayerPrefs.GetFloat("Panel13Price");
        }
        if (PlayerPrefs.HasKey("Panel14Price"))
        {
            price[13] = PlayerPrefs.GetFloat("Panel14Price");
        }
        if (PlayerPrefs.HasKey("Panel15Price"))
        {
            price[14] = PlayerPrefs.GetFloat("Panel15Price");
        }
        if (PlayerPrefs.HasKey("Panel16Price"))
        {
            price[15] = PlayerPrefs.GetFloat("Panel16Price");
        }
        if (PlayerPrefs.HasKey("Panel17Price"))
        {
            price[16] = PlayerPrefs.GetFloat("Panel17Price");
        }
        if (PlayerPrefs.HasKey("Panel18Price"))
        {
            price[17] = PlayerPrefs.GetFloat("Panel18Price");
        }
        if (PlayerPrefs.HasKey("Panel19Price"))
        {
            price[18] = PlayerPrefs.GetFloat("Panel19Price");
        }
        if (PlayerPrefs.HasKey("Panel20Price"))
        {
            price[19] = PlayerPrefs.GetFloat("Panel20Price");
        }
        if (PlayerPrefs.HasKey("Panel21Price"))
        {
            price[20] = PlayerPrefs.GetFloat("Panel21Price");
        }
    }


    // �г� ��Ȱ��ȭ
    public void panelSetfalse()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);
        panel6.SetActive(false);
        panel7.SetActive(false);
        panel8.SetActive(false);
        panel9.SetActive(false);
        panel10.SetActive(false);
        panel11.SetActive(false);
        panel12.SetActive(false);
        panel13.SetActive(false);
        panel14.SetActive(false);
        panel15.SetActive(false);
        panel16.SetActive(false);
        panel17.SetActive(false);
        panel18.SetActive(false);
        panel19.SetActive(false);
        panel20.SetActive(false);
        panel21.SetActive(false);
    }
    

    // ���� ���� ��/ ����ȭ������ �Ѿ �� panel�ʱ�ȭ
    public void panelToZero()
    {
        XbuttonClick00(panel1);
        XbuttonClick01(panel2);
        XbuttonClick02(panel3);
        XbuttonClick03(panel4);
        XbuttonClick04(panel5);
        XbuttonClick05(panel6);
        XbuttonClick06(panel7);
        XbuttonClick07(panel8);
        XbuttonClick08(panel9);
        XbuttonClick09(panel10);
        XbuttonClick10(panel11);
        XbuttonClick11(panel12);
        XbuttonClick12(panel13);
        XbuttonClick13(panel14);
        XbuttonClick14(panel15);
        XbuttonClick15(panel16);
        XbuttonClick16(panel17);
        XbuttonClick17(panel18);
        XbuttonClick18(panel19);
        XbuttonClick19(panel20);
        XbuttonClick20(panel21);
    }

    // ���� ���� �� PlayerPrefs �ʱ�ȭ
    public void P_PrefsDelete()
    {
        // �޼���� ���� UImanager���� ������ �� �ֵ���.
        PlayerPrefs.DeleteAll();  // ��� PlayerPrefs ������ ����
    }


    // ����ȭ������ �Ѿ��.
    public void GotoPayment()
    {
        boxC[0].enabled = false;
        boxC[1].enabled = false;
        paymentPanel.SetActive(true);
        creditCard.SetActive(true);
    }


    // ����ȭ�� ����ϱ�.
    public void ClosePayment()
    {
        boxC[0].enabled = true;
        boxC[1].enabled = true;
        paymentPanel.SetActive(false);
        creditCard.SetActive(false);
    }

}
