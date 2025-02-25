using UnityEngine;
using TMPro;
using System;

public class RealClock : MonoBehaviour
{
    public TMP_Text clockText;

    private void OnEnable()
    {
        if (clockText == null)
        {
            Debug.LogError("Clock TextMeshPro component is not assigned!");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(UpdateClock), 0f, 1f);
    }

    private void UpdateClock()
    {
        clockText.text = DateTime.Now.ToString("HH:mm"); // Format: 24-hour HH:mm
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(UpdateClock));
    }
}