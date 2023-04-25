using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish1;
    public GameObject fish2;
    private GameObject obj;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private GameObject WhichFish() {
        int id = Random.Range(0, 2) * 10;
        
        if (id <= 5f) {
            return fish1;
        } else {
            return fish2;
        }
    }

    public void Jump() {

        obj = WhichFish();

        //Float bounds for x position: (-1.6, -3.75)
        //Float bounds for y position: (0.5, 3.5)
        
        float lowerXBound = -3.75f;
        float upperXBound = -1.6f;
        float lowerYBound = 0.5f;
        float upperYBound = 3.5f;

        Vector2 pos = new Vector2(Random.Range(lowerXBound, upperXBound), Random.Range(lowerYBound, upperYBound));

        Instantiate(obj, pos, Quaternion.identity, transform);
    }
}
