using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Jump() {
        Instantiate(fish1);
    }
}
