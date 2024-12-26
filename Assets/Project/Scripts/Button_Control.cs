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

    public GameObject textPrefab; // 텍스트와 버튼이 포함된 프리팹
    public Transform contentParent; // 프리팹이 생성될 부모 오브젝트 (ScrollView의 Content)
    private List<GameObject> orderItems = new List<GameObject>(); // 생성된 텍스트 UI 저장 리스트

    private int totalPrice = 0;
    private int currentOptionPrice = 0;
    private int currentMenuPrice = 0;
    private string currentMenuName = "";
    private List<string> currentOptions = new List<string>(); // 추가된 옵션 이름 리스트

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
        currentMenuName = "아메리카노";
        ResetOptions();
    }
    public void Coldbrew()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "콜드브루";
        ResetOptions();
    }
    public void Espresso()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 1500;
        currentMenuName = "에스프레소";
        ResetOptions();
    }
    public void Caffelatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 2900;
        currentMenuName = "카페라떼";
        ResetOptions();
    }
    public void Cafemocha()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 390;
        currentMenuName = "카페모카";
        ResetOptions();
    }
    public void Cappuccino()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
        currentMenuPrice = 2900;
        currentMenuName = "카푸치노";
        ResetOptions();
    }
    public void Caramelmacchiato()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
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
    }
    public void Icetea()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3000;
        currentMenuName = "아이스티";
        ResetOptions();
    }
    public void Chamomile()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 2500;
        currentMenuName = "캐모마일";
        ResetOptions();
    }
    public void Peppermint()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 2500;
        currentMenuName = "페퍼민트";
        ResetOptions();
    }
    public void Citron()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3300;
        currentMenuName = "유자";
        ResetOptions();
    }
    public void Grapefruit()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "자몽에이드";
        ResetOptions();
    }
    public void Whitegrape()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "청포도에이드";
        ResetOptions();
    }
    public void Lemon()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "레몬에이드";
        ResetOptions();
    }
    public void Chocolatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "초코라떼";
        ResetOptions();
    }
    public void Strawberrylatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3700;
        currentMenuName = "딸기라떼";
        ResetOptions();
    }
    public void Grainlatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3000;
        currentMenuName = "곡물라떼";
        ResetOptions();
    }
    public void Greentealatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "녹차라떼";
        ResetOptions();
    }
    public void Sweetpotatolatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3500;
        currentMenuName = "고구마라떼";
        ResetOptions();
    }
    public void Strawberrysmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "딸기스무디";
        ResetOptions();
    }
    public void Blueberrysmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "블루베리스무디";
        ResetOptions();
    }
    public void Planesmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "플레인스무디";
        ResetOptions();
    }
    public void Mangosmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "망고스무디";
        ResetOptions();
    }
    public void Cookiefrappe()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
        currentMenuPrice = 3900;
        currentMenuName = "쿠키프라페";
        ResetOptions();
    }
    public void Chocofrappe()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
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
    public void Resetoption()
    {
        Debug.Log("option");
    }
    void AddOrder(string menuName, int price)
    {
        // 프리팹 생성
        GameObject newItem = Instantiate(textPrefab, contentParent);

        // 텍스트 UI 설정
        Text leftText = newItem.transform.Find("LeftText").GetComponent<Text>();
        Text rightText = newItem.transform.Find("RightText").GetComponent<Text>();

        leftText.text = menuName;
        rightText.text = price.ToString();

        // 삭제 버튼 이벤트 연결
        Button removeButton = newItem.transform.Find("RemoveButton").GetComponent<Button>();
        removeButton.onClick.AddListener(() => RemoveOrderButton(newItem)); // 프리팹 오브젝트 전달

        // 콜라이더 추가 (VR에서 클릭 가능하게 만듬)
        removeButton.gameObject.AddComponent<BoxCollider>(); // 버튼에 콜라이더 추가

        // 주문 리스트에 추가
        orderItems.Add(newItem);
        totalPrice += price;
        UpdateTotalPrice();
    }

    void AddOption(string optionName, int price)
    {
        if (!currentOptions.Contains(optionName)) // 중복 옵션 방지
        {
            currentOptions.Add(optionName);
            currentOptionPrice += price;
        }
        else
        {
            Debug.Log($"옵션 '{optionName}'은 이미 추가되었습니다.");
        }
    }

    public void RemoveOrderButton(GameObject orderItem)
    {
        // 삭제할 항목의 가격 가져오기
        int price = int.Parse(orderItem.transform.Find("RightText").GetComponent<Text>().text);

        // 총 가격에서 차감
        totalPrice -= price;

        // 주문 항목 리스트에서 제거
        orderItems.Remove(orderItem);

        // UI 오브젝트 삭제
        Destroy(orderItem);

        // 총 가격 UI 갱신
        UpdateTotalPrice();
    }

    void ResetCurrentSelections()
    {
        currentOptionPrice = 0;
        currentOptions.Clear(); // 선택된 옵션 초기화
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

