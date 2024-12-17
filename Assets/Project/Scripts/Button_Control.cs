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
    public GameObject panelLattemenu;
    public GameObject panelTeamenu;
    public GameObject panelAdemenu;
    public GameObject panelNonCoffeemenu;
    public GameObject panelFrappemenu;
    public GameObject panelFoodmenu;
    public GameObject panelOption;

    bool startSwitch;
    bool teaselectSwitch;
    bool foodselectSwitch;
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
        panelLattemenu = GameObject.Find("Panel(LatteMenu)");
        panelLattemenu.SetActive(false);
        panelTeamenu = GameObject.Find("Panel(TeaMenu)");
        panelTeamenu.SetActive(false);
        panelAdemenu = GameObject.Find("Panel(AdeMenu)");
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu = GameObject.Find("Panel(NonCoffeeLatteMenu)");
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu = GameObject.Find("Panel(FrappeMenu)");
        panelFrappemenu.SetActive(false);
        panelFoodmenu = GameObject.Find("Panel(FoodMenu)");
        panelFoodmenu.SetActive(false);
        panelOption = GameObject.Find("Panel(Option)");
        panelOption.SetActive(false);
    }

    
    void Update()
    {
        if (panelMain.activeSelf == true && startSwitch == false && panelCoffee.activeSelf == true)
        {
            panelCoffeemenu.SetActive(true);
            panelLattemenu.SetActive(false);
            panelTeamenu.SetActive(false);
            panelAdemenu.SetActive(false);
            panelNonCoffeemenu.SetActive(false);
            panelFrappemenu.SetActive(false);
            panelFoodmenu.SetActive(false);
            startSwitch = true;
        }
        if(panelMain.activeSelf == true && teaselectSwitch == false && panelTea.activeSelf == true)
        {
            panelCoffeemenu.SetActive(false);
            panelLattemenu.SetActive(false);
            panelTeamenu.SetActive(true);
            panelAdemenu.SetActive(false);
            panelNonCoffeemenu.SetActive(false);
            panelFrappemenu.SetActive(false);
            panelFoodmenu.SetActive(false);
            teaselectSwitch = true;
        }
        if (panelMain.activeSelf == true && foodselectSwitch == false && panelFood.activeSelf == true)
        {
            panelCoffeemenu.SetActive(false);
            panelLattemenu.SetActive(false);
            panelTeamenu.SetActive(false);
            panelAdemenu.SetActive(false);
            panelNonCoffeemenu.SetActive(false);
            panelFrappemenu.SetActive(false);
            panelFoodmenu.SetActive(true);
            foodselectSwitch = true;
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
        panelCoffee.SetActive(true);
    }
    public void Gostart()
    {
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(false);
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
        panelFoodmenu.SetActive(false);
        panelStart.SetActive(true);
        startSwitch = false;
    }
    public void CoffeeMenu()
    {
        panelCoffee.SetActive(true);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
        teaselectSwitch = false;
        foodselectSwitch = false;
    }
    public void TeaMenu()
    {
        panelCoffee.SetActive(false);
        panelTea.SetActive(true);
        panelFood.SetActive(false);
        startSwitch = false;
        foodselectSwitch = false;
    }
    public void FoodMenu()
    {
        panelCoffee.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(true);
        panelFoodmenu.SetActive(true);
        startSwitch = false;
        teaselectSwitch = false;
    }
    public void CoffeeOpen()
    {
        panelCoffeemenu.SetActive(true);
        panelLattemenu.SetActive(false);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
    }
    public void LatteOpen()
    {
        panelCoffeemenu.SetActive(false);
        panelLattemenu.SetActive(true);
        panelTea.SetActive(false);
        panelFood.SetActive(false);
    }
    public void TeaOpen()
    {
        panelTeamenu.SetActive(true);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
    }
    public void AdeOpen()
    {
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(true);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(false);
    }
    public void NonCoffeeOpen()
    {
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(true);
        panelFrappemenu.SetActive(false);
    }
    public void FrappeOpen()
    {
        panelTeamenu.SetActive(false);
        panelAdemenu.SetActive(false);
        panelNonCoffeemenu.SetActive(false);
        panelFrappemenu.SetActive(true);
    }
    public void Americano()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Coldbrew()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Espresso()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Caffelatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Cafemocha()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Cappuccino()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Caramelmacchiato()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelCoffee.SetActive(false);
        panelCoffeemenu.SetActive(false);
    }
    public void Off()
    {
        panelOption.SetActive(false);
        panelMain.SetActive(true);
        panelCoffee.SetActive(true);
        panelCoffeemenu.SetActive(true);
    }
    public void Icetea()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Chamomile()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Peppermint()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Citron()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Grapefruit()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Whitegrape()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Lemon()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Chocolatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Strawberrylatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Grainlatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Greentealatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Sweetpotatolatte()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Strawberrysmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Blueberrysmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Planesmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Mangosmoothie()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Cookiefrappe()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Chocofrappe()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
        panelTea.SetActive(false);
        panelTeamenu.SetActive(false);
    }
    public void Planebagle()
    {
        Debug.Log("dlatl");
    }
    public void Chococake()
    {
        Debug.Log("dlatl");
    }
    public void Milkcake()
    {
        Debug.Log("dlatl");
    }
    public void Croquemonsieur()
    {
        Debug.Log("dlatl");
    }
    public void Croiffle()
    {
        Debug.Log("dlatl");
    }
    public void Honeybread()
    {
        Debug.Log("dlatl");
    }
}
