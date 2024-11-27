using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Left_Hand : MonoBehaviour
{
    GameObject Lhand;
    LineRenderer lineR;
    Ray ray;
    RaycastHit hit;
    public UnityEvent<bool> changeColor01 = new UnityEvent<bool>();
    bool hitButton01; //각각 버튼마다 따로 설정해야 각각 작동함 색을 바꾸기위해 유니티 이벤트를 사용
    public UnityEvent<bool> changeColor02 = new UnityEvent<bool>();
    bool hitButton02;
    public UnityEvent<bool> changeColor03 = new UnityEvent<bool>();
    bool hitButton03;
    public UnityEvent<bool> changeColor04 = new UnityEvent<bool>();
    bool hitButton04;
    public UnityEvent<bool> changeColor05 = new UnityEvent<bool>();
    bool hitButton05;
    public UnityEvent<bool> changeColor06 = new UnityEvent<bool>();
    bool hitButton06;
    Coroutine vibeHandle; //버튼 클릭시 진동을 주기위함

    GameObject startScreen; //시작화면
    GameObject selectScreen; //키오스크 선택화면(스탠드,테이블)
    GameObject tutorialScreen; //튜토리얼 화면

    void Start()
    {
        Lhand = GameObject.Find("LeftHandAnchor"); //오른손 컨트롤러를 따라다니도록
        transform.position = Lhand.transform.position;
        transform.eulerAngles = Lhand.transform.eulerAngles;
        transform.parent = Lhand.transform;

        lineR = GetComponent<LineRenderer>();

        startScreen = GameObject.Find("StartScreen");
        selectScreen = GameObject.Find("SelectScreen");
        //selectScreen.SetActive(false); //시작할때 선택화면 꺼두기
        tutorialScreen = GameObject.Find("TutorialScreen");
        //tutorialScreen.SetActive(false); //시작할때 튜토리얼화면 꺼두기
    }


    void Update()
    {
        ray.origin = transform.position; //오른손을 시작으로 레이가 시작
        ray.direction = transform.forward; //레이의 방향은 앞쪽
        lineR.SetPosition(0, ray.origin); //레이를 눈에 보이도록 시작은 오른손
        lineR.SetPosition(1, ray.direction * 8); //레이의 길이
        lineR.material.color = Color.cyan; //레이의 색

        if (Physics.Raycast(ray, out hit, 100f)) //레이를 100거리만큼 발사
        {
            lineR.SetPosition(0, ray.origin);
            lineR.SetPosition(1, hit.point); //레이가 콜라이더를 가진 어떤 오브젝트에 부딪히면 거기까지만 보이도록

            if (hit.collider.gameObject.CompareTag("startscreen")) //레이가 시작화면에 부딪히면
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)) //오른쪽 컨트롤러의 인덱스버튼을 누르면
                {
                    hit.collider.gameObject.SetActive(false); //해당 시작화면 비활성화
                }
            }

            if (hit.collider.gameObject.CompareTag("button01")) //테그 버튼01(시작버튼)
            {
                if (hitButton01 == false) //유니티이벤트로 선택된 버튼의 색을 바꾸기위함
                {
                    hitButton01 = true;
                    changeColor01.Invoke(hitButton01);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke(); //해당버튼을 작동(여기서는 선택화면을 활성화시킴)
                    StartCoroutine(VibeHandle()); //진동
                }
            }
            if (hit.collider.gameObject.CompareTag("button02")) //테그 버튼02(튜토리얼버튼)
            {
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
            if (hit.collider.gameObject.CompareTag("button03")) //테그 버튼03(종료버튼)
            {
                if (hitButton03 == false)
                {
                    hitButton03 = true;
                    changeColor03.Invoke(hitButton03);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }

            if (hit.collider.gameObject.CompareTag("off")) //튜토리얼 종료버튼
            {
                if (hitButton06 == false)
                {
                    hitButton06 = true;
                    changeColor06.Invoke(hitButton06);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }

            if (hit.collider.gameObject.CompareTag("stand")) //선택화면에서 스탠드키오스크버튼
            {
                if (hitButton04 == false) //스탠드키오스크버튼과 테이블키오스크버튼을 옮겨다닐때 색을 바꾸도록
                {
                    hitButton04 = true;
                    changeColor04.Invoke(hitButton04);
                }
                if (hitButton05 == true)
                {
                    hitButton05 = false;
                    changeColor05.Invoke(hitButton05);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }
            if (hit.collider.gameObject.CompareTag("table")) //선택화면에서 테이블키오스크버튼
            {
                if (hitButton05 == false)
                {
                    hitButton05 = true;
                    changeColor05.Invoke(hitButton05);
                }
                if (hitButton04 == true)
                {
                    hitButton04 = false;
                    changeColor04.Invoke(hitButton04);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }
        }
        else if (hitButton01 == true) //각각 버튼들이 선택되지 않았을때 다시 색을 바꾸도록
        {
            hitButton01 = false;
            changeColor01.Invoke(hitButton01);
        }
        else if (hitButton02 == true)
        {
            hitButton02 = false;
            changeColor02.Invoke(hitButton02);
        }
        else if (hitButton03 == true)
        {
            hitButton03 = false;
            changeColor03.Invoke(hitButton03);
        }
        else if (hitButton04 == true)
        {
            hitButton04 = false;
            changeColor04.Invoke(hitButton04);
        }
        else if (hitButton05 == true)
        {
            hitButton05 = false;
            changeColor05.Invoke(hitButton05);
        }
        else if (hitButton06 == true)
        {
            hitButton06 = false;
            changeColor06.Invoke(hitButton06);
        }

        //if (!startScreen.activeSelf) //시작화면이 비활성화되면
        //{
        //    selectScreen.SetActive(true); //선택화면 활성화

        //    if (!tutorialScreen.activeSelf) //튜토리얼화면이 비활성화되면
        //    {
        //        selectScreen.SetActive(true);
        //    }
        //    else if (tutorialScreen.activeSelf) //튜토리얼화면이 활성화되면
        //    {
        //        selectScreen.SetActive(false); //선택화면 비활성화
        //    }
        //}
    }
    IEnumerator VibeHandle() //버튼을 클릭할때 진동을 주기위한 코루틴
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
    }
}
