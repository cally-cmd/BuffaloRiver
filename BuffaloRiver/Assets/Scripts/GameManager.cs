using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance {get; private set;}
    public int riverEcon;

    void Awake() {
       if (Instance == null) {
           Instance = this;
           DontDestroyOnLoad(gameObject);
       } else {
           Destroy(gameObject);
       }
    }
    void Start()
    {
        riverEcon = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
