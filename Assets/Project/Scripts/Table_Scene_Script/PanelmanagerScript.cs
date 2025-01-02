using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelmanagerScript : MonoBehaviour
{
    UImanagerScript barCon; //스크립트 참조.
    
    // 메뉴 클릭시 장바구니에 띄울 패널.
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

    // 패널의 RectTransform.
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
    

    float spacing = 0.03f; // 패널 간격

    // 패널안의 수량을 표시할 텍스트.
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


    public Text totalQuantity; // 총 합계 표시

    public Text totalPriceText; // 총 가격 표시

    public Text confirmQuantity; // 주문내역 확인창 총 합계 표시

    public Text confirmPriceText; // 주문내역 확인창 총 가격 표시

    public Text paymentPrice; // 결제화면 총 가격 표시

    public Text errorMessage; // 오류 메시지 표시 (패널 생성 제한 초과 시)

    public GameObject errormessagePanel; // 오류메세지 뒤에 띄울 패널.


    int[] quan = new int[21];

    float[] price = new float[21]; // 각 패널의 가격을 저장 (예: panel1 = 10, panel2 = 20, panel3 = 30)

    // 패널이 생성된 여부를 추적하는 리스트 (최대 2개까지만 활성화 가능)
    List<bool> isPanelCreated = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    // 패널들이 활성화된 순서대로 저장
    List<GameObject> activePanels = new List<GameObject>();

    public GameObject confirmPanel; //주문내역 확인내역 판넬.

    // 새로운 UI Text 추가: 저장된 수량 표시용
    public Text savedNameText; // 저장된 수량을 표시할 UI Text

    // 새로운 UI Text 추가: 저장된 수량 표시용
    public Text savedQuantityText; // 저장된 수량을 표시할 UI Text

    // 새로운 UI Text 추가: 저장된 금액 표시용
    public Text savedPriceText; // 저장된 금액을 표시할 UI Text

    // 최대 생성 가능한 패널 수
    public int maxPanels = 8;

    public GameObject paymentPanel; //결제화면 판넬

    public BoxCollider[] boxC; // 버튼의 박스 콜라이더 setActive 껐다켰다.

    public GameObject creditCard; // 신용카드 오브젝트
    public GameObject fixedcreditCard; // 고정된 신용카드 오브젝트

    public GameObject orderedPanel; // 결제가 완료된 판넬

    public GameObject timerText; // 시간을 표시할 오브젝트
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

        // 패널 비활성화
        panelSetfalse();

        //// 패널 비활성화
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

        //// 패널 초기화
        //panelToZero();

        confirmPanel.SetActive(false);
        paymentPanel.SetActive(false);
        orderedPanel.SetActive(false);
        creditCard.SetActive(false);
        fixedcreditCard.SetActive(false);

        //boxC[0] = GetComponent<BoxCollider>();
        //boxC[1] = GetComponent<BoxCollider>();

        price[0] = 9000f; // panel1 가격 //닭갈비 메뉴
        price[1] = 23000f; // panel2 가격
        price[2] = 23000f; // panel3 가격
        price[3] = 10000f;
        price[4] = 6500f; // 볶음밥 메뉴
        price[5] = 6500f;
        price[6] = 7000f;
        price[7] = 3000f;
        price[8] = 4000f;
        price[9] = 7000f; // 별미메뉴
        price[10] = 7000f;
        price[11] = 6000f;
        price[12] = 4500f;
        price[13] = 3500f;
        price[14] = 4500f; // 사리메뉴
        price[15] = 3000f;
        price[16] = 2000f;
        price[17] = 2000f;
        price[18] = 2000f;
        price[19] = 2000f;
        price[20] = 1000f;

        errormessagePanel.SetActive(false); // 오류 메시지 패널 초기에는 숨김
        errorMessage.gameObject.SetActive(false); // 오류 메시지 초기에는 숨김

        // 게임 시작 시 PlayerPrefs 초기화
        P_PrefsDelete();

        // 저장된 값 불러오기
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

        // 합계를 계산하여 totalQuantity에 표시
        int total = quan[0] + quan[1] + quan[2] + quan[3] + quan[4] + quan[5] + quan[6] + quan[7] + quan[8] + quan[9] + quan[10] + quan[11] + quan[12] + quan[13] + quan[14] + quan[15] + quan[16] + quan[17] + quan[18] + quan[19] + quan[20];
        totalQuantity.text = "총 수량: " + total.ToString() + "개"; // 합계를 텍스트로 표시
        confirmQuantity.text = "주문 수량 " + total.ToString() + " 개";

        // 가격을 계산하여 totalPriceText에 표시
        float totalPrice = (quan[0] * price[0]) + (quan[1] * price[1]) + (quan[2] * price[2]) + (quan[3] * price[3]) + (quan[4] * price[4]) + (quan[5] * price[5]) + (quan[6] * price[6]) + (quan[7] * price[7]) + (quan[8] * price[8]) + (quan[9] * price[9])
            + (quan[10] * price[10]) + (quan[11] * price[11]) + (quan[12] * price[12]) + (quan[13] * price[13]) + (quan[14] * price[14]) + (quan[15] * price[15]) + (quan[16] * price[16]) + (quan[17] * price[17]) + (quan[18] * price[18]) + (quan[19] * price[19]) + (quan[20] * price[20]);
        totalPriceText.text = "총 결제금액: " + totalPrice.ToString() + "원"; // 총 가격 표시
        confirmPriceText.text = "총 주문 금액: " + totalPrice.ToString() + " 원";
        paymentPrice.text = totalPrice.ToString();

        if (orderedPanel.activeSelf)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timerText.GetComponent<Text>().text = time.ToString("F0") + "초 뒤에 엔딩으로 넘어갑니다";
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

    // 1번 버튼 클릭 시 호출
    public void OnButton1Click()
    {
        if (!isPanelCreated[0]) // panel1이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[0] = 1;
                quantity1.text = quan[0].ToString(); // 수량 업데이트
                panel1.SetActive(true); // panel1 활성화
                activePanels.Add(panel1); // 활성화된 패널 목록에 추가
                isPanelCreated[0] = true; // panel1 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel1이 생성되어 있다면 수량만 증가
        {
            quan[0]++;
            quantity1.text = quan[0].ToString();
        }

        UpdatePanel2Position();
    }

    // 2번 버튼 클릭 시 호출
    public void OnButton2Click()
    {
        if (!isPanelCreated[1]) // panel2가 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[1] = 1;
                quantity2.text = quan[1].ToString();
                panel2.SetActive(true); // panel2 활성화
                activePanels.Add(panel2); // 활성화된 패널 목록에 추가
                isPanelCreated[1] = true; // panel2 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel2가 생성되어 있다면 수량만 증가
        {
            quan[1]++;
            quantity2.text = quan[1].ToString();
        }

        UpdatePanel2Position();
    }

    // 3번 버튼 클릭 시 호출
    public void OnButton3Click()
    {
        if (!isPanelCreated[2]) // panel3이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[2] = 1;
                quantity3.text = quan[2].ToString();
                panel3.SetActive(true); // panel3 활성화
                activePanels.Add(panel3); // 활성화된 패널 목록에 추가
                isPanelCreated[2] = true; // panel3 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel3이 생성되어 있다면 수량만 증가
        {
            quan[2]++;
            quantity3.text = quan[2].ToString();
        }

        UpdatePanel2Position();
    }

    // 4번 버튼 클릭 시 호출
    public void OnButton4Click()
    {
        if (!isPanelCreated[3]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[3] = 1;
                quantity4.text = quan[3].ToString(); // 수량 업데이트
                panel4.SetActive(true); // panel4 활성화
                activePanels.Add(panel4); // 활성화된 패널 목록에 추가
                isPanelCreated[3] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[3]++;
            quantity4.text = quan[3].ToString();
        }

        UpdatePanel2Position();
    }

    // 5번 버튼 클릭 시 호출
    public void OnButton5Click()
    {
        if (!isPanelCreated[4]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[4] = 1;
                quantity5.text = quan[4].ToString(); // 수량 업데이트
                panel5.SetActive(true); // panel4 활성화
                activePanels.Add(panel5); // 활성화된 패널 목록에 추가
                isPanelCreated[4] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[4]++;
            quantity5.text = quan[4].ToString();
        }

        UpdatePanel2Position();
    }

    // 6번 버튼 클릭 시 호출
    public void OnButton6Click()
    {
        if (!isPanelCreated[5]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[5] = 1;
                quantity6.text = quan[5].ToString(); // 수량 업데이트
                panel6.SetActive(true); // panel4 활성화
                activePanels.Add(panel6); // 활성화된 패널 목록에 추가
                isPanelCreated[5] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[5]++;
            quantity6.text = quan[5].ToString();
        }

        UpdatePanel2Position();
    }

    // 7번 버튼 클릭 시 호출
    public void OnButton7Click()
    {
        if (!isPanelCreated[6]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[6] = 1;
                quantity7.text = quan[6].ToString(); // 수량 업데이트
                panel7.SetActive(true); // panel4 활성화
                activePanels.Add(panel7); // 활성화된 패널 목록에 추가
                isPanelCreated[6] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[6]++;
            quantity7.text = quan[6].ToString();
        }

        UpdatePanel2Position();
    }

    // 8번 버튼 클릭 시 호출
    public void OnButton8Click()
    {
        if (!isPanelCreated[7]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[7] = 1;
                quantity8.text = quan[7].ToString(); // 수량 업데이트
                panel8.SetActive(true); // panel4 활성화
                activePanels.Add(panel8); // 활성화된 패널 목록에 추가
                isPanelCreated[7] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[7]++;
            quantity8.text = quan[7].ToString();
        }

        UpdatePanel2Position();
    }

    // 9번 버튼 클릭 시 호출
    public void OnButton9Click()
    {
        if (!isPanelCreated[8]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[8] = 1;
                quantity9.text = quan[8].ToString(); // 수량 업데이트
                panel9.SetActive(true); // panel4 활성화
                activePanels.Add(panel9); // 활성화된 패널 목록에 추가
                isPanelCreated[8] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[8]++;
            quantity9.text = quan[8].ToString();
        }

        UpdatePanel2Position();
    }

    // 10번 버튼 클릭 시 호출
    public void OnButton10Click()
    {
        if (!isPanelCreated[9]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[9] = 1;
                quantity10.text = quan[9].ToString(); // 수량 업데이트
                panel10.SetActive(true); // panel4 활성화
                activePanels.Add(panel10); // 활성화된 패널 목록에 추가
                isPanelCreated[9] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[9]++;
            quantity10.text = quan[9].ToString();
        }

        UpdatePanel2Position();
    }

    // 11번 버튼 클릭 시 호출
    public void OnButton11Click()
    {
        if (!isPanelCreated[10]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[10] = 1;
                quantity11.text = quan[10].ToString(); // 수량 업데이트
                panel11.SetActive(true); // panel4 활성화
                activePanels.Add(panel11); // 활성화된 패널 목록에 추가
                isPanelCreated[10] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[10]++;
            quantity11.text = quan[10].ToString();
        }

        UpdatePanel2Position();
    }

    // 12번 버튼 클릭 시 호출
    public void OnButton12Click()
    {
        if (!isPanelCreated[11]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[11] = 1;
                quantity12.text = quan[11].ToString(); // 수량 업데이트
                panel12.SetActive(true); // panel4 활성화
                activePanels.Add(panel12); // 활성화된 패널 목록에 추가
                isPanelCreated[11] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[11]++;
            quantity12.text = quan[11].ToString();
        }

        UpdatePanel2Position();
    }

    // 13번 버튼 클릭 시 호출
    public void OnButton13Click()
    {
        if (!isPanelCreated[12]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[12] = 1;
                quantity13.text = quan[12].ToString(); // 수량 업데이트
                panel13.SetActive(true); // panel4 활성화
                activePanels.Add(panel13); // 활성화된 패널 목록에 추가
                isPanelCreated[12] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[12]++;
            quantity13.text = quan[12].ToString();
        }

        UpdatePanel2Position();
    }

    // 14번 버튼 클릭 시 호출
    public void OnButton14Click()
    {
        if (!isPanelCreated[13]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[13] = 1;
                quantity14.text = quan[13].ToString(); // 수량 업데이트
                panel14.SetActive(true); // panel4 활성화
                activePanels.Add(panel14); // 활성화된 패널 목록에 추가
                isPanelCreated[13] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[13]++;
            quantity14.text = quan[13].ToString();
        }

        UpdatePanel2Position();
    }

    // 15번 버튼 클릭 시 호출
    public void OnButton15Click()
    {
        if (!isPanelCreated[14]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[14] = 1;
                quantity15.text = quan[14].ToString(); // 수량 업데이트
                panel15.SetActive(true); // panel4 활성화
                activePanels.Add(panel15); // 활성화된 패널 목록에 추가
                isPanelCreated[14] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[14]++;
            quantity15.text = quan[14].ToString();
        }

        UpdatePanel2Position();
    }

    // 16번 버튼 클릭 시 호출
    public void OnButton16Click()
    {
        if (!isPanelCreated[15]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[15] = 1;
                quantity16.text = quan[15].ToString(); // 수량 업데이트
                panel16.SetActive(true); // panel4 활성화
                activePanels.Add(panel16); // 활성화된 패널 목록에 추가
                isPanelCreated[15] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[15]++;
            quantity16.text = quan[15].ToString();
        }

        UpdatePanel2Position();
    }

    // 17번 버튼 클릭 시 호출
    public void OnButton17Click()
    {
        if (!isPanelCreated[16]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[16] = 1;
                quantity17.text = quan[16].ToString(); // 수량 업데이트
                panel17.SetActive(true); // panel4 활성화
                activePanels.Add(panel17); // 활성화된 패널 목록에 추가
                isPanelCreated[16] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[16]++;
            quantity17.text = quan[16].ToString();
        }

        UpdatePanel2Position();
    }

    // 18번 버튼 클릭 시 호출
    public void OnButton18Click()
    {
        if (!isPanelCreated[17]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[17] = 1;
                quantity18.text = quan[17].ToString(); // 수량 업데이트
                panel18.SetActive(true); // panel4 활성화
                activePanels.Add(panel18); // 활성화된 패널 목록에 추가
                isPanelCreated[17] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[17]++;
            quantity18.text = quan[17].ToString();
        }

        UpdatePanel2Position();
    }

    // 19번 버튼 클릭 시 호출
    public void OnButton19Click()
    {
        if (!isPanelCreated[18]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[18] = 1;
                quantity19.text = quan[18].ToString(); // 수량 업데이트
                panel19.SetActive(true); // panel4 활성화
                activePanels.Add(panel19); // 활성화된 패널 목록에 추가
                isPanelCreated[18] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[18]++;
            quantity19.text = quan[18].ToString();
        }

        UpdatePanel2Position();
    }

    // 20번 버튼 클릭 시 호출
    public void OnButton20Click()
    {
        if (!isPanelCreated[19]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[19] = 1;
                quantity20.text = quan[19].ToString(); // 수량 업데이트
                panel20.SetActive(true); // panel4 활성화
                activePanels.Add(panel20); // 활성화된 패널 목록에 추가
                isPanelCreated[19] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[19]++;
            quantity20.text = quan[19].ToString();
        }

        UpdatePanel2Position();
    }

    // 21번 버튼 클릭 시 호출
    public void OnButton21Click()
    {
        if (!isPanelCreated[20]) // panel4이 아직 생성되지 않았을 경우
        {
            if (activePanels.Count < maxPanels) // 생성된 패널이 8개 미만일 때만 패널 추가 가능
            {
                quan[20] = 1;
                quantity21.text = quan[20].ToString(); // 수량 업데이트
                panel21.SetActive(true); // panel4 활성화
                activePanels.Add(panel21); // 활성화된 패널 목록에 추가
                isPanelCreated[20] = true; // panel4 생성된 상태로 표시
            }
            else
            {
                ShowErrorMessage("장바구니에 " + maxPanels + " 개 품목만 담을 수 있습니다.");
                return;
            }
        }
        else // 이미 panel4이 생성되어 있다면 수량만 증가
        {
            quan[20]++;
            quantity21.text = quan[20].ToString();
        }

        UpdatePanel2Position();
    }


    // 패널 위치 업데이트
    public void UpdatePanel2Position()
    {

        // 패널들이 활성화된 순서대로 위치 업데이트
        float yOffset = 0.167805f; // 초기 Y 좌표

        foreach (var panel in activePanels)
        {
            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchoredPosition = new Vector2(panelRect.anchoredPosition.x, yOffset); // Y 좌표 업데이트

            yOffset -= spacing; // 간격을 두고 아래로 배치
        }

    }

    // -버튼 -> 수량감소
    public void DecreaseClick00() //싱가네 닭갈비 -버튼
    {
        if (quan[0] > 1)
        {
            quan[0]--;
            quantity1.text = quan[0].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick01()
    {
        if (quan[1] > 1)
        {
            quan[1]--;
            quantity2.text = quan[1].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick02()
    {
        if (quan[2] > 1)
        {
            quan[2]--;
            quantity3.text = quan[2].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick03()
    {
        if (quan[3] > 1)
        {
            quan[3]--;
            quantity4.text = quan[3].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick04()
    {
        if (quan[4] > 1)
        {
            quan[4]--;
            quantity5.text = quan[4].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick05()
    {
        if (quan[5] > 1)
        {
            quan[5]--;
            quantity6.text = quan[5].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick06()
    {
        if (quan[6] > 1)
        {
            quan[6]--;
            quantity7.text = quan[6].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick07()
    {
        if (quan[7] > 1)
        {
            quan[7]--;
            quantity8.text = quan[7].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick08()
    {
        if (quan[8] > 1)
        {
            quan[8]--;
            quantity9.text = quan[8].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick09()
    {
        if (quan[9] > 1)
        {
            quan[9]--;
            quantity10.text = quan[9].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick10()
    {
        if (quan[10] > 1)
        {
            quan[10]--;
            quantity11.text = quan[10].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick11()
    {
        if (quan[11] > 1)
        {
            quan[11]--;
            quantity12.text = quan[11].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick12()
    {
        if (quan[12] > 1)
        {
            quan[12]--;
            quantity13.text = quan[12].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick13()
    {
        if (quan[13] > 1)
        {
            quan[13]--;
            quantity14.text = quan[13].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick14()
    {
        if (quan[14] > 1)
        {
            quan[14]--;
            quantity15.text = quan[14].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick15()
    {
        if (quan[15] > 1)
        {
            quan[15]--;
            quantity16.text = quan[15].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick16()
    {
        if (quan[16] > 1)
        {
            quan[16]--;
            quantity17.text = quan[16].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick17()
    {
        if (quan[17] > 1)
        {
            quan[17]--;
            quantity18.text = quan[17].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick18()
    {
        if (quan[18] > 1)
        {
            quan[18]--;
            quantity19.text = quan[18].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick19()
    {
        if (quan[19] > 1)
        {
            quan[19]--;
            quantity20.text = quan[19].ToString(); // 수량 업데이트
        }
    }
    public void DecreaseClick20()
    {
        if (quan[20] > 1)
        {
            quan[20]--;
            quantity21.text = quan[20].ToString(); // 수량 업데이트
        }
    }

    // +버튼 -> 수량증가
    public void IncreaseClick00() //싱가네 닭갈비 +버튼
    {
        quan[0]++;
        quantity1.text = quan[0].ToString(); // 수량 업데이트
    }

    public void IncreaseClick01()
    {
        quan[1]++;
        quantity2.text = quan[1].ToString(); // 수량 업데이트
    }

    public void IncreaseClick02()
    {
        quan[2]++;
        quantity3.text = quan[2].ToString(); // 수량 업데이트
    }
    public void IncreaseClick03()
    {
        quan[3]++;
        quantity4.text = quan[3].ToString(); // 수량 업데이트        
    }
    public void IncreaseClick04()
    {
        quan[4]++;
        quantity5.text = quan[4].ToString(); // 수량 업데이트
    }
    public void IncreaseClick05()
    {
        quan[5]++;
        quantity6.text = quan[5].ToString(); // 수량 업데이트        
    }
    public void IncreaseClick06()
    {
        quan[6]++;
        quantity7.text = quan[6].ToString(); // 수량 업데이트
    }
    public void IncreaseClick07()
    {
        quan[7]++;
        quantity8.text = quan[7].ToString(); // 수량 업데이트
    }
    public void IncreaseClick08()
    {
        quan[8]++;
        quantity9.text = quan[8].ToString(); // 수량 업데이트
    }
    public void IncreaseClick09()
    {
        quan[9]++;
        quantity10.text = quan[9].ToString(); // 수량 업데이트
    }
    public void IncreaseClick10()
    {
        quan[10]++;
        quantity11.text = quan[10].ToString(); // 수량 업데이트
    }
    public void IncreaseClick11()
    {
        quan[11]++;
        quantity12.text = quan[11].ToString(); // 수량 업데이트
    }
    public void IncreaseClick12()
    {
        quan[12]++;
        quantity13.text = quan[12].ToString(); // 수량 업데이트
    }
    public void IncreaseClick13()
    {
        quan[13]++;
        quantity14.text = quan[13].ToString(); // 수량 업데이트
    }
    public void IncreaseClick14()
    {
        quan[14]++;
        quantity15.text = quan[14].ToString(); // 수량 업데이트
    }
    public void IncreaseClick15()
    {
        quan[15]++;
        quantity16.text = quan[15].ToString(); // 수량 업데이트
    }
    public void IncreaseClick16()
    {
        quan[16]++;
        quantity17.text = quan[16].ToString(); // 수량 업데이트
    }
    public void IncreaseClick17()
    {
        quan[17]++;
        quantity18.text = quan[17].ToString(); // 수량 업데이트
    }
    public void IncreaseClick18()
    {
        quan[18]++;
        quantity19.text = quan[18].ToString(); // 수량 업데이트
    }
    public void IncreaseClick19()
    {
        quan[19]++;
        quantity20.text = quan[19].ToString(); // 수량 업데이트
    }
    public void IncreaseClick20()
    {
        quan[20]++;
        quantity21.text = quan[20].ToString(); // 수량 업데이트
    }

    // X버튼 -> 항목삭제
    public void XbuttonClick00(GameObject panel) //싱가네 닭갈비 X버튼
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[0] = 0; // quantity를 0으로 설정
            quantity1.text = quan[0].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[0] = false; // 해당 패널 생성 상태를 false로 변경

        activePanels.Remove(panel);
        UpdatePanel2Position();
    }

    public void XbuttonClick01(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[1] = 0; // quantity를 0으로 설정
            quantity2.text = quan[1].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[1] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }

    public void XbuttonClick02(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[2] = 0; // quantity를 0으로 설정
            quantity3.text = quan[2].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[2] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick03(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[3] = 0; // quantity를 0으로 설정
            quantity4.text = quan[3].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[3] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick04(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[4] = 0; // quantity를 0으로 설정
            quantity5.text = quan[4].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[4] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick05(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[5] = 0; // quantity를 0으로 설정
            quantity6.text = quan[5].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[5] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick06(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[6] = 0; // quantity를 0으로 설정
            quantity7.text = quan[6].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[6] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick07(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[7] = 0; // quantity를 0으로 설정
            quantity8.text = quan[7].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[7] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick08(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[8] = 0; // quantity를 0으로 설정
            quantity9.text = quan[8].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[8] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick09(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[9] = 0; // quantity를 0으로 설정
            quantity10.text = quan[9].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[9] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick10(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[10] = 0; // quantity를 0으로 설정
            quantity11.text = quan[10].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[10] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick11(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[11] = 0; // quantity를 0으로 설정
            quantity12.text = quan[11].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[11] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick12(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[12] = 0; // quantity를 0으로 설정
            quantity13.text = quan[12].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[12] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick13(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[13] = 0; // quantity를 0으로 설정
            quantity14.text = quan[13].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[13] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick14(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[14] = 0; // quantity를 0으로 설정
            quantity15.text = quan[14].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[14] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick15(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[15] = 0; // quantity를 0으로 설정
            quantity16.text = quan[15].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[15] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick16(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[16] = 0; // quantity를 0으로 설정
            quantity17.text = quan[16].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[16] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick17(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[17] = 0; // quantity를 0으로 설정
            quantity18.text = quan[17].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[17] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick18(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[18] = 0; // quantity를 0으로 설정
            quantity19.text = quan[18].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[18] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick19(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[19] = 0; // quantity를 0으로 설정
            quantity20.text = quan[19].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[19] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }
    public void XbuttonClick20(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);

        if (!panel.activeSelf)  // 비활성화 된 경우
        {
            quan[20] = 0; // quantity를 0으로 설정
            quantity21.text = quan[20].ToString(); // UI 텍스트 업데이트
        }

        isPanelCreated[20] = false; // 해당 패널 생성 상태를 false로 변경
        activePanels.Remove(panel);
        UpdatePanel2Position();
    }

    // 오류 메시지를 표시하는 함수
    private void ShowErrorMessage(string message)
    {
        errormessagePanel.SetActive(true);
        errorMessage.text = message;
        errorMessage.gameObject.SetActive(true); // 오류 메시지를 화면에 표시
        Invoke("HideErrorMessage", 2f); // 2초 후에 오류 메시지를 숨김
    }

    // 오류 메시지를 숨기는 함수
    private void HideErrorMessage()
    {
        errormessagePanel.SetActive(false);
        errorMessage.gameObject.SetActive(false);
    }

    // 주문하기 버튼 클릭 시 호출
    public void OnOrderButtonClick()
    {
        // 패널의 수량을 저장
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
        PlayerPrefs.Save(); // 저장하기
        Debug.Log("Order saved!");

        confirmPanel.SetActive(true);
        
        // 저장된 값을 새 UI Text에 표시
        DisplaySavedQuantities();

    }

    // 주문 세부내역 닫기 X버튼 클릭시
    public void CloseConfirmClick()
    {
        confirmPanel.SetActive(false);
    }

    // 저장된 값을 새 UI Text에 표시
    public void DisplaySavedQuantities()
    {
        // 저장된 수량 값 불러오기
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

        // 수량과 가격을 저장할 텍스트 변수
        string nameResultText = "";
        string quantityResultText = "";
        string priceResultText = "";


        // panel1의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel1Quantity > 0)
        {
            nameResultText += "싱가네 닭갈비" + "\n";
            quantityResultText += panel1Quantity + "개" + "\n";
            priceResultText += panel1Quantity * panel1Price + "원" + "\n";
        }

        // panel2의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel2Quantity > 0)
        {
            nameResultText += "치즈닭갈비" + "\n";
            quantityResultText += panel2Quantity + "개" + "\n";
            priceResultText += panel2Quantity * panel2Price + "원" + "\n";
        }

        // panel3의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel3Quantity > 0)
        {
            nameResultText += "로제닭갈비" + "\n";
            quantityResultText += panel3Quantity + "개" + "\n";
            priceResultText += panel3Quantity * panel3Price + "원" + "\n";
        }

        // panel4의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel4Quantity > 0)
        {
            nameResultText += "쭈꾸미닭갈비" + "\n";
            quantityResultText += panel4Quantity + "개" + "\n";
            priceResultText += panel4Quantity * panel4Price + "원" + "\n";
        }
        // panel5의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel5Quantity > 0)
        {
            nameResultText += "닭갈비철판볶음밥" + "\n";
            quantityResultText += panel5Quantity + "개" + "\n";
            priceResultText += panel5Quantity * panel5Price + "원" + "\n";
        }
        // panel6의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel6Quantity > 0)
        {
            nameResultText += "닭야채철판볶음밥" + "\n";
            quantityResultText += panel6Quantity + "개" + "\n";
            priceResultText += panel6Quantity * panel6Price + "원" + "\n";
        }
        // panel7의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel7Quantity > 0)
        {
            nameResultText += "치즈철판볶음밥" + "\n";
            quantityResultText += panel7Quantity + "개" + "\n";
            priceResultText += panel7Quantity * panel7Price + "원" + "\n";
        }
        // panel8의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel8Quantity > 0)
        {
            nameResultText += "볶음공기" + "\n";
            quantityResultText += panel8Quantity + "개" + "\n";
            priceResultText += panel8Quantity * panel8Price + "원" + "\n";
        }
        // panel9의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel9Quantity > 0)
        {
            nameResultText += "날치알볶음공기" + "\n";
            quantityResultText += panel9Quantity + "개" + "\n";
            priceResultText += panel9Quantity * panel9Price + "원" + "\n";
        }
        // panel10의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel10Quantity > 0)
        {
            nameResultText += "물막국수" + "\n";
            quantityResultText += panel10Quantity + "개" + "\n";
            priceResultText += panel10Quantity * panel10Price + "원" + "\n";
        }
        // panel11의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel11Quantity > 0)
        {
            nameResultText += "물비빔막국수" + "\n";
            quantityResultText += panel11Quantity + "개" + "\n";
            priceResultText += panel11Quantity * panel11Price + "원" + "\n";
        }
        // panel12의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel12Quantity > 0)
        {
            nameResultText += "비빔쫄면" + "\n";
            quantityResultText += panel12Quantity + "개" + "\n";
            priceResultText += panel12Quantity * panel12Price + "원" + "\n";
        }
        // panel13의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel13Quantity > 0)
        {
            nameResultText += "스팸주먹밥" + "\n";
            quantityResultText += panel13Quantity + "개" + "\n";
            priceResultText += panel13Quantity * panel13Price + "원" + "\n";
        }
        // panel14의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel14Quantity > 0)
        {
            nameResultText += "계란찜" + "\n";
            quantityResultText += panel14Quantity + "개" + "\n";
            priceResultText += panel14Quantity * panel14Price + "원" + "\n";
        }
        // panel15의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel15Quantity > 0)
        {
            nameResultText += "모둠사리" + "\n";
            quantityResultText += panel15Quantity + "개" + "\n";
            priceResultText += panel15Quantity * panel15Price + "원" + "\n";
        }
        // panel16의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel16Quantity > 0)
        {
            nameResultText += "모짜렐라치즈" + "\n";
            quantityResultText += panel16Quantity + "개" + "\n";
            priceResultText += panel16Quantity * panel16Price + "원" + "\n";
        }
        // panel17의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel17Quantity > 0)
        {
            nameResultText += "라면사리" + "\n";
            quantityResultText += panel17Quantity + "개" + "\n";
            priceResultText += panel17Quantity * panel17Price + "원" + "\n";
        }
        // panel18의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel18Quantity > 0)
        {
            nameResultText += "우동사리" + "\n";
            quantityResultText += panel18Quantity + "개" + "\n";
            priceResultText += panel18Quantity * panel18Price + "원" + "\n";
        }
        // panel19의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel19Quantity > 0)
        {
            nameResultText += "떡볶이떡" + "\n";
            quantityResultText += panel19Quantity + "개" + "\n";
            priceResultText += panel19Quantity * panel19Price + "원" + "\n";
        }
        // panel20의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel20Quantity > 0)
        {
            nameResultText += "치즈떡" + "\n";
            quantityResultText += panel20Quantity + "개" + "\n";
            priceResultText += panel20Quantity * panel20Price + "원" + "\n";
        }
        // panel21의 수량이 0이 아니면 결과 텍스트에 추가
        if (panel21Quantity > 0)
        {
            nameResultText += "공기밥" + "\n";
            quantityResultText += panel21Quantity + "개" + "\n";
            priceResultText += panel21Quantity * panel21Price + "원" + "\n";
        }

        // 결과 텍스트가 비어 있지 않으면, 저장된 수량을 텍스트 UI에 출력
        if (!string.IsNullOrEmpty(quantityResultText))
        {
            savedNameText.text = nameResultText;
            savedQuantityText.text = quantityResultText;
            savedPriceText.text = priceResultText;
        }
        else
        {
            savedNameText.text = "주문할 아이템이 없습니다.";
            savedQuantityText.text = " ";
            savedPriceText.text = " ";
        }

    }

    // 저장된 값 불러오기
    public void LoadPanelValues()
    {
        // 수량 불러오기
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

        // 가격 불러오기
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


    // 패널 비활성화
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
    

    // 게임 시작 시/ 광고화면으로 넘어갈 시 panel초기화
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

    // 게임 시작 시 PlayerPrefs 초기화
    public void P_PrefsDelete()
    {
        // 메서드로 만들어서 UImanager에서 참조할 수 있도록.
        PlayerPrefs.DeleteAll();  // 모든 PlayerPrefs 데이터 삭제
    }


    // 결제화면으로 넘어가기.
    public void GotoPayment()
    {
        boxC[0].enabled = false;
        boxC[1].enabled = false;
        paymentPanel.SetActive(true);
        creditCard.SetActive(true);
    }


    // 결제화면 취소하기.
    public void ClosePayment()
    {
        boxC[0].enabled = true;
        boxC[1].enabled = true;
        paymentPanel.SetActive(false);
        creditCard.SetActive(false);
    }

}
