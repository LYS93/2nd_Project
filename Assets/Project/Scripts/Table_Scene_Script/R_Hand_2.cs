using Meta.WitAi.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class R_Hand_2 : MonoBehaviour
{
    GameObject Rhand;
    LineRenderer lineR;
    Ray ray;
    RaycastHit hit;
    public UnityEvent<bool> changeColor01 = new UnityEvent<bool>();
    bool hitButton01;
    public UnityEvent<bool> changeColor02 = new UnityEvent<bool>();
    bool hitButton02;
    Coroutine vibeHandle;
    Coroutine vibeButtons; //버튼클릭시 진동 (내가 넣은 스크립트.)


    GameObject cameraCenter;

    //메서드 사용을 위해 스크립트 참조
    Camera_Move cammove;

    L_Hand_2 lHand;

    bool ischaracterEnter = false; //발판 이전 키오스크 화면 클릭 막기위한 플래그.

    Vector3 KioskDirection = new Vector3(1.86f, 2.3f, -1.22f);//코루틴을 위해 가져옴.
    Vector3 TurnAngles = new Vector3(-1.5f, 1, 0.001f);//코루틴을 위해 가져옴.

    BoxCollider BoxCol; // 키오스크 콜라이더 비활성화를 위한 메서드.

    //스크립트 참조
    PanelmanagerScript panelManager;

    public GameObject KioWindow;// 키오스크 화면 껐다 켰다.
    BoxCollider KioskCol; // 옵션창 띄울때 키오스크의 콜라이더에 옵션창이 막히지 않도록 껐다켰다. 

    // Start is called before the first frame update
    void Start()
    {
        Rhand = GameObject.Find("RightHandAnchor");
        transform.position = Rhand.transform.position;
        transform.eulerAngles = Rhand.transform.eulerAngles;
        transform.parent = Rhand.transform;

        lineR = GetComponent<LineRenderer>();

        cameraCenter = GameObject.Find("CenterEyeAnchor");
        lHand = GameObject.Find("leftHand").GetComponent<L_Hand_2>();

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

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
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

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
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

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    ischaracterEnter = true;
                }
            }

            if (hit.collider.gameObject.CompareTag("KioskFront")) //카메라 키오스크 정면 이동. (내가 넣은 코드.)
            {
                if (ischaracterEnter == true)
                {
                    lineR.material.color = Color.blue;

                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                    {
                        BoxCol.enabled = false; //추가해야하는지 확인부터
                        cammove.Camera_moveToKiosk();//카메라 이동.
                    }
                }                
            }

            if (hit.collider.gameObject.CompareTag("order")) //키오스크 화면 전환. 광고> 메뉴화면. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }


            if (hit.collider.gameObject.CompareTag("cateChicken")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateFriedrice")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateSide")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateNoodle")) //키오스크 메뉴 화면 전환. (내가 넣은 코드.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("bar")) //장바구니. (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("goAd")) //키오스크 처음화면. (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    // 패널 초기화
                    panelManager.panelSetfalse();
                    panelManager.panelToZero();
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("menuButton") && !hit.collider.gameObject.CompareTag("barPartition")) //메뉴버튼을 눌렀을때.&& 장바구니 창 뒤로 인식이 안되도록 (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }

            }

            if (hit.collider.gameObject.CompareTag("buttonEtc") && !hit.collider.gameObject.CompareTag("confirmPartition")) //기타 버튼을 눌렀을때. ex.+ / - / x 버튼. (내가 넣은 코드.)
                                                                                                                            //&& 주문내역 확인창 떴을때 인식 안되도록.
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }


            if (hit.collider.gameObject.CompareTag("card")) //카드를 움직여서 이동하기 위함. (내가 넣은 코드.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.transform.position = Rhand.transform.position + ray.direction * 0.5f;
                    hit.collider.gameObject.transform.parent = Rhand.transform;
                    lineR.SetPosition(1, hit.point);
                    hit.collider.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                    StartCoroutine(VibeCard());
                }
                if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
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

        if (lHand.optionScreen.activeSelf == true && lHand.optionSwitch == true) //옵션창이 열려있을때
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                KioWindow.SetActive(true);
                KioskCol.enabled = true;

                lHand.optionScreen.SetActive(false);
                lHand.optionSwitch = false;
            }
        }
        else if (lHand.optionScreen.activeSelf == false && lHand.optionSwitch == false) //옵션창이 닫혀있을때
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                KioWindow.SetActive(false);
                KioskCol.enabled = false;

                lHand.optionScreen.SetActive(true);
                lHand.optionSwitch = true;
                lHand.optionScreen.transform.position = cameraCenter.transform.position + cameraCenter.transform.forward * 0.85f;
                lHand.optionScreen.transform.forward = cameraCenter.transform.forward;
                //옵션창이 현재 사용자가 바라보는 방향의 앞쪽에 나올수있도록
            }
        }

        


    }

    IEnumerator VibeHandle()
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }

    IEnumerator VibeButtons()
    {
        OVRInput.SetControllerVibration(0.1f, 0.5f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }

    IEnumerator VibeCard()
    {
        OVRInput.SetControllerVibration(0.05f, 0.5f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }
}
