using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelMain;
    public GameObject panelCoffee;
    public GameObject panelTea;
    public GameObject panelFood;
    public GameObject panelCoffeemenu;

    bool startSwitch;
    void Start()
    {
        panelStart = GameObject.Find("Panel(start)");
        panelStart.SetActive(true);
        panelMain = GameObject.Find("Panel(MainScreen)");
        panelMain.SetActive(false);
        panelCoffee = GameObject.Find("Panel(CoffeeLatteSelect)");
        panelCoffee.SetActive(false);
        panelTea = GameObject.Find("Panel(TeaAdeSelect)");
        panelTea.SetActive(false);
        panelFood = GameObject.Find("Panel(FoodSelect)");
        panelFood.SetActive(false);
        panelCoffeemenu = GameObject.Find("Panel(CoffeeMenu)");
        panelCoffeemenu.SetActive(false);
    }

    
    void Update()
    {
        if (panelMain.activeSelf == true && startSwitch == false)
        {
            panelCoffee.SetActive(true);
            panelCoffeemenu.SetActive(true);
            startSwitch = true;
        }
    }
    public void Restart() //시작화면으로 돌아가는 버튼
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Quit() //프로그램 종료버튼
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void StartMainScreen()
    {
        panelMain.SetActive(true);
        panelStart.SetActive(false);
    }
    public void Gostart()
    {
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelStart.SetActive(true);
        startSwitch = false;
    }
    public void CoffeeMenu()
    {
        panelCoffee.SetActive(true);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
    }
    public void TeaMenu()
    {
        panelCoffee.SetActive(false);
        panelTea.SetActive(true);
        panelFood.SetActive(false);
    }
    public void FoodMenu()
    {
        panelCoffee.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(true);
    }
}
