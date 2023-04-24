using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySplash : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audio;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        if (!GameManager.Instance.paused){
            audio.Play();
            GameManager.Instance.riverEcon++;
            // print(GameManager.Instance.riverEcon);
            DelaySplash();
        }
    }

    public IEnumerator DelaySplash() {
        print("Delay");
        yield return new WaitForSeconds(0.5f);
    }
}
