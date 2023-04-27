using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {
  
  public AudioSource factoryClip;

  public void PlayFactoryClip() {
    factoryClip.Play();
    print("Factory Clip");
  }

  // public IEnumerator PlayAndDelay() {
  //   yield return new WaitForSeconds(3f);
  //   PlayFactoryClip();
  // }

}
