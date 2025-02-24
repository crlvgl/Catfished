using UnityEngine;

public class SmartphoneMenu : MonoBehaviour
{
    public GameObject nextScreen;
    public bool disableThis = false;

    void OnMouseDown()
    {
        nextScreen.SetActive(true);
        if (disableThis)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}