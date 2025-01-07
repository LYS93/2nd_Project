using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class L_Hand_2 : MonoBehaviour
{
    GameObject Lhand;
    LineRenderer lineR;
    Ray ray;
    RaycastHit hit;
    public UnityEvent<bool> changeColor01 = new UnityEvent<bool>();
    bool hitButton01;
    public UnityEvent<bool> changeColor02 = new UnityEvent<bool>();
    bool hitButton02;
    Coroutine vibeHandle;
    Coroutine vibeButtons; //버튼클릭시 진동 (내가 넣은 스크립트.)

    public GameObject optionScreen;
    GameObject cameraCenter;

    //메서드 사용을 위해 스크립트 참조
    Camera_Move cammove;

    public bool optionSwitch; //옵션창 열림,닫힘을 확인하기위해

    bool ischaracterEnter = false; //발판 이전 키오스크 화면 클릭 막기위한 플래그.

    Vector3 KioskDirection = new Vector3(1.86f, 2.3f, -1.22f);//코루틴을 위해 가져옴.
    Vector3 TurnAngles = new Vector3(-1.5f, 1, 0.001f);//코루틴을 위해 가져옴.

    BoxCollider BoxCol; // 키오스크 콜라이더 비활성화를 위한 메서드.

    //스크립트 참조
    PanelmanagerScript panelManager;

    public GameObject KioWindow;// 키오스크 화면 껐다 켰다.
    BoxCollider KioskCol; // 옵션창 띄울때 키오스크의 콜라이더에 옵션창이 막히지 않도록 껐다켰다.

    public AudioSource clickFoot; // 01. 발판 선택 멘트.

    public AudioSource clickKiosk; // 02. 키오스크 화면 누르고 주문하기 멘트.

    public AudioSource clickCate; // 03-1. 키오스크 (카테고리를 눌러) 메뉴선택 멘트.

    public AudioSource clickCate2; // 03-2. 키오스크 메뉴선택 멘트.

    public AudioSource clickCheck; // 04. 장바구니를 눌러 확인 멘트.

    public AudioSource clickChangeQ; // 05. 수량 추가 감소 제거버튼 멘트.

    public AudioSource clickAddOther; // 06. 다른메뉴 추가시 장바구니를 닫기 멘트.

    public AudioSource clickToPay; // 07. 주문하기를 눌러서 결제하기 멘트.

    public AudioSource clickToCheckOrder; // 08. 결제하려면 결제하기/ 취소하려면 취소하기버튼 클릭 멘트.

    public AudioSource dragToInsertCard; // 09. 카드를 오른쪽 투입구에 넣어주세요 멘트.


    bool isMenuClicked = false; // 메뉴 클릭을 했는가?
    bool isBarClicked = false; // 바를 클릭 했는가?
    bool isSecondPlay = false; // 두번째 플레이인지?
    bool isMClicked = false; // 첫번째로 클릭했는지?

    // Start is called before the first frame update
    void Start()
    {
        Lhand = GameObject.Find("LeftHandAnchor");
        transform.position = Lhand.transform.position;
        transform.eulerAngles = Lhand.transform.eulerAngles;
        transform.parent = Lhand.transform;

        lineR = GetComponent<LineRenderer>();

        optionScreen = GameObject.Find("OptionScreen");
        cameraCenter = GameObject.Find("CenterEyeAnchor");
        optionScreen.SetActive(false); //시작할때 옵션창 비활성화

        if (hitButton01 == true)
        {
            hitButton01 = false;
            changeColor01.Invoke(hitButton01);
        }
        if (hitButton02 == true)
        {
            hitButton02 = false;
            changeColor02.Invoke(hitButton02);
        }

        //메서드 사용을 위해 스크립트 참조
        cammove = GameObject.Find("OVRCameraRig").GetComponent<Camera_Move>();

        BoxCol = GameObject.Find("KioskCube").GetComponent<BoxCollider>();

        panelManager = GameObject.Find("PanelManager").GetComponent<PanelmanagerScript>();

        KioskCol = GameObject.Find("TKiosk").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        lineR.SetPosition(0, ray.origin);
        lineR.SetPosition(1, ray.origin + ray.direction * 8);
        lineR.material.color = Color.cyan;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            lineR.SetPosition(0, ray.origin);
            lineR.SetPosition(1, hit.point);


            if (hit.collider.gameObject.CompareTag("button01")) //시작으로 돌아가는 버튼
            {
                lineR.material.color = Color.blue;

                if (hitButton01 == false)
                {
                    hitButton01 = true;
                    changeColor01.Invoke(hitButton01);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }
            if (hit.collider.gameObject.CompareTag("button02")) //프로그램을 종료하는 버튼
            {
                lineR.material.color = Color.blue;

                if (hitButton02 == false)
                {
                    hitButton02 = true;
                    changeColor02.Invoke(hitButton02);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }

            if (hit.collider.gameObject.CompareTag("option"))
            {
                lineR.material.color = Color.blue;
                hitButton01 = false;
                changeColor01.Invoke(hitButton01);
                hitButton02 = false;
                changeColor02.Invoke(hitButton02);
            }

            if (hit.collider.gameObject.CompareTag("FootPrint")) //텔레포트. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    ischaracterEnter = true;

                    clickFoot.Stop();

                    clickKiosk.Play();
                }
            }

            if (hit.collider.gameObject.CompareTag("KioskFront")) //카메라 키오스크 정면 이동. (내가 넣은 코드.)
            {
                if (ischaracterEnter == true)
                {
                    lineR.material.color = Color.blue;

                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                    {
                        BoxCol.enabled = false; //추가해야하는지 확인부터
                        cammove.Camera_moveToKiosk();//카메라 이동.
                    }
                }
            }

            if (hit.collider.gameObject.CompareTag("order")) //키오스크 화면 전환. 광고> 메뉴화면. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());

                    clickKiosk.Stop();
                    if (isSecondPlay == false) // 처음 플레이를 해봤다면 오디오 출력. 
                    {
                        clickCate.Play();
                        isSecondPlay = true;
                    }
                    else if (isSecondPlay == true)
                    {
                        clickCate2.Play();
                    }
                }
            }


            if (hit.collider.gameObject.CompareTag("cateChicken")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateFriedrice")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateSide")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateNoodle")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("bar")) //장바구니. (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());

                    if (isBarClicked == false)
                    {
                        clickCheck.Stop();

                        clickChangeQ.Play();
                        Invoke("clickToAddOther", 12.0f);
                        isBarClicked = true;
                    }
                }
            }

            if (hit.collider.gameObject.CompareTag("goAd")) //키오스크 처음화면. (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    // 패널 초기화
                    panelManager.panelSetfalse();
                    panelManager.panelToZero();
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());

                    isMenuClicked = false;
                    isBarClicked = false;
                    isMClicked = false;
                    clickCate.Stop();
                    clickCate2.Stop();
                    clickCheck.Stop();
                    clickChangeQ.Stop();
                    clickAddOther.Stop();
                    clickToPay.Stop();
                    clickToCheckOrder.Stop();
                    dragToInsertCard.Stop();
                    // 모든 Invoke 취소
                    CancelInvoke();
                }
            }

            if (hit.collider.gameObject.CompareTag("menuButton") && !hit.collider.gameObject.CompareTag("barPartition")) //메뉴버튼을 눌렀을때.&& 장바구니 창 뒤로 인식이 안되도록 (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());

                    if (isMenuClicked == false)
                    {
                        clickCate.Stop();
                        clickCate2.Stop();

                        clickCheck.Play();
                        isMenuClicked = true;
                    }
                    else if (isBarClicked == true)
                    {
                        if (clickAddOther.isPlaying == true)
                        {
                            if (clickToPay.isPlaying == false && isMClicked == false) //음성이 재생이 안되고 있을때 & 한번 클릭되었는지 여부.
                            {
                                isMClicked = true;
                                Debug.Log("왜 안될까??");
                                Invoke("clickToPay_", 5.0f);
                            }
                        }
                    }
                }


            }

            if (hit.collider.gameObject.CompareTag("buttonEtc") && !hit.collider.gameObject.CompareTag("confirmPartition")) //기타 버튼을 눌렀을때. ex.+ / - / x 버튼. (내가 넣은 코드.)
                                                                                                                            //&& 주문내역 확인창 떴을때 인식 안되도록.
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("card")) //카드를 움직여서 이동하기 위함. (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.transform.position = Lhand.transform.position + ray.direction * 0.5f;
                    hit.collider.gameObject.transform.parent = Lhand.transform;
                    lineR.SetPosition(1, hit.point);
                    hit.collider.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                    StartCoroutine(VibeCard());
                }
                if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    GameObject location = GameObject.Find(hit.collider.gameObject.name + "_");
                    hit.collider.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                    hit.collider.gameObject.transform.parent = location.transform;
                    hit.collider.gameObject.transform.localPosition = new Vector3(2.645f, 2.4943f, -0.6345f);
                }
            }
        }
        else if (hitButton01 == true)
        {
            hitButton01 = false;
            changeColor01.Invoke(hitButton01);
        }
        else if (hitButton02 == true)
        {
            hitButton02 = false;
            changeColor02.Invoke(hitButton02);
        }

        if (optionScreen.activeSelf == true && optionSwitch == true) //옵션창이 열려있을때
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                KioWindow.SetActive(true);
                KioskCol.enabled = true;

                optionScreen.SetActive(false);
                optionSwitch = false;
            }
        }
        else if (optionScreen.activeSelf == false && optionSwitch == false) //옵션창이 닫혀있을때
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                KioWindow.SetActive(false);
                KioskCol.enabled = false;

                optionScreen.SetActive(true);
                optionSwitch = true;
                optionScreen.transform.position = cameraCenter.transform.position + cameraCenter.transform.forward * 0.85f;
                optionScreen.transform.forward = cameraCenter.transform.forward;
                //옵션창이 현재 사용자가 바라보는 방향의 앞쪽에 나올수있도록
            }
        }
    }

    IEnumerator VibeHandle()
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
    }

    IEnumerator VibeButtons()
    {
        OVRInput.SetControllerVibration(0.1f, 0.5f, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
    }

    IEnumerator VibeCard()
    {
        OVRInput.SetControllerVibration(0.05f, 0.5f, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
    }

    void clickToAddOther()
    {
        clickAddOther.Play();
    }

    void clickToPay_()
    {
        clickToPay.Play();
    }
}
