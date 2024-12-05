using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerLogic : MonoBehaviour {
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    public class OnSpacePressedEventArgs : EventArgs {
        public int spaceCount;
    }

    public event ClickerLogicDelegate OnFloatEvent;
    public delegate void ClickerLogicDelegate(float f);

    public event Action<bool, int> OnActionEvent;
    private int spaceCount;
    private void Start() {

    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Space pressed!
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });

            OnFloatEvent?.Invoke(5.5f);

            OnActionEvent?.Invoke(true, 56);
        }
    }
}