using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI calendarYear;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.paused){
            GameManager.Instance.timer++;
        }
        GameManager.Instance.actualTime = 1972 + (GameManager.Instance.timer / GameManager.Instance.timePassing);
        scoreText.text = GameManager.Instance.riverEcon.ToString();
        calendarYear.text = GameManager.Instance.actualTime.ToString();
    }
}
