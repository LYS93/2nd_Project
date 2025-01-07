using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Con : MonoBehaviour
{
    GameObject menu;
    public GameObject tutorial;

    public AudioSource selectAudio;

    void Start()
    {
        menu = GameObject.Find("SelectMenuScreen");
        menu.SetActive(false); //�����Ҷ� ���ĵ�,���̺� ����ȭ�� ��Ȱ��ȭ
        tutorial = GameObject.Find("TutorialScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuOpen() //���ĵ�,���̺� ����ȭ�� �����ư
    {
        menu.SetActive(true);
        selectAudio.Play();
    }
    public void OpenStand() //���ĵ�Ű����ũ��ư
    {
        SceneManager.LoadScene("StandKioskScene");
    }
    public void OpenTable() //���̺�Ű����ũ��ư
    {
        SceneManager.LoadScene("TableKioskScene");
    }
    public void Quit() //���α׷� �����ư
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void TutorialOpen() //Ʃ�丮��ȭ�� �����ư
    {
        tutorial.SetActive(true);
    }
    public void TutorialClose() //Ʃ�丮��ȭ�� �ݱ��ư
    {
        tutorial.SetActive(false);
    }
}
