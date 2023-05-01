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
    public bool purchasedFactory;
    public bool purchasedBoat;
    
    //now handled in levelmanager
    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI calendarYear;
    
    //maximums
    public float maxHealth;
    public float maxBeauty;
    
    public bool paused;
    public int timePassing;
    public int ClickPower;

   //shop - the texts are covered in levelmanager
    public int item1Price; //This is the boat price.
    //public TextMeshProUGUI item1text;
    public int item2Price; //This is the factory price.
    //public TextMeshProUGUI item2text;
    public int item3Price;
    //public TextMeshProUGUI item3text;
    
    //Shop buttons 
    // public GameObject incomeUpgradeButton;
    // public GameObject factoryUpgradeButton;
    // public GameObject boatUpgradeButton;

    // public GameObject factory;
    // public AudioSource factoryClip;
    // public GameObject touristBoat;
    // public GameObject dock;

    public AudioClip[] healthMusic;

    //money gains
    public int riverEcon;
    public int moneyGains;
    public int factoryNumber;
    public int boatNumber;

    //click upgrade
    public int UpgradeCost;
    //moved to levelManager
    //public TextMeshProUGUI UpgradeText;
    //public TextMeshProUGUI factorySubscript;
    //public TextMeshProUGUI boatSubscript;
    
    // input for healthbar sprite;
    //unnecessary now
    //public GameObject healthBar;

    //Random event
    public bool nowIsEvent;
    //public GameObject weather;

    public bool hasEvent1;
    public bool hasEvent2;
    public bool hasEvent3;
    public bool hasEvent4;
    
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
        riverEcon = 1;
        timer = 0;
        actualTime = 0;
        ecosystemHealth = 100f;
        maxHealth = 100;
        riverBeauty = 100;
        maxBeauty = 100;
        timePassing = 2000;
        paused = true;
        ClickPower = 1;
        factoryNumber = 0;
        boatNumber = 0;
        UpgradeCost = 20;
        item1Price = 5;
        item2Price = 10;
        purchasedFactory = false;
        //moved to levelManager
        //touristBoat.SetActive(false);
        purchasedBoat = false;
        money = 0;
        hasEvent1 = false;
        hasEvent2 = false;
        hasEvent3 = false;
        hasEvent4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ecosystemHealth < 1)
        {
            SceneManager.LoadScene("Game Over");
            riverEcon = 5;
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
            UpgradeCost = 20;
            item1Price = 5;
            item2Price = 10;
            money = 0;
            hasEvent1 = false;
            hasEvent2 = false;
            hasEvent3 = false;
            hasEvent4 = false;
        }
        else if ((actualTime > 2023))
        {
            SceneManager.LoadScene("Credits");
            riverEcon = 5;
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
            UpgradeCost = 20;
            item1Price = 5;
            item2Price = 10;
            money = 0;
            hasEvent1 = false;
            hasEvent2 = false;
            hasEvent3 = false;
            hasEvent4 = false;
        }
        else if ((actualTime == 1980) && (!hasEvent1)){
            hasEvent1 = true;
            pause();
            SceneManager.LoadScene("flood_event");
        }
        else if ((actualTime == 1990) && (!hasEvent2)){
            hasEvent2 = true;
            pause();
            SceneManager.LoadScene("put something here");
        }
        else if ((actualTime == 2000) && (!hasEvent3)){
            hasEvent3 = true;
            pause();
            SceneManager.LoadScene("put something here");
        }
        else if ((actualTime == 2010) && (!hasEvent4)){
            hasEvent4 = true;
            pause();
            SceneManager.LoadScene("put something here");
        }


        //moved to levelManager
        // //Disable the upgrade buy button when the player cannot afford.
        // if (money < UpgradeCost) {
        //     incomeUpgradeButton.SetActive(false);
        // } else {
        //     incomeUpgradeButton.SetActive(true);
        // }
        
        // //Disable the boat buy button when the player cannot afford.
        // if (money < item1Price) {
        //     boatUpgradeButton.SetActive(false);
        // } else {
        //     boatUpgradeButton.SetActive(true);
        // }

        // //Disable the factory buy button when player cannot afford.
        // if (money < item2Price) {
        //     factoryUpgradeButton.SetActive(false);
        // } else {
        //     factoryUpgradeButton.SetActive(true);
        // }

        //shop
        //item1text.text = "$" + item1Price;
        //item2text.text = "$" + item2Price;
        //item3text.text = "$" + item3Price;
        

        //upgrade
        //UpgradeText.text = "Cost: $" + UpgradeCost;


        // temp inputs to test health system
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(-25);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(25);
        }

        //Random event
        //if(nowIsEvent == false && time is not a specific year){
        //    StartCoroutine(WaitForEvent());

        //}

        //if(nowIsEvent == true && time is a specific year){


        //}

    }

    public void item1() //tourism boat
    {
        if(money >= item1Price){
            money -= item1Price;
            moneyGains += 5;
            boatNumber++;
            item1Price *= 2;
            
            // moved to levelManager
            // if (!purchasedBoat) {
            //     touristBoat.SetActive(true);
            //     dock.SetActive(true);
            // }
            // boatSubscript.text = boatNumber.ToString();

            //amount += 5;
            //profit += 5;
        }


    }

    public void item2() //factory
    {
        if(money >= item2Price){
            money -= item2Price;
            moneyGains += 10;
            factoryNumber++;
            item2Price *= 2;

            //moved to levelManager
            // if (!purchasedFactory) {
            //     factory.SetActive(true);
            //     purchasedFactory = true;
            // }
            // factorySubscript.text = factoryNumber.ToString();
            

            // StartCoroutine(PlayAndDelay());
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
    // public IEnumerator PlayAndDelay() {
    //     factoryClip.Play();
    //     yield return new WaitForSeconds(3f);
    // }
    //
    // private void PlayFactoryClip() {
    //     factoryClip.Play();
    //     print("Factory Clip");
    // }

    public void HarmfulEvent(){
        //TakeDamage();
        //nowIsEvent = false;

    }

    IEnumerator WaitForEvent(){
        yield return new WaitForSeconds(5f);
        int x = 0;
        x = Random.Range(1, 3);

        
    }

    //public void
    

}
