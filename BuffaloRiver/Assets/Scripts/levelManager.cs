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
    public GameObject healthBar;
    public GameObject beautyBar;
    private int previousTime;
    
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
                }
            GameManager.Instance.money += GameManager.Instance.moneyGains;
        }
        scoreText.text = GameManager.Instance.money.ToString();
        calendarYear.text = GameManager.Instance.actualTime.ToString();
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

    public void healthAdjust(float change){
        if (GameManager.Instance.ecosystemHealth + change > GameManager.Instance.maxHealth){
            healthBar.transform.localScale = new Vector3(1f,1f,1f);
        }
        float healingfraction = (change/100f) * 7.36339f;
        healthBar.transform.localScale += new Vector3(0f,healingfraction,0f);
        if (change > 0){
            GameManager.Instance.Heal(change);
        }
        else{
            GameManager.Instance.TakeDamage(change);
        }
    }

    public void beautyAdjust(float change){
        float beautyfraction = (change/100f) * 7.36339f;
        beautyBar.transform.localScale += new Vector3(0f,beautyfraction,0f);
        if (change > 0){
            GameManager.Instance.Cleansing(change);
        }
        else{
            GameManager.Instance.Ruination(change);
        }
    }


}
