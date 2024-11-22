using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Con : MonoBehaviour
{
    GameObject menu;

    void Start()
    {
        menu = GameObject.Find("SelectMenuScreen");
        menu.SetActive(false);
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
}
