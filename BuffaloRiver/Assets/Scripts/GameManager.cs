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
    public int timer;
    public int actualTime;
    public float ecosystemHealth;
    public float riverBeauty;
    public int money;
    
    //now handled in levelmanager
    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI calendarYear;
    
    //maximums
    public float maxHealth;
    public float maxBeauty;
    
    public bool paused;
    public int timePassing;
    public int ClickPower;

    //shop
    public int item1Price = 5;
    public TextMeshProUGUI item1text;
    public int item2Price = 10;
    public TextMeshProUGUI item2text;
    public int item3Price = 15;
    public TextMeshProUGUI item3text;

    //money gains
    public int riverEcon;
    public int moneyGains;
    public int factoryNumber;
    public int boatNumber;

    //click upgrade
    public int UpgradeCost;
    public TextMeshProUGUI UpgradeText;

    // input for healthbar sprite;
    //unnecessary now
    //public GameObject healthBar;
    
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
        maxHealth = 100;
        riverBeauty = 100;
        maxBeauty = 100;
        timePassing = 2000;
        paused = false;
        ClickPower = 1;
        factoryNumber = 0;
        boatNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ecosystemHealth < 1)
        {
            SceneManager.LoadScene("Game Over");
            riverEcon = 0;
            timer = 0;
            ecosystemHealth = 100f;
            actualTime = 0;
            maxHealth = 100;
            riverBeauty = 100;
            maxBeauty = 100;
            timePassing = 2000;
            factoryNumber = 0;
            boatNumber = 0;
            paused = true;
        }
        else if ((actualTime > 2023))
        {
            SceneManager.LoadScene("Credits");
            riverEcon = 0;
            timer = 0;
            ecosystemHealth = 100f;
            actualTime = 0;
            maxHealth = 100;
            riverBeauty = 100;
            maxBeauty = 100;
            timePassing = 2000;
            factoryNumber = 0;
            boatNumber = 0;
            paused = true;
        }

        //shop
        item1text.text = "$" + item1Price;
        item2text.text = "$" + item2Price;
        //item3text.text = "$" + item3Price;
        

        //upgrade
        UpgradeText.text = "Cost: $" + UpgradeCost;


        // temp inputs to test health system
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(-25);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(25);
        }

    }

    public void item1()
    {
        if(money >= item1Price){
            money -= item1Price;
            moneyGains += 5;
            boatNumber++;

            //amount += 5;
            //profit += 5;
        }


    }

    public void item2()
    {
        if(money >= item2Price){
            money -= item2Price;
            moneyGains += 10;
            factoryNumber++;

            //amount += 2;
            //profit += 2;
        }

    }

    public void upgrade()
    {
        print("Poverty");
        print(money);
        print(UpgradeCost);
        if (money >= UpgradeCost)
        {
            print("purchased");
            money -= UpgradeCost;
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
        ecosystemHealth += damage;

        //this currently adds 1. the y of the health bar is 7.363... but there's an inherent issue of it not
        //sticking to a spot on the ground. We can change that by adding a movement change after each damage change,
        //or just making the whole thing twice the size and then hiding the lower half beneath the land so it looks like it shirnks properly

        //this is unnecessary because of levelManager having it now
        //float damagefraction = (damage/100f) * 7.36339f;
        //healthBar.transform.localScale += new Vector3(0f,-damagefraction,0f);
    }

    // increases health
    public void Heal(float healingAmount)
    {
        ecosystemHealth += healingAmount;
        
        //someone type in the chat what this does pls
        ecosystemHealth = Mathf.Clamp(ecosystemHealth, 0, 100);
        
        //healthBar.fillAmount = ecosystemHealth / 100f;
        //same as for take damage
        //float healingfraction = (healingAmount/100f) * 7.36339f;
        //healthBar.transform.localScale += new Vector3(0f,healingfraction,0f);
    }

    public void Ruination(float destruction){
        riverBeauty += destruction;
    }

    public void Cleansing(float recovery){
        riverBeauty += recovery;
    }
    

}
