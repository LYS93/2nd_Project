using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Con : MonoBehaviour
{
    GameObject menu;
    public GameObject tutorial;

    void Start()
    {
        menu = GameObject.Find("SelectMenuScreen");
        menu.SetActive(false);
        tutorial = GameObject.Find("TutorialScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuOpen()
    {
        menu.SetActive(true);
    }
    public void OpenStand()
    {
        SceneManager.LoadScene("StandKioskScene");
    }
    public void OpenTable()
    {
        SceneManager.LoadScene("TableKioskScene");
    }
    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void TutorialOpen()
    {
        tutorial.SetActive(true);
    }
    public void TutorialClose()
    {
        tutorial.SetActive(false);
    }
}
