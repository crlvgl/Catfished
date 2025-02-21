using UnityEngine;
using System.Collections;

public class DestroyLavaBubbles : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyBubbles());
    }

    IEnumerator DestroyBubbles()
    {
        if (this.transform.name == "LavaBubble1(Clone)")
        {
            yield return new WaitForSeconds(1.24f);
        }
        else if (this.transform.name == "LavaBubble2(Clone)")
        {
            yield return new WaitForSeconds(0.62f);
        }
        else
        {
            Debug.Log("Error: LavaBubble name not found");
        }
        Destroy(this.gameObject);
    }
}