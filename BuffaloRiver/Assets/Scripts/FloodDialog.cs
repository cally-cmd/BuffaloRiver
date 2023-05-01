using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloodDialog : MonoBehaviour {

  public string introDialog;
  public string specificDialog;

  public TextMeshProUGUI dialogText;

  private bool isIntroDialog;

  void Start() {
    isIntroDialog = true;
  }
  
  public void ToggleText() {
    if (isIntroDialog) {
      GameManager.Instance.DialogShow(dialogText, specificDialog);
    } else {
      GameManager.Instance.DialogShow(dialogText, introDialog);
    }

    isIntroDialog = !isIntroDialog;
  }
}
