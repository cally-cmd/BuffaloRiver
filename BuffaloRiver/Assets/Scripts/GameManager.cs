using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance {get; private set;}
    public int riverEcon;
    public int timer;
    public int actualTime;
    public int ecosystemHealth;
    public int riverBeauty;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI calendarYear;
    public bool paused;
    public int timePassing;

    //shop
    public float currentScore;
    public int item1Price;
    public int item2Price;
    public int item3Price;

    //click upgrade
    public int UpgradeCost;
    public TextMeshProUGUI UpgradeText;
    


    void Awake() {
       if (Instance == null) {
           Instance = this;
           DontDestroyOnLoad(gameObject);
       } else {
           Destroy(gameObject);
       }
    }
    void Start()
    {
        riverEcon = 0;
        timer = 0;
        actualTime = 0;
        ecosystemHealth = 100;
        riverBeauty = 100;
        timePassing = 2000;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((actualTime > 2023) && (riverEcon < 50)){
            SceneManager.LoadScene("Game Over");
            riverEcon = 0;
            timer = 0;
            actualTime = 0;
            ecosystemHealth = 100;
            riverBeauty = 100;
            timePassing = 2000;
            paused = true;
        }
        else if ((actualTime > 2023)){
            SceneManager.LoadScene("Credits");
            riverEcon = 0;
            timer = 0;
            actualTime = 0;
            ecosystemHealth = 100;
            riverBeauty = 100;
            timePassing = 2000;
            paused = true;
        }
    }

    public void item1()
    {
        //if(currentScore >= item1Price){
            //currentScore -= item1Price;
            //amount += 5;
            //profit += 5;
        //}


    }

    public void item2()
    {
        //if(currentScore >= item2Price){
            //currentScore -= item2Price;
            //amount += 2;
            //profit += 2;
        //}

    }

    public void upgrade()
    {


    }

    public void pause(){
        paused = true;
    }

    public void unpause(){
        paused = false;
    }


}
