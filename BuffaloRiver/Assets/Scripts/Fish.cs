using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    private float x;
    private float y;
    private float frequency;
    public GameObject fish1;
    //public GameObject fish2;
    private bool jumping;
    private float amplitude;
    void Start()
    {
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        if (jumping) {
            float stop = now + Mathf.PI;
            while (Time.time < stop) {
                x = Mathf.Cos(Time.time * frequency) * amplitude;
                y = Mathf.Sin(Time.time * frequency) * amplitude;

                fish1.transform.position = new Vector2(x, y);
            }
            jumping = false;
            Destroy(fish1);
        }
    }

    public void Jump() {
        Instantiate(fish1);
        jumping = true;
        printTest();
    }

    public void printTest(){
        print("yoooo");
    }
}
