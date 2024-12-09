using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{
    public GameObject panel01;
    public GameObject panel02;
    void Start()
    {
        panel01 = GameObject.Find("Panel01");
        panel01.SetActive(true);
        panel02 = GameObject.Find("Panel02");
        panel02.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void Restart() //����ȭ������ ���ư��� ��ư
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Quit() //���α׷� �����ư
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void StartPanel02()
    {
        panel01.SetActive(false);
        panel02.SetActive(true);
    }
}
