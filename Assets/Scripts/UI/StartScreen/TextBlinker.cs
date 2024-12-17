using UnityEngine;
using System.Collections;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    public TMP_Text text;
    public float blinkTimeActive = 0.5f;
    public float blinkTimeInactive = 0.5f;

    void Start()
    {
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            text.enabled = !text.enabled;
            if (text.enabled)
            {
                yield return new WaitForSeconds(blinkTimeActive);
            }
            else
            {
                yield return new WaitForSeconds(blinkTimeInactive);
            }
        }
    }
}