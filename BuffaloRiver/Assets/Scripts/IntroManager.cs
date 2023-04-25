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
        StartCoroutine(TypeText(text));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeText(string text) {
        dialogText.text = "";
        foreach (char c in text.ToCharArray()) {
            dialogText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
