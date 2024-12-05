using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateFish : MonoBehaviour
{
    public TMP_Text fishText;
    private int pets;

    private void Start() {
        ClickerLogic clickerLogic = GetComponent<ClickerLogic>();
        clickerLogic.OnSpacePressed += ClickerLogic_OnSpacePressed;
        clickerLogic.OnFloatEvent += ClickerLogic_OnFloatEvent;
        clickerLogic.OnActionEvent += ClickerLogic_OnActionEvent;
    }

    private void ClickerLogic_OnActionEvent(bool arg1, int arg2) {
        Debug.Log(arg1 + " " + arg2);
    }

    private void ClickerLogic_OnFloatEvent(float f) {
        Debug.Log("float: " + f);
    }

    private void ClickerLogic_OnSpacePressed(object sender, ClickerLogic.OnSpacePressedEventArgs e) {
        Debug.Log("Space! " + e.spaceCount);
    }

    public void AddFish()
    {
        pets++;
        fishText.text = "Pets: " + pets;
    }
}
