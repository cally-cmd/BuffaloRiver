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
    
    // Start is called before the first frame update
    void Start()
    {
        previousTime = 1972;
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
            GameManager.Instance.money += GameManager.Instance.moneyGains;
        }
        scoreText.text = GameManager.Instance.money.ToString();
        calendarYear.text = GameManager.Instance.actualTime.ToString();
        item1text.text = "$" + GameManager.Instance.item1Price.ToString();
        item2text.text = "$" + GameManager.Instance.item2Price.ToString();
        UpgradeText.text = "$" + GameManager.Instance.UpgradeCost.ToString();
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

    }


}
