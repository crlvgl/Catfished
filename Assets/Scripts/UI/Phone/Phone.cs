using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject pauseScreen;
    void OnMouseDown()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }
}