using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class L_Hand : MonoBehaviour
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

    public GameObject optionScreen;
    GameObject cameraCenter;

    public bool optionSwitch; //옵션창 열림,닫힘을 확인하기위해 

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
    }


    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        lineR.SetPosition(0, ray.origin);
        lineR.SetPosition(1, ray.direction * 8);
        lineR.material.color = Color.cyan;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            lineR.SetPosition(0, ray.origin);
            lineR.SetPosition(1, hit.point);

            if (hit.collider.gameObject.CompareTag("button01")) //시작으로 돌아가는 버튼
            {
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
                hitButton01 = false;
                changeColor01.Invoke(hitButton01);
                hitButton02 = false;
                changeColor02.Invoke(hitButton02);
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
                optionScreen.SetActive(false);
                optionSwitch = false;
            }
        }
        else if (optionScreen.activeSelf == false && optionSwitch == false) //옵션창이 닫혀있을때
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                optionScreen.SetActive(true);
                optionSwitch = true;
                optionScreen.transform.position = cameraCenter.transform.position + cameraCenter.transform.forward * 1;
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
}
