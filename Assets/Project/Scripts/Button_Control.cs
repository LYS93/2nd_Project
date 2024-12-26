using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Control : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelMain;
    public GameObject panelCoffee;
    public GameObject panelTea;
    public GameObject panelFood;
    public GameObject panelCoffeemenu;
    public GameObject panelLattemenu;
    public GameObject panelTeamenu;
    public GameObject panelAdemenu;
    public GameObject panelNonCoffeemenu;
    public GameObject panelFrappemenu;
    public GameObject panelFoodmenu;
    public GameObject panelOption;

    bool startSwitch;
    bool teaselectSwitch;
    bool foodselectSwitch;

    public GameObject textPrefab; // �ؽ�Ʈ�� ��ư�� ���Ե� ������
    public Transform contentParent; // �������� ������ �θ� ������Ʈ (ScrollView�� Content)
    private List<GameObject> orderItems = new List<GameObject>(); // ������ �ؽ�Ʈ UI ���� ����Ʈ

    private int totalPrice = 0;
    private int currentOptionPrice = 0;
    private int currentMenuPrice = 0;
    private string currentMenuName = "";
    private List<string> currentOptions = new List<string>(); // �߰��� �ɼ� �̸� ����Ʈ

    void Start()
    {
        panelStart = GameObject.Find("Panel(start)");
        panelStart.SetActive(true);
        panelMain = GameObject.Find("Panel(MainScreen)");
        panelMain.SetActive(false);
        panelCoffee = GameObject.Find("Panel(CoffeeLatteSelect)");
        panelCoffee.SetActive(false);
        panelTea = GameObject.Find("Panel(TeaAdeSelect)");
        panelTea.SetActive(false);
        panelFood = GameObject.Find("Panel(FoodSelect)");
        panelFood.SetActive(false);
        panelCoffeemenu = GameObject.Find("Panel(CoffeeMenu)");
        panelCoffeemenu.SetActive(false);
        panelLattemenu = GameObject.Find("Panel(LatteMenu)");
        panelLattemenu.SetActive(false);
        panelTeamenu = GameObject.Find("Panel(TeaMenu)");
        panelTeamenu.SetActive(false);
        panelAdemenu = GameObject.Find("Panel(AdeMenu)");
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu = GameObject.Find("Panel(NonCoffeeLatteMenu)");
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu = GameObject.Find("Panel(FrappeMenu)");
        panelFrappemenu.SetActive(false);
        panelFoodmenu = GameObject.Find("Panel(FoodMenu)");
        panelFoodmenu.SetActive(false);
        panelOption = GameObject.Find("Panel(Option)");
        panelOption.SetActive(false);

        GameObject.Find("TotalPriceText").GetComponent<Text>().text = "";
        orderItems.Clear();
        totalPrice = 0;
    }

    
    void Update()
    {
        if (panelMain.activeSelf == true && startSwitch == false && panelCoffee.activeSelf == true)
        {
            panelCoffeemenu.SetActive(true);
            panelLattemenu.SetActive(false);
            panelTeamenu.SetActive(false);
            panelAdemenu.SetActive(false);
            panelNonCoffeemenu.SetActive(false);
            panelFrappemenu.SetActive(false);
            panelFoodmenu.SetActive(false);
            startSwitch = true;
        }
        if(panelMain.activeSelf == true && teaselectSwitch == false && panelTea.activeSelf == true)
        {
            panelCoffeemenu.SetActive(false);
            panelLattemenu.SetActive(false);
            panelTeamenu.SetActive(true);
            panelAdemenu.SetActive(false);
            panelNonCoffeemenu.SetActive(false);
            panelFrappemenu.SetActive(false);
            panelFoodmenu.SetActive(false);
            teaselectSwitch = true;
        }
        if (panelMain.activeSelf == true && foodselectSwitch == false && panelFood.activeSelf == true)
        {
            panelCoffeemenu.SetActive(false);
            panelLattemenu.SetActive(false);
            panelTeamenu.SetActive(false);
            panelAdemenu.SetActive(false);
            panelNonCoffeemenu.SetActive(false);
            panelFrappemenu.SetActive(false);
            panelFoodmenu.SetActive(true);
            foodselectSwitch = true;
        }        
    }
    public void Restart() //����ȭ������ ���ư��� ��ư
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Quit() //���α׷� �����ư
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void StartMainScreen()
    {
        panelMain.SetActive(true);
        panelStart.SetActive(false);
        panelCoffee.SetActive(true);
    }
    public void Gostart()
    {
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelStart.SetActive(true);
        startSwitch = false;
    }
    public void CoffeeMenu()
    {
        panelCoffee.SetActive(true);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        teaselectSwitch = false;
        foodselectSwitch = false;
    }
    public void TeaMenu()
    {
        panelCoffee.SetActive(false);
        panelTea.SetActive(true);
        panelFood.SetActive(false);
        startSwitch = false;
        foodselectSwitch = false;
    }
    public void FoodMenu()
    {
        panelCoffee.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(true);
        panelFoodmenu.SetActive(true);
        startSwitch = false;
        teaselectSwitch = false;
    }
    public void CoffeeOpen()
    {
        panelCoffeemenu.SetActive(true);
        panelLattemenu.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
    }
    public void LatteOpen()
    {
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(true);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
    }
    public void TeaOpen()
    {
        panelTeamenu.SetActive(true);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
    }
    public void AdeOpen()
    {
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(true);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
    }
    public void NonCoffeeOpen()
    {
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(true);
        panelFrappemenu.SetActive(false);
    }
    public void FrappeOpen()
    {
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(true);
    }
    public void Americano()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 2000;
        currentMenuName = "�Ƹ޸�ī��";
        ResetOptions();
    }
    public void Coldbrew()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "�ݵ���";
        ResetOptions();
    }
    public void Espresso()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 1500;
        currentMenuName = "����������";
        ResetOptions();
    }
    public void Caffelatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 2900;
        currentMenuName = "ī���";
        ResetOptions();
    }
    public void Cafemocha()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 390;
        currentMenuName = "ī���ī";
        ResetOptions();
    }
    public void Cappuccino()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 2900;
        currentMenuName = "īǪġ��";
        ResetOptions();
    }
    public void Caramelmacchiato()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 3700;
        currentMenuName = "ī��Ḷ���ƶ�";
        ResetOptions();
    }
    public void Off()
    {
        panelOption.SetActive(false);
        panelMain.SetActive(true);
        panelCoffee.SetActive(true);
        panelCoffeemenu.SetActive(true);
    }
    public void Icetea()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3000;
        currentMenuName = "���̽�Ƽ";
        ResetOptions();
    }
    public void Chamomile()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 2500;
        currentMenuName = "ĳ����";
        ResetOptions();
    }
    public void Peppermint()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 2500;
        currentMenuName = "���۹�Ʈ";
        ResetOptions();
    }
    public void Citron()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3300;
        currentMenuName = "����";
        ResetOptions();
    }
    public void Grapefruit()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "�ڸ����̵�";
        ResetOptions();
    }
    public void Whitegrape()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "û�������̵�";
        ResetOptions();
    }
    public void Lemon()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "�����̵�";
        ResetOptions();
    }
    public void Chocolatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "���ڶ�";
        ResetOptions();
    }
    public void Strawberrylatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3700;
        currentMenuName = "�����";
        ResetOptions();
    }
    public void Grainlatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3000;
        currentMenuName = "���";
        ResetOptions();
    }
    public void Greentealatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "������";
        ResetOptions();
    }
    public void Sweetpotatolatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "������";
        ResetOptions();
    }
    public void Strawberrysmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "���⽺����";
        ResetOptions();
    }
    public void Blueberrysmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "��纣��������";
        ResetOptions();
    }
    public void Planesmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "�÷��ν�����";
        ResetOptions();
    }
    public void Mangosmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "��������";
        ResetOptions();
    }
    public void Cookiefrappe()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "��Ű������";
        ResetOptions();
    }
    public void Chocofrappe()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "����������";
        ResetOptions();
    }
    public void Planebagle()
    {
        currentMenuPrice = 3000;
        currentMenuName = "�÷��κ��̱�";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Chococake()
    {
        currentMenuPrice = 4500;
        currentMenuName = "��������ũ";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Milkcake()
    {
        currentMenuPrice = 4500;
        currentMenuName = "��������ũ";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Croquemonsieur()
    {
        currentMenuPrice = 3900;
        currentMenuName = "ũ��ũ����";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Croiffle()
    {
        currentMenuPrice = 3000;
        currentMenuName = "ũ����";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Honeybread()
    {
        currentMenuPrice = 5400;
        currentMenuName = "��Ϻ극��";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Tumbler()
    {
        AddOption("�Һ�", 0);
    }
    public void Mild()
    {
        AddOption("���ϰ�", 0);
    }
    public void Shot()
    {
        AddOption("���߰�", 500);
    }
    public void Cream()
    {
        AddOption("�����߰�", 700);
    }
    public void Order()
    {
        panelMain.SetActive(true);
        panelStart.SetActive(false);
        panelCoffee.SetActive(true);
        panelCoffeemenu.SetActive(true);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);

        int finalPrice = currentMenuPrice + currentOptionPrice;

        // �޴� �̸��� �ɼ� ����
        string finalMenuName = currentMenuName;
        if (currentOptions.Count > 0)
        {
            finalMenuName += $" ({string.Join(", ", currentOptions)})";
        }

        AddOrder(finalMenuName, finalPrice);
        ResetCurrentSelections(); // ���� ���� �ʱ�ȭ
    }
    public void Resetoption()
    {
        Debug.Log("option");
    }
    void AddOrder(string menuName, int price)
    {
        // ������ ����
        GameObject newItem = Instantiate(textPrefab, contentParent);

        // �ؽ�Ʈ UI ����
        Text leftText = newItem.transform.Find("LeftText").GetComponent<Text>();
        Text rightText = newItem.transform.Find("RightText").GetComponent<Text>();

        leftText.text = menuName;
        rightText.text = price.ToString();

        // ���� ��ư �̺�Ʈ ����
        Button removeButton = newItem.transform.Find("RemoveButton").GetComponent<Button>();
        removeButton.onClick.AddListener(() => RemoveOrderButton(newItem)); // ������ ������Ʈ ����

        // �ݶ��̴� �߰� (VR���� Ŭ�� �����ϰ� ����)
        removeButton.gameObject.AddComponent<BoxCollider>(); // ��ư�� �ݶ��̴� �߰�

        // �ֹ� ����Ʈ�� �߰�
        orderItems.Add(newItem);
        totalPrice += price;
        UpdateTotalPrice();
    }

    void AddOption(string optionName, int price)
    {
        if (!currentOptions.Contains(optionName)) // �ߺ� �ɼ� ����
        {
            currentOptions.Add(optionName);
            currentOptionPrice += price;
        }
        else
        {
            Debug.Log($"�ɼ� '{optionName}'�� �̹� �߰��Ǿ����ϴ�.");
        }
    }

    public void RemoveOrderButton(GameObject orderItem)
    {
        // ������ �׸��� ���� ��������
        int price = int.Parse(orderItem.transform.Find("RightText").GetComponent<Text>().text);

        // �� ���ݿ��� ����
        totalPrice -= price;

        // �ֹ� �׸� ����Ʈ���� ����
        orderItems.Remove(orderItem);

        // UI ������Ʈ ����
        Destroy(orderItem);

        // �� ���� UI ����
        UpdateTotalPrice();
    }

    void ResetCurrentSelections()
    {
        currentOptionPrice = 0;
        currentOptions.Clear(); // ���õ� �ɼ� �ʱ�ȭ
    }

    void UpdateTotalPrice()
    {
        GameObject.Find("TotalPriceText").GetComponent<Text>().text = totalPrice.ToString();
    }

    void ResetOptions()
    {
        currentOptions.Clear();
        currentOptionPrice = 0;
    }
}

