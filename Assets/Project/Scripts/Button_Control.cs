using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject panelHere;
    public GameObject panelCard;
    public GameObject panelCharge;

    bool startSwitch;
    bool teaselectSwitch;
    bool foodselectSwitch;

    public GameObject textPrefab; // �ؽ�Ʈ�� ��ư�� ���Ե� ������
    public Text[] menuCountTexts; // �޴� ������ ǥ���� �ؽ�Ʈ �迭
    public Text[] leftTextFields; // �ٸ� �гο� �ִ� LeftText �ؽ�Ʈ �迭
    public Text[] rightTextFields; // �ٸ� �гο� �ִ� RightText �ؽ�Ʈ �迭
    public List<Text> totalPriceTexts; // �� ������ ǥ���� �ؽ�Ʈ �迭
    public Text selectedOptionsText; // ������ �ɼ��� ǥ���� �ؽ�Ʈ
    public Text totalOptionPriceText; // �� �ɼ� ������ ǥ���� �ؽ�Ʈ

    private List<GameObject> orderItems = new List<GameObject>(); // ������ �ؽ�Ʈ UI ���� ����Ʈ
    private List<Text> leftTextList = new List<Text>(); // �������� ������ LeftText ����Ʈ
    private List<Text> rightTextList = new List<Text>(); // �������� ������ RightText ����Ʈ
    private List<string> currentOptions = new List<string>(); // �߰��� �ɼ� �̸� ����Ʈ
    private int totalPrice = 0; // �� ����
    private int currentOptionPrice = 0; // ���� ���õ� �ɼ��� �� ����
    private int totalMenuCount = 0; // �޴��� �� ����

    public string currentMenuName; // ���� ���õ� �޴� �̸�
    public int currentMenuPrice; // ���� ���õ� �޴� ����

    public Transform contentParentMain;  // ���� �г��� Content Parent
    public Transform contentParentOther; // �ٸ� �г��� Content Parent

    public GameObject card;

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
        panelHere = GameObject.Find("Panel(HereTogo)");
        panelHere.SetActive(false);
        panelCard = GameObject.Find("Panel(CardorCash)");
        panelCard.SetActive(false);
        panelCharge = GameObject.Find("Panel(Charge)");
        panelCharge.SetActive(false);

        orderItems.Clear();
        totalPrice = 0;

        card = GameObject.Find("Card");
        card.SetActive(false);
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
        if (panelMain.activeSelf == true && teaselectSwitch == false && panelTea.activeSelf == true)
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

        // �ֹ� ����Ʈ ����
        orderItems.Clear();
        leftTextList.Clear();
        rightTextList.Clear();

        // ȭ�鿡�� �ֹ� �׸� ����
        foreach (Transform child in contentParentMain)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in contentParentOther)
        {
            Destroy(child.gameObject);
        }

        // ������ �ʱ�ȭ
        totalPrice = 0;
        totalMenuCount = 0;
        currentOptionPrice = 0;
        currentOptions.Clear();

        // UI �ʱ�ȭ
        UpdateTotalPrice();
        UpdateMenuCountText();
        UpdateMenuUI();
    }
    public void CoffeeMenu()
    {
        panelCoffee.SetActive(true);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        panelFood.SetActive(false);
        teaselectSwitch = false;
        foodselectSwitch = false;
    }
    public void TeaMenu()
    {
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelTea.SetActive(true);
        panelTeamenu.SetActive(true);
        panelFood.SetActive(false);
        startSwitch = false;
        foodselectSwitch = false;
    }
    public void FoodMenu()
    {
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
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
        OptionOpen();
        currentMenuPrice = 2000;
        currentMenuName = "�Ƹ޸�ī��";
        ResetOptions();
    }
    public void Coldbrew()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "�ݵ���";
        ResetOptions();
    }
    public void Espresso()
    {
        OptionOpen();
        currentMenuPrice = 1500;
        currentMenuName = "����������";
        ResetOptions();
    }
    public void Caffelatte()
    {
        OptionOpen();
        currentMenuPrice = 2900;
        currentMenuName = "ī���";
        ResetOptions();
    }
    public void Cafemocha()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "ī���ī";
        ResetOptions();
    }
    public void Cappuccino()
    {
        OptionOpen();
        currentMenuPrice = 2900;
        currentMenuName = "īǪġ��";
        ResetOptions();
    }
    public void Caramelmacchiato()
    {
        OptionOpen();
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
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        panelCard.SetActive(false);
        panelHere.SetActive(false);
        panelStart.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelCharge.SetActive(false);
        card.SetActive(false);
    }
    public void Icetea()
    {
        OptionOpen();
        currentMenuPrice = 3000;
        currentMenuName = "���̽�Ƽ";
        ResetOptions();
    }
    public void Chamomile()
    {
        OptionOpen();
        currentMenuPrice = 2500;
        currentMenuName = "ĳ����";
        ResetOptions();
    }
    public void Peppermint()
    {
        OptionOpen();
        currentMenuPrice = 2500;
        currentMenuName = "���۹�Ʈ";
        ResetOptions();
    }
    public void Citron()
    {
        OptionOpen();
        currentMenuPrice = 3300;
        currentMenuName = "����";
        ResetOptions();
    }
    public void Grapefruit()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "�ڸ����̵�";
        ResetOptions();
    }
    public void Whitegrape()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "û�������̵�";
        ResetOptions();
    }
    public void Lemon()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "�����̵�";
        ResetOptions();
    }
    public void Chocolatte()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "���ڶ�";
        ResetOptions();
    }
    public void Strawberrylatte()
    {
        OptionOpen();
        currentMenuPrice = 3700;
        currentMenuName = "�����";
        ResetOptions();
    }
    public void Grainlatte()
    {
        OptionOpen();
        currentMenuPrice = 3000;
        currentMenuName = "���";
        ResetOptions();
    }
    public void Greentealatte()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "������";
        ResetOptions();
    }
    public void Sweetpotatolatte()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "������";
        ResetOptions();
    }
    public void Strawberrysmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "���⽺����";
        ResetOptions();
    }
    public void Blueberrysmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "��纣��������";
        ResetOptions();
    }
    public void Planesmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "�÷��ν�����";
        ResetOptions();
    }
    public void Mangosmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "��������";
        ResetOptions();
    }
    public void Cookiefrappe()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "��Ű������";
        ResetOptions();
    }
    public void Chocofrappe()
    {
        OptionOpen();
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
        panelTea.SetActive(false);
        panelFood.SetActive(false);
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
    public void Payment()
    {
        panelHere.SetActive(true);
        panelMain.SetActive(false);
        panelStart.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);
    }
    public void Back()
    {
        panelHere.SetActive(false);
        panelMain.SetActive(true);
        panelStart.SetActive(false);
        panelCoffee.SetActive(true);
        panelCoffeemenu.SetActive(true);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);
    }
    public void Here()
    {
        panelCard.SetActive(true);
        panelHere.SetActive(false);
        panelMain.SetActive(false);
        panelStart.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);
    }
    public void Togo()
    {
        panelCard.SetActive(true);
        panelHere.SetActive(false);
        panelMain.SetActive(false);
        panelStart.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);
    }
    public void Gifticon()
    {
        panelCard.SetActive(false);
        panelHere.SetActive(false);
        panelMain.SetActive(false);
        panelStart.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);
        panelCharge.SetActive(true);
    }
    public void Card()
    {
        panelCard.SetActive(false);
        panelHere.SetActive(false);
        panelMain.SetActive(false);
        panelStart.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelOption.SetActive(false);
        panelCharge.SetActive(true);
        card.SetActive(true);
    }
    public void Cardcharge()
    {
        SceneManager.LoadScene("ENDScene");
    }
    //000
    void AddOrder(string menuName, int price)
    {
        // ���� �޴� ���� ������Ʈ
        currentMenuName = menuName;
        currentMenuPrice = price;

        // ������ ���� (������ contentParent�� ����)
        GameObject newItemMainPanel = Instantiate(textPrefab, contentParentMain);
        GameObject newItemOtherPanel = Instantiate(textPrefab, contentParentOther);

        // �ؽ�Ʈ UI ����
        Text leftTextMain = newItemMainPanel.transform.Find("LeftText").GetComponent<Text>();
        Text rightTextMain = newItemMainPanel.transform.Find("RightText").GetComponent<Text>();

        Text leftTextOther = newItemOtherPanel.transform.Find("LeftText").GetComponent<Text>();
        Text rightTextOther = newItemOtherPanel.transform.Find("RightText").GetComponent<Text>();

        leftTextMain.text = menuName;
        rightTextMain.text = price.ToString();

        leftTextOther.text = menuName;
        rightTextOther.text = price.ToString();

        // ��ġ �� ũ�� ���� (�� ��° �гο�����)
        RectTransform rectTransformOther = newItemOtherPanel.GetComponent<RectTransform>();
        rectTransformOther.anchoredPosition = new Vector2(100f, 0f); // ���÷� X = 100, Y = 0 ��ġ
        rectTransformOther.sizeDelta = new Vector2(300f, 50f); // ũ�� ����: 300x50

        // ����Ʈ�� �߰�
        orderItems.Add(newItemMainPanel);
        orderItems.Add(newItemOtherPanel);

        // ���� ��ư �̺�Ʈ ���� (����ȭ)
        Button removeButtonMain = newItemMainPanel.transform.Find("RemoveButton").GetComponent<Button>();
        removeButtonMain.onClick.AddListener(() => RemoveOrder(newItemMainPanel, newItemOtherPanel, price));

        Button removeButtonOther = newItemOtherPanel.transform.Find("RemoveButton").GetComponent<Button>();
        removeButtonOther.onClick.AddListener(() => RemoveOrder(newItemOtherPanel, newItemMainPanel, price));

        // �ݶ��̴� �߰� (VR���� Ŭ�� �����ϰ� ����)
        BoxCollider colliderMain = removeButtonMain.gameObject.AddComponent<BoxCollider>();
        colliderMain.size = new Vector3(30f, 30f, 3f);

        BoxCollider colliderOther = removeButtonOther.gameObject.AddComponent<BoxCollider>();
        colliderOther.size = new Vector3(30f, 30f, 3f);

        // ���� �� �޴� ���� ������Ʈ
        totalPrice += price;
        totalMenuCount++;

        // UI ����
        UpdateTotalPrice();
        UpdateMenuCountText();
    }

    private void AddOption(string optionName, int price)
    {
        if (!currentOptions.Contains(optionName)) // �ߺ� �ɼ� ����
        {
            currentOptions.Add(optionName);
            currentOptionPrice += price;

            // �ؽ�Ʈ UI ������Ʈ
            UpdateSelectedOptionsText();
            UpdateTotalOptionPriceText();
        }
        else
        {
            Debug.Log($"�ɼ� '{optionName}'�� �̹� �߰��Ǿ����ϴ�.");
        }
    }
    void UpdateMenuCountText()
    {
        // �޴� ������ ���� �гο��� ����ȭ
        foreach (Text text in menuCountTexts)
        {
            text.text = totalMenuCount.ToString();
        }
    }

    private void UpdateSelectedOptionsText()
    {
        // �ɼ� ����� ���ڿ��� ��ȯ�Ͽ� �ؽ�Ʈ UI�� ǥ��
        string optionsSummary = string.Join(", ", currentOptions);
        selectedOptionsText.text = $"{optionsSummary}";
    }

    private void UpdateTotalOptionPriceText()
    {
        // �� �ɼ� ������ �ؽ�Ʈ UI�� ǥ��
        totalOptionPriceText.text = $"{currentOptionPrice}";
    }

    void RemoveOrder(GameObject orderItem, GameObject syncedOrderItem, int price)
    {
        // ����Ʈ���� ����
        orderItems.Remove(orderItem);
        orderItems.Remove(syncedOrderItem);

        // UI ������Ʈ ����
        Destroy(orderItem);
        Destroy(syncedOrderItem);

        // ���� �� �޴� ���� ������Ʈ
        totalPrice -= price;
        totalMenuCount--;

        // UI ����
        UpdateTotalPrice();
        UpdateMenuCountText();
    }
    private void UpdateMenuUI()
    {
        // �� �г��� �׸��� ��� ������ �� ����ȭ
        foreach (Transform child in contentParentMain)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in contentParentOther)
        {
            Destroy(child.gameObject);
        }

        // orderItems ����Ʈ�� ������� ����ȭ�� �׸� ����
        for (int i = 0; i < orderItems.Count; i += 2)
        {
            GameObject orderItemMainPanel = orderItems[i];  // ù ��° �г��� �׸�
            GameObject orderItemOtherPanel = orderItems[i + 1];  // �� ��° �г��� �׸�

            // ù ��° �г� �׸��� �����ϰ� �ؽ�Ʈ ����
            GameObject newItemMainPanel = Instantiate(orderItemMainPanel, contentParentMain);
            Text leftTextMain = newItemMainPanel.transform.Find("LeftText").GetComponent<Text>();
            Text rightTextMain = newItemMainPanel.transform.Find("RightText").GetComponent<Text>();
            leftTextMain.text = orderItemMainPanel.transform.Find("LeftText").GetComponent<Text>().text;
            rightTextMain.text = orderItemMainPanel.transform.Find("RightText").GetComponent<Text>().text;

            // �� ��° �г� �׸��� �����ϰ� �ؽ�Ʈ ����
            GameObject newItemOtherPanel = Instantiate(orderItemOtherPanel, contentParentOther);
            Text leftTextOther = newItemOtherPanel.transform.Find("LeftText").GetComponent<Text>();
            Text rightTextOther = newItemOtherPanel.transform.Find("RightText").GetComponent<Text>();
            leftTextOther.text = orderItemOtherPanel.transform.Find("LeftText").GetComponent<Text>().text;
            rightTextOther.text = orderItemOtherPanel.transform.Find("RightText").GetComponent<Text>().text;

            // ���� ��ư �ٽ� ����
            Button removeButtonMain = newItemMainPanel.transform.Find("RemoveButton").GetComponent<Button>();
            removeButtonMain.onClick.AddListener(() => RemoveOrder(newItemMainPanel, newItemOtherPanel, int.Parse(rightTextMain.text)));

            Button removeButtonOther = newItemOtherPanel.transform.Find("RemoveButton").GetComponent<Button>();
            removeButtonOther.onClick.AddListener(() => RemoveOrder(newItemOtherPanel, newItemMainPanel, int.Parse(rightTextOther.text)));
        }
    }

    void ResetCurrentSelections()
    {
        currentOptionPrice = 0;
        currentOptions.Clear(); // ���õ� �ɼ� �ʱ�ȭ
    }

    void UpdateTotalPrice()
    {
        foreach (Text text in totalPriceTexts)
        {
            text.text = totalPrice.ToString();
        }
    }

    public void ResetOptions()
    {
        // �ɼ� ����Ʈ�� �� ���� �ʱ�ȭ
        currentOptions.Clear();
        currentOptionPrice = 0;

        // �ؽ�Ʈ UI �ʱ�ȭ
        UpdateSelectedOptionsText();
        UpdateTotalOptionPriceText();
    }
    public void ResetOrders()
    {
        // �ֹ� ����Ʈ ����
        orderItems.Clear();
        leftTextList.Clear();
        rightTextList.Clear();

        // ȭ�鿡�� �ֹ� �׸� ����
        foreach (Transform child in contentParentMain)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in contentParentOther)
        {
            Destroy(child.gameObject);
        }

        // ������ �ʱ�ȭ
        totalPrice = 0;
        totalMenuCount = 0;
        currentOptionPrice = 0;
        currentOptions.Clear();

        // UI �ʱ�ȭ
        UpdateTotalPrice();
        UpdateMenuCountText();
        UpdateMenuUI();
    }
    void OptionOpen()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelCard.SetActive(false);
        panelHere.SetActive(false);
        panelStart.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
    }
}

