using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerLogic : MonoBehaviour {

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    public class OnSpacePressedEventArgs : EventArgs {
        public int spaceCount;
    }

    public delegate void ClickerLogicDelegate(float f);

    private int spaceCount;
    private void Start() {

    }


    private void Update() {
        
        if (remainingTime > 0) {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0) {
            remainingTime = 0;
            // GameOver();
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Space pressed!
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });
        }
    }
}