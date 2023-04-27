using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFish : MonoBehaviour
{
  public GameObject obj;

  void OnMouseDown() {
    Destroy(obj);
    GameManager.Instance.money += 2 + GameManager.Instance.riverEcon;
  }
}

