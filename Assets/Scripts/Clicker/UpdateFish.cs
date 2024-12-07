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
    }

    private void ClickerLogic_OnSpacePressed(object sender, ClickerLogic.OnSpacePressedEventArgs e) {
        Debug.Log("Space! " + e.spaceCount);
        fishText.text = "Pets: " + e.spaceCount;
    }

}
