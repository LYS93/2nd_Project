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
    bool hitButton01; //���� ��ư���� ���� �����ؾ� ���� �۵��� ���� �ٲٱ����� ����Ƽ �̺�Ʈ�� ���
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
    Coroutine vibeHandle; //��ư Ŭ���� ������ �ֱ�����

    GameObject startScreen; //����ȭ��
    GameObject selectScreen; //Ű����ũ ����ȭ��(���ĵ�,���̺�)
    GameObject tutorialScreen; //Ʃ�丮�� ȭ��

    void Start()
    {
        Lhand = GameObject.Find("LeftHandAnchor"); //������ ��Ʈ�ѷ��� ����ٴϵ���
        transform.position = Lhand.transform.position;
        transform.eulerAngles = Lhand.transform.eulerAngles;
        transform.parent = Lhand.transform;

        lineR = GetComponent<LineRenderer>();

        startScreen = GameObject.Find("StartScreen");
        selectScreen = GameObject.Find("SelectScreen");
        //selectScreen.SetActive(false); //�����Ҷ� ����ȭ�� ���α�
        tutorialScreen = GameObject.Find("TutorialScreen");
        //tutorialScreen.SetActive(false); //�����Ҷ� Ʃ�丮��ȭ�� ���α�
    }


    void Update()
    {
        ray.origin = transform.position; //�������� �������� ���̰� ����
        ray.direction = transform.forward; //������ ������ ����
        lineR.SetPosition(0, ray.origin); //���̸� ���� ���̵��� ������ ������
        lineR.SetPosition(1, ray.direction * 8); //������ ����
        lineR.material.color = Color.cyan; //������ ��

        if (Physics.Raycast(ray, out hit, 100f)) //���̸� 100�Ÿ���ŭ �߻�
        {
            lineR.SetPosition(0, ray.origin);
            lineR.SetPosition(1, hit.point); //���̰� �ݶ��̴��� ���� � ������Ʈ�� �ε����� �ű������ ���̵���

            if (hit.collider.gameObject.CompareTag("startscreen")) //���̰� ����ȭ�鿡 �ε�����
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)) //������ ��Ʈ�ѷ��� �ε�����ư�� ������
                {
                    hit.collider.gameObject.SetActive(false); //�ش� ����ȭ�� ��Ȱ��ȭ
                }
            }

            if (hit.collider.gameObject.CompareTag("button01")) //�ױ� ��ư01(���۹�ư)
            {
                if (hitButton01 == false) //����Ƽ�̺�Ʈ�� ���õ� ��ư�� ���� �ٲٱ�����
                {
                    hitButton01 = true;
                    changeColor01.Invoke(hitButton01);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke(); //�ش��ư�� �۵�(���⼭�� ����ȭ���� Ȱ��ȭ��Ŵ)
                    StartCoroutine(VibeHandle()); //����
                }
            }
            if (hit.collider.gameObject.CompareTag("button02")) //�ױ� ��ư02(Ʃ�丮���ư)
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
            if (hit.collider.gameObject.CompareTag("button03")) //�ױ� ��ư03(�����ư)
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

            if (hit.collider.gameObject.CompareTag("off")) //Ʃ�丮�� �����ư
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

            if (hit.collider.gameObject.CompareTag("stand")) //����ȭ�鿡�� ���ĵ�Ű����ũ��ư
            {
                if (hitButton04 == false) //���ĵ�Ű����ũ��ư�� ���̺�Ű����ũ��ư�� �ŰܴٴҶ� ���� �ٲٵ���
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
            if (hit.collider.gameObject.CompareTag("table")) //����ȭ�鿡�� ���̺�Ű����ũ��ư
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
        else if (hitButton01 == true) //���� ��ư���� ���õ��� �ʾ����� �ٽ� ���� �ٲٵ���
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

        //if (!startScreen.activeSelf) //����ȭ���� ��Ȱ��ȭ�Ǹ�
        //{
        //    selectScreen.SetActive(true); //����ȭ�� Ȱ��ȭ

        //    if (!tutorialScreen.activeSelf) //Ʃ�丮��ȭ���� ��Ȱ��ȭ�Ǹ�
        //    {
        //        selectScreen.SetActive(true);
        //    }
        //    else if (tutorialScreen.activeSelf) //Ʃ�丮��ȭ���� Ȱ��ȭ�Ǹ�
        //    {
        //        selectScreen.SetActive(false); //����ȭ�� ��Ȱ��ȭ
        //    }
        //}
    }
    IEnumerator VibeHandle() //��ư�� Ŭ���Ҷ� ������ �ֱ����� �ڷ�ƾ
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);
    }
}
