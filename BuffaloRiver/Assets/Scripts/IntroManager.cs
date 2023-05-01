using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    public string text;
    public TextMeshProUGUI dialogText;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.DialogShow(dialogText, text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
