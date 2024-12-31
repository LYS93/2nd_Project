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

    public GameObject textPrefab; // 텍스트와 버튼이 포함된 프리팹
    public Text[] menuCountTexts; // 메뉴 갯수를 표시할 텍스트 배열
    public Text[] leftTextFields; // 다른 패널에 있는 LeftText 텍스트 배열
    public Text[] rightTextFields; // 다른 패널에 있는 RightText 텍스트 배열
    public List<Text> totalPriceTexts; // 총 가격을 표시할 텍스트 배열
    public Text selectedOptionsText; // 선택한 옵션을 표시할 텍스트
    public Text totalOptionPriceText; // 총 옵션 가격을 표시할 텍스트

    private List<GameObject> orderItems = new List<GameObject>(); // 생성된 텍스트 UI 저장 리스트
    private List<Text> leftTextList = new List<Text>(); // 동적으로 생성된 LeftText 리스트
    private List<Text> rightTextList = new List<Text>(); // 동적으로 생성된 RightText 리스트
    private List<string> currentOptions = new List<string>(); // 추가된 옵션 이름 리스트
    private int totalPrice = 0; // 총 가격
    private int currentOptionPrice = 0; // 현재 선택된 옵션의 총 가격
    private int totalMenuCount = 0; // 메뉴의 총 갯수

    public string currentMenuName; // 현재 선택된 메뉴 이름
    public int currentMenuPrice; // 현재 선택된 메뉴 가격

    public Transform contentParentMain;  // 메인 패널의 Content Parent
    public Transform contentParentOther; // 다른 패널의 Content Parent

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
    public void Restart() //시작화면으로 돌아가는 버튼
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Quit() //프로그램 종료버튼
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

        // 주문 리스트 비우기
        orderItems.Clear();
        leftTextList.Clear();
        rightTextList.Clear();

        // 화면에서 주문 항목 삭제
        foreach (Transform child in contentParentMain)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in contentParentOther)
        {
            Destroy(child.gameObject);
        }

        // 데이터 초기화
        totalPrice = 0;
        totalMenuCount = 0;
        currentOptionPrice = 0;
        currentOptions.Clear();

        // UI 초기화
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
        currentMenuName = "아메리카노";
        ResetOptions();
    }
    public void Coldbrew()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "콜드브루";
        ResetOptions();
    }
    public void Espresso()
    {
        OptionOpen();
        currentMenuPrice = 1500;
        currentMenuName = "에스프레소";
        ResetOptions();
    }
    public void Caffelatte()
    {
        OptionOpen();
        currentMenuPrice = 2900;
        currentMenuName = "카페라떼";
        ResetOptions();
    }
    public void Cafemocha()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "카페모카";
        ResetOptions();
    }
    public void Cappuccino()
    {
        OptionOpen();
        currentMenuPrice = 2900;
        currentMenuName = "카푸치노";
        ResetOptions();
    }
    public void Caramelmacchiato()
    {
        OptionOpen();
        currentMenuPrice = 3700;
        currentMenuName = "카라멜마끼아또";
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
        currentMenuName = "아이스티";
        ResetOptions();
    }
    public void Chamomile()
    {
        OptionOpen();
        currentMenuPrice = 2500;
        currentMenuName = "캐모마일";
        ResetOptions();
    }
    public void Peppermint()
    {
        OptionOpen();
        currentMenuPrice = 2500;
        currentMenuName = "페퍼민트";
        ResetOptions();
    }
    public void Citron()
    {
        OptionOpen();
        currentMenuPrice = 3300;
        currentMenuName = "유자";
        ResetOptions();
    }
    public void Grapefruit()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "자몽에이드";
        ResetOptions();
    }
    public void Whitegrape()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "청포도에이드";
        ResetOptions();
    }
    public void Lemon()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "레몬에이드";
        ResetOptions();
    }
    public void Chocolatte()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "초코라떼";
        ResetOptions();
    }
    public void Strawberrylatte()
    {
        OptionOpen();
        currentMenuPrice = 3700;
        currentMenuName = "딸기라떼";
        ResetOptions();
    }
    public void Grainlatte()
    {
        OptionOpen();
        currentMenuPrice = 3000;
        currentMenuName = "곡물라떼";
        ResetOptions();
    }
    public void Greentealatte()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "녹차라떼";
        ResetOptions();
    }
    public void Sweetpotatolatte()
    {
        OptionOpen();
        currentMenuPrice = 3500;
        currentMenuName = "고구마라떼";
        ResetOptions();
    }
    public void Strawberrysmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "딸기스무디";
        ResetOptions();
    }
    public void Blueberrysmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "블루베리스무디";
        ResetOptions();
    }
    public void Planesmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "플레인스무디";
        ResetOptions();
    }
    public void Mangosmoothie()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "망고스무디";
        ResetOptions();
    }
    public void Cookiefrappe()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "쿠키프라페";
        ResetOptions();
    }
    public void Chocofrappe()
    {
        OptionOpen();
        currentMenuPrice = 3900;
        currentMenuName = "초코프라페";
        ResetOptions();
    }
    public void Planebagle()
    {
        currentMenuPrice = 3000;
        currentMenuName = "플레인베이글";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Chococake()
    {
        currentMenuPrice = 4500;
        currentMenuName = "초코케이크";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Milkcake()
    {
        currentMenuPrice = 4500;
        currentMenuName = "우유케이크";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Croquemonsieur()
    {
        currentMenuPrice = 3900;
        currentMenuName = "크로크무슈";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Croiffle()
    {
        currentMenuPrice = 3000;
        currentMenuName = "크로플";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Honeybread()
    {
        currentMenuPrice = 5400;
        currentMenuName = "허니브레드";
        ResetOptions();
        AddOrder(currentMenuName, currentMenuPrice);
    }
    public void Tumbler()
    {
        AddOption("텀블러", 0);
    }
    public void Mild()
    {
        AddOption("연하게", 0);
    }
    public void Shot()
    {
        AddOption("샷추가", 500);
    }
    public void Cream()
    {
        AddOption("휘핑추가", 700);
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

        // 메뉴 이름과 옵션 결합
        string finalMenuName = currentMenuName;
        if (currentOptions.Count > 0)
        {
            finalMenuName += $" ({string.Join(", ", currentOptions)})";
        }

        AddOrder(finalMenuName, finalPrice);
        ResetCurrentSelections(); // 현재 선택 초기화
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
        // 현재 메뉴 정보 업데이트
        currentMenuName = menuName;
        currentMenuPrice = price;

        // 프리팹 생성 (공유된 contentParent에 생성)
        GameObject newItemMainPanel = Instantiate(textPrefab, contentParentMain);
        GameObject newItemOtherPanel = Instantiate(textPrefab, contentParentOther);

        // 텍스트 UI 설정
        Text leftTextMain = newItemMainPanel.transform.Find("LeftText").GetComponent<Text>();
        Text rightTextMain = newItemMainPanel.transform.Find("RightText").GetComponent<Text>();

        Text leftTextOther = newItemOtherPanel.transform.Find("LeftText").GetComponent<Text>();
        Text rightTextOther = newItemOtherPanel.transform.Find("RightText").GetComponent<Text>();

        leftTextMain.text = menuName;
        rightTextMain.text = price.ToString();

        leftTextOther.text = menuName;
        rightTextOther.text = price.ToString();

        // 위치 및 크기 변경 (두 번째 패널에서만)
        RectTransform rectTransformOther = newItemOtherPanel.GetComponent<RectTransform>();
        rectTransformOther.anchoredPosition = new Vector2(100f, 0f); // 예시로 X = 100, Y = 0 위치
        rectTransformOther.sizeDelta = new Vector2(300f, 50f); // 크기 조정: 300x50

        // 리스트에 추가
        orderItems.Add(newItemMainPanel);
        orderItems.Add(newItemOtherPanel);

        // 삭제 버튼 이벤트 연결 (동기화)
        Button removeButtonMain = newItemMainPanel.transform.Find("RemoveButton").GetComponent<Button>();
        removeButtonMain.onClick.AddListener(() => RemoveOrder(newItemMainPanel, newItemOtherPanel, price));

        Button removeButtonOther = newItemOtherPanel.transform.Find("RemoveButton").GetComponent<Button>();
        removeButtonOther.onClick.AddListener(() => RemoveOrder(newItemOtherPanel, newItemMainPanel, price));

        // 콜라이더 추가 (VR에서 클릭 가능하게 만듬)
        BoxCollider colliderMain = removeButtonMain.gameObject.AddComponent<BoxCollider>();
        colliderMain.size = new Vector3(30f, 30f, 3f);

        BoxCollider colliderOther = removeButtonOther.gameObject.AddComponent<BoxCollider>();
        colliderOther.size = new Vector3(30f, 30f, 3f);

        // 가격 및 메뉴 개수 업데이트
        totalPrice += price;
        totalMenuCount++;

        // UI 갱신
        UpdateTotalPrice();
        UpdateMenuCountText();
    }

    private void AddOption(string optionName, int price)
    {
        if (!currentOptions.Contains(optionName)) // 중복 옵션 방지
        {
            currentOptions.Add(optionName);
            currentOptionPrice += price;

            // 텍스트 UI 업데이트
            UpdateSelectedOptionsText();
            UpdateTotalOptionPriceText();
        }
        else
        {
            Debug.Log($"옵션 '{optionName}'은 이미 추가되었습니다.");
        }
    }
    void UpdateMenuCountText()
    {
        // 메뉴 갯수를 여러 패널에서 동기화
        foreach (Text text in menuCountTexts)
        {
            text.text = totalMenuCount.ToString();
        }
    }

    private void UpdateSelectedOptionsText()
    {
        // 옵션 목록을 문자열로 변환하여 텍스트 UI에 표시
        string optionsSummary = string.Join(", ", currentOptions);
        selectedOptionsText.text = $"{optionsSummary}";
    }

    private void UpdateTotalOptionPriceText()
    {
        // 총 옵션 가격을 텍스트 UI에 표시
        totalOptionPriceText.text = $"{currentOptionPrice}";
    }

    void RemoveOrder(GameObject orderItem, GameObject syncedOrderItem, int price)
    {
        // 리스트에서 제거
        orderItems.Remove(orderItem);
        orderItems.Remove(syncedOrderItem);

        // UI 오브젝트 삭제
        Destroy(orderItem);
        Destroy(syncedOrderItem);

        // 가격 및 메뉴 개수 업데이트
        totalPrice -= price;
        totalMenuCount--;

        // UI 갱신
        UpdateTotalPrice();
        UpdateMenuCountText();
    }
    private void UpdateMenuUI()
    {
        // 각 패널의 항목을 모두 제거한 후 동기화
        foreach (Transform child in contentParentMain)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in contentParentOther)
        {
            Destroy(child.gameObject);
        }

        // orderItems 리스트를 기반으로 동기화된 항목 생성
        for (int i = 0; i < orderItems.Count; i += 2)
        {
            GameObject orderItemMainPanel = orderItems[i];  // 첫 번째 패널의 항목
            GameObject orderItemOtherPanel = orderItems[i + 1];  // 두 번째 패널의 항목

            // 첫 번째 패널 항목을 생성하고 텍스트 설정
            GameObject newItemMainPanel = Instantiate(orderItemMainPanel, contentParentMain);
            Text leftTextMain = newItemMainPanel.transform.Find("LeftText").GetComponent<Text>();
            Text rightTextMain = newItemMainPanel.transform.Find("RightText").GetComponent<Text>();
            leftTextMain.text = orderItemMainPanel.transform.Find("LeftText").GetComponent<Text>().text;
            rightTextMain.text = orderItemMainPanel.transform.Find("RightText").GetComponent<Text>().text;

            // 두 번째 패널 항목을 생성하고 텍스트 설정
            GameObject newItemOtherPanel = Instantiate(orderItemOtherPanel, contentParentOther);
            Text leftTextOther = newItemOtherPanel.transform.Find("LeftText").GetComponent<Text>();
            Text rightTextOther = newItemOtherPanel.transform.Find("RightText").GetComponent<Text>();
            leftTextOther.text = orderItemOtherPanel.transform.Find("LeftText").GetComponent<Text>().text;
            rightTextOther.text = orderItemOtherPanel.transform.Find("RightText").GetComponent<Text>().text;

            // 삭제 버튼 다시 연결
            Button removeButtonMain = newItemMainPanel.transform.Find("RemoveButton").GetComponent<Button>();
            removeButtonMain.onClick.AddListener(() => RemoveOrder(newItemMainPanel, newItemOtherPanel, int.Parse(rightTextMain.text)));

            Button removeButtonOther = newItemOtherPanel.transform.Find("RemoveButton").GetComponent<Button>();
            removeButtonOther.onClick.AddListener(() => RemoveOrder(newItemOtherPanel, newItemMainPanel, int.Parse(rightTextOther.text)));
        }
    }

    void ResetCurrentSelections()
    {
        currentOptionPrice = 0;
        currentOptions.Clear(); // 선택된 옵션 초기화
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
        // 옵션 리스트와 총 가격 초기화
        currentOptions.Clear();
        currentOptionPrice = 0;

        // 텍스트 UI 초기화
        UpdateSelectedOptionsText();
        UpdateTotalOptionPriceText();
    }
    public void ResetOrders()
    {
        // 주문 리스트 비우기
        orderItems.Clear();
        leftTextList.Clear();
        rightTextList.Clear();

        // 화면에서 주문 항목 삭제
        foreach (Transform child in contentParentMain)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in contentParentOther)
        {
            Destroy(child.gameObject);
        }

        // 데이터 초기화
        totalPrice = 0;
        totalMenuCount = 0;
        currentOptionPrice = 0;
        currentOptions.Clear();

        // UI 초기화
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

