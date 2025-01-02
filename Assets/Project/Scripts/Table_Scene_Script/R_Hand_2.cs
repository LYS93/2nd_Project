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
    Coroutine vibeButtons; //��ưŬ���� ���� (���� ���� ��ũ��Ʈ.)


    GameObject cameraCenter;

    //�޼��� ����� ���� ��ũ��Ʈ ����
    Camera_Move cammove;

    L_Hand_2 lHand;

    bool ischaracterEnter = false; //���� ���� Ű����ũ ȭ�� Ŭ�� �������� �÷���.

    Vector3 KioskDirection = new Vector3(1.86f, 2.3f, -1.22f);//�ڷ�ƾ�� ���� ������.
    Vector3 TurnAngles = new Vector3(-1.5f, 1, 0.001f);//�ڷ�ƾ�� ���� ������.

    BoxCollider BoxCol; // Ű����ũ �ݶ��̴� ��Ȱ��ȭ�� ���� �޼���.

    //��ũ��Ʈ ����
    PanelmanagerScript panelManager;

    public GameObject KioWindow;// Ű����ũ ȭ�� ���� �״�.
    BoxCollider KioskCol; // �ɼ�â ��ﶧ Ű����ũ�� �ݶ��̴��� �ɼ�â�� ������ �ʵ��� �����״�. 

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


        //�޼��� ����� ���� ��ũ��Ʈ ����
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

            if (hit.collider.gameObject.CompareTag("button01")) //�������� ���ư��� ��ư
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
            if (hit.collider.gameObject.CompareTag("button02")) //���α׷��� �����ϴ� ��ư
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


            if (hit.collider.gameObject.CompareTag("FootPrint")) //�ڷ���Ʈ. (���� ���� �ڵ�.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    ischaracterEnter = true;
                }
            }

            if (hit.collider.gameObject.CompareTag("KioskFront")) //ī�޶� Ű����ũ ���� �̵�. (���� ���� �ڵ�.)
            {
                if (ischaracterEnter == true)
                {
                    lineR.material.color = Color.blue;

                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                    {
                        BoxCol.enabled = false; //�߰��ؾ��ϴ��� Ȯ�κ���
                        cammove.Camera_moveToKiosk();//ī�޶� �̵�.
                    }
                }                
            }

            if (hit.collider.gameObject.CompareTag("order")) //Ű����ũ ȭ�� ��ȯ. ����> �޴�ȭ��. (���� ���� �ڵ�.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }


            if (hit.collider.gameObject.CompareTag("cateChicken")) //Ű����ũ �޴� ȭ�� ��ȯ. (���� ���� �ڵ�.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateFriedrice")) //Ű����ũ �޴� ȭ�� ��ȯ. (���� ���� �ڵ�.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateSide")) //Ű����ũ �޴� ȭ�� ��ȯ. (���� ���� �ڵ�.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("cateNoodle")) //Ű����ũ �޴� ȭ�� ��ȯ. (���� ���� �ڵ�.)
            {
                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("bar")) //��ٱ���. (���� ���� �ڵ�.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("goAd")) //Ű����ũ ó��ȭ��. (���� ���� �ڵ�.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    // �г� �ʱ�ȭ
                    panelManager.panelSetfalse();
                    panelManager.panelToZero();
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }

            if (hit.collider.gameObject.CompareTag("menuButton") && !hit.collider.gameObject.CompareTag("barPartition")) //�޴���ư�� ��������.&& ��ٱ��� â �ڷ� �ν��� �ȵǵ��� (���� ���� �ڵ�.)
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }

            }

            if (hit.collider.gameObject.CompareTag("buttonEtc") && !hit.collider.gameObject.CompareTag("confirmPartition")) //��Ÿ ��ư�� ��������. ex.+ / - / x ��ư. (���� ���� �ڵ�.)
                                                                                                                            //&& �ֹ����� Ȯ��â ������ �ν� �ȵǵ���.
            {

                lineR.material.color = Color.blue;

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeButtons());
                }
            }


            if (hit.collider.gameObject.CompareTag("card")) //ī�带 �������� �̵��ϱ� ����. (���� ���� �ڵ�.)
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

        if (lHand.optionScreen.activeSelf == true && lHand.optionSwitch == true) //�ɼ�â�� ����������
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                KioWindow.SetActive(true);
                KioskCol.enabled = true;

                lHand.optionScreen.SetActive(false);
                lHand.optionSwitch = false;
            }
        }
        else if (lHand.optionScreen.activeSelf == false && lHand.optionSwitch == false) //�ɼ�â�� ����������
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                KioWindow.SetActive(false);
                KioskCol.enabled = false;

                lHand.optionScreen.SetActive(true);
                lHand.optionSwitch = true;
                lHand.optionScreen.transform.position = cameraCenter.transform.position + cameraCenter.transform.forward * 0.85f;
                lHand.optionScreen.transform.forward = cameraCenter.transform.forward;
                //�ɼ�â�� ���� ����ڰ� �ٶ󺸴� ������ ���ʿ� ���ü��ֵ���
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
