using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class R_Hand : MonoBehaviour
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

    GameObject cameraCenter;
    GameObject cameraRig;

    L_Hand lHand;

    //public bool moveIn;

    //Button_Control buttonCon;

    void Start()
    {
        Rhand = GameObject.Find("RightHandAnchor");
        transform.position = Rhand.transform.position;
        transform.eulerAngles = Rhand.transform.eulerAngles;
        transform.parent = Rhand.transform;

        lineR = GetComponent<LineRenderer>();

        cameraCenter = GameObject.Find("CenterEyeAnchor");
        cameraRig = GameObject.Find("OVRCameraRig");
        lHand = GameObject.Find("leftHand").GetComponent<L_Hand>();

        //buttonCon = GameObject.Find("ButtonControl").GetComponent<Button_Control>();

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

            if(hit.collider.gameObject.CompareTag("option"))
            {
                lineR.material.color = Color.blue;

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

            if(hit.collider.gameObject.CompareTag("foot"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    if (lHand.moveIn == false)
                    {
                        cameraRig.transform.position = new Vector3(0.9f, 0.2f, 0.6f);
                        cameraRig.transform.Rotate(Vector3.up * 90);
                        lHand.moveIn = true;
                        StartCoroutine(VibeHandle());
                    }
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

            }

            if (hit.collider.gameObject.CompareTag("start"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }

            }

            if (hit.collider.gameObject.CompareTag("home"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }

            }
            if (hit.collider.gameObject.CompareTag("coffee"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }

            }
            if (hit.collider.gameObject.CompareTag("drink"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }

            }
            if (hit.collider.gameObject.CompareTag("food"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }

            }
            if (hit.collider.gameObject.CompareTag("plus"))
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
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
                lHand.optionScreen.SetActive(false);
                lHand.optionSwitch = false;
            }
        }
        else if (lHand.optionScreen.activeSelf == false && lHand.optionSwitch == false) //옵션창이 닫혀있을때
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                lHand.optionScreen.SetActive(true);
                lHand.optionSwitch = true;
                lHand.optionScreen.transform.position = cameraCenter.transform.position + cameraCenter.transform.forward * 0.7f;
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
}
