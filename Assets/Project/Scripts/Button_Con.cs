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
        menu.SetActive(false); //시작할때 스탠드,테이블 선택화면 비활성화
        tutorial = GameObject.Find("TutorialScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuOpen() //스탠드,테이블 선택화면 열기버튼
    {
        menu.SetActive(true);
        selectAudio.Play();
    }
    public void OpenStand() //스탠드키오스크버튼
    {
        SceneManager.LoadScene("StandKioskScene");
    }
    public void OpenTable() //테이블키오스크버튼
    {
        SceneManager.LoadScene("TableKioskScene");
    }
    public void Quit() //프로그램 종료버튼
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void TutorialOpen() //튜토리얼화면 열기버튼
    {
        tutorial.SetActive(true);
    }
    public void TutorialClose() //튜토리얼화면 닫기버튼
    {
        tutorial.SetActive(false);
    }
}
