using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI calendarYear;
    
    public GameObject pauseButton;
    public GameObject playButton;

    public GameObject helpButtonOpen;
    public GameObject helpButtonClose;
    
    public GameObject healthBar;
    public GameObject beautyBar;
    
    private int previousTime;

    //for making these update properly
    public TextMeshProUGUI item1text;
    public TextMeshProUGUI item2text;
    //public TextMeshProUGUI item3text; -> currently unused, need to add the health and beauty recovery items but we probably won't get those done by tuesday
    public TextMeshProUGUI UpgradeText;

    //from game manager
    public TextMeshProUGUI factorySubscript;
    public TextMeshProUGUI boatSubscript;

    
    //shop buttons
    public GameObject incomeUpgradeButton;
    public GameObject factoryUpgradeButton;
    public GameObject boatUpgradeButton;

    public GameObject factory;
    public AudioSource factoryClip;
    public GameObject touristBoat;
    public GameObject dock;

    //for tourism
    public float adjustedTourism;

    // Start is called before the first frame update
    void Start()
    {
        previousTime = 1972;
        touristBoat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.paused){
            GameManager.Instance.timer++;
            
        }
        GameManager.Instance.actualTime = 1972 + (GameManager.Instance.timer / GameManager.Instance.timePassing);
        if (previousTime != GameManager.Instance.actualTime){
            previousTime = 1972 + (GameManager.Instance.timer / GameManager.Instance.timePassing);
            healthAdjust(5);
            beautyAdjust(5);
            for (int i = 0; i < GameManager.Instance.factoryNumber; i++) 
                {
                    healthAdjust(-2);
                    beautyAdjust(-2);
                    print("you have factories");
                }
            GameManager.Instance.money += (GameManager.Instance.moneyGains + (int)adjustedTourism);
        }
        scoreText.text = "$" + GameManager.Instance.money.ToString();
        calendarYear.text = GameManager.Instance.actualTime.ToString();
        item1text.text = "$" + GameManager.Instance.item1Price.ToString();
        item2text.text = "$" + GameManager.Instance.item2Price.ToString();
        UpgradeText.text = "$" + GameManager.Instance.UpgradeCost.ToString();


        // from GameManager
        //Disable the upgrade buy button when the player cannot afford.
        if (GameManager.Instance.money < GameManager.Instance.UpgradeCost) {
            incomeUpgradeButton.SetActive(false);
        } else {
            incomeUpgradeButton.SetActive(true);
        }
        
        //Disable the boat buy button when the player cannot afford.
        if (GameManager.Instance.money < GameManager.Instance.item1Price) {
            boatUpgradeButton.SetActive(false);
        } else {
            boatUpgradeButton.SetActive(true);
        }

        //Disable the factory buy button when player cannot afford.
        if (GameManager.Instance.money < GameManager.Instance.item2Price) {
            factoryUpgradeButton.SetActive(false);
        } else {
            factoryUpgradeButton.SetActive(true);
        }

        if ((GameManager.Instance.actualTime == 1980) && (!GameManager.Instance.hasEvent1)){
            GameManager.Instance.hasEvent1 = true;
            levelPause();
            GameManager.Instance.item2Price *= 2;
            beautyAdjust(-10);
            SceneManager.LoadScene("flood_event");
        }
        else if ((GameManager.Instance.actualTime == 1990) && (!GameManager.Instance.hasEvent2)){
            GameManager.Instance.hasEvent2 = true;
            levelPause();
            healthAdjust(-10);
            beautyAdjust(-10);
            GameManager.Instance.item2Price /= 2;
            SceneManager.LoadScene("Algal_Event");
        }
        else if ((GameManager.Instance.actualTime == 2000) && (!GameManager.Instance.hasEvent3)){
            GameManager.Instance.hasEvent3 = true;
            levelPause();
            healthAdjust(-10);
            beautyAdjust(-10);
            SceneManager.LoadScene("Ecoli_Event");
        }
        else if ((GameManager.Instance.actualTime == 2010) && (!GameManager.Instance.hasEvent4)){
            GameManager.Instance.hasEvent4 = true;
            levelPause();
            if (GameManager.Instance.purchasedFactory){
                GameManager.Instance.factoryNumber /= 2;
                GameManager.Instance.moneyGains /= 2;
            } else {
                beautyAdjust(20);
                GameManager.Instance.riverEcon /= 2;
            }
            SceneManager.LoadScene("Land_Purchase");
        }

    }

    public void levelPause(){
        GameManager.Instance.pause();
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void levelUnpause(){
        GameManager.Instance.unpause();
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    public void openHelp(){
        helpButtonOpen.SetActive(false);
        helpButtonClose.SetActive(true);
    }

    public void closeHelp(){
        helpButtonClose.SetActive(false);
        helpButtonOpen.SetActive(true);
    }

    public void faster(){
        GameManager.Instance.timePassing /= 2;
    }

    public void slower(){
        GameManager.Instance.timePassing *= 2;
    }

    public void healthAdjust(float change){
        if (GameManager.Instance.ecosystemHealth + change > GameManager.Instance.maxHealth){
            float healthmax = 3f * (GameManager.Instance.maxHealth/100);
            healthBar.transform.localScale = new Vector3(0.5f,healthmax,1f);
            GameManager.Instance.ecosystemHealth = 100f;
        } else{
            float healingfraction = (change/100f) * 3f;
            healthBar.transform.localScale += new Vector3(0f,healingfraction,0f);
            if (change > 0){
                GameManager.Instance.Heal(change);
            }
            else{
                GameManager.Instance.TakeDamage(change);
            }
        }

        HealthAudioAdjust(GameManager.Instance.ecosystemHealth, GameManager.Instance.healthMusic);
    }

    private void HealthAudioAdjust(float health, AudioClip[] healthMusic) {
        print(health);
        if (health >= 76) {
            AudioManager.Instance.SwapTrack(healthMusic[0]);
            print("First Quarter");
        } else if (health >= 51 && health <= 75) {
            AudioManager.Instance.SwapTrack(healthMusic[1]);
            print("Second Quarter");
        } else if (health >= 26 && health <= 50) {
            AudioManager.Instance.SwapTrack(healthMusic[2]);
            print("Third Quarter");
        } else {
            AudioManager.Instance.SwapTrack(healthMusic[3]);
            print("Fourth Quarter");
        }
    }

    public void beautyAdjust(float change){
        if (GameManager.Instance.riverBeauty + change > GameManager.Instance.maxBeauty){
            float beautymax = 3f * (GameManager.Instance.maxBeauty/100);
            beautyBar.transform.localScale = new Vector3(0.5f,beautymax,1f);
            GameManager.Instance.riverBeauty = 100f;
        } else if(GameManager.Instance.riverBeauty + change < 0) {
            beautyBar.transform.localScale = new Vector3(0.5f,0f,1f);
            GameManager.Instance.riverBeauty = 0f;
        } else {
            float beautyfraction = (change/100f) * 3f;
            beautyBar.transform.localScale += new Vector3(0f,beautyfraction,0f);
            if (change > 0){
                GameManager.Instance.Cleansing(change);
            }
            else{
                GameManager.Instance.Ruination(change);
            }
        }
        adjustedTourism = GameManager.Instance.boatGains * (GameManager.Instance.riverBeauty / 100);

    }

    public void buyItem1(){
        GameManager.Instance.item1();
        print("boat buy check");
        if (!GameManager.Instance.purchasedBoat) {
                touristBoat.SetActive(true);
                dock.SetActive(true);
                GameManager.Instance.purchasedBoat = true;
            }
            boatSubscript.text = GameManager.Instance.boatNumber.ToString();
    }

    public void buyItem2(){
        GameManager.Instance.item2();
        if (!GameManager.Instance.purchasedFactory) {
                factory.SetActive(true);
                GameManager.Instance.purchasedFactory = true;
            }
            factorySubscript.text = GameManager.Instance.factoryNumber.ToString();
    }

    public void buyUpgrade(){
        GameManager.Instance.upgrade();
    }
}
