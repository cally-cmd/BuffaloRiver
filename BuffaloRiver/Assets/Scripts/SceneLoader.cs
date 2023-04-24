using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(DelayScene(sceneName));
    }

        public IEnumerator DelayScene(string sceneName) {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);

        
    }
    
}
