using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance { get; private set; }
    public int riverEcon;
    public int timer;
    public int actualTime;
    public float ecosystemHealth;
    public int riverBeauty;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI calendarYear;
    public bool paused;
    public int timePassing;
    public int ClickPower;

    //shop
    public int item1Price;
    public TextMeshProUGUI item1text;
    public int item2Price;
    public TextMeshProUGUI item2text;
    public int item3Price;
    public TextMeshProUGUI item3text;

    //click upgrade
    public int UpgradeCost;
    public TextMeshProUGUI UpgradeText;

    // input for healthbar sprite;
    public GameObject healthBar;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        riverEcon = 0;
        timer = 0;
        actualTime = 0;
        ecosystemHealth = 100f;
        riverBeauty = 100;
        timePassing = 2000;
        paused = false;
        ClickPower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((actualTime > 2023) && (riverEcon < 50))
        {
            SceneManager.LoadScene("Game Over");
            riverEcon = 0;
            timer = 0;
            actualTime = 0;
            riverBeauty = 100;
            timePassing = 2000;
            paused = true;
        }
        else if ((actualTime > 2023))
        {
            SceneManager.LoadScene("Credits");
            riverEcon = 0;
            timer = 0;
            actualTime = 0;
            riverBeauty = 100;
            timePassing = 2000;
            paused = true;
        }

        //shop
        //item1text.text = "$" + item1Price;
        //item2text.text = "$" + item2Price;
        //item3text.text = "$" + item3Price;


        //upgrade
        //UpgradeText.text = "Cost: $" + UpgradeCost;


        // temp inputs to test health system
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(25);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(25);
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
        print("Poverty");
        print(riverEcon);
        print(UpgradeCost);
        if (riverEcon >= UpgradeCost)
        {
            print("purchased");
            riverEcon -= UpgradeCost;
            riverEcon *= 2;
            UpgradeCost *= 3;
        }


    }

    public void pause()
    {
        paused = true;
    }

    public void unpause()
    {
        paused = false;
    }

    // lowers health
    public void TakeDamage(float damage)
    {
        ecosystemHealth -= damage;

        //this currently adds 1. the y of the health bar is 7.363... but there's an inherent issue of it not 
        //sticking to a spot on the ground. We can change that by adding a movement change after each damage change, 
        //or just making the whole thing twice the size and then hiding the lower half beneath the land so it looks like it shirnks properly
        float damagefraction = (damage/100f) * 7.36339f;
        healthBar.transform.localScale += new Vector3(0f,-damagefraction,0f);

        //ecosystemHealth / 100f;
    }
    // increases health
    public void Heal(float healingAmount)
    {
        ecosystemHealth += healingAmount;
        ecosystemHealth = Mathf.Clamp(ecosystemHealth, 0, 100);
        //healthBar.fillAmount = ecosystemHealth / 100f;
    }


}
