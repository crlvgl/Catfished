using UnityEngine;

public class DisablePauseScreen : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] screens;

    void OnDisable()
    {
        pauseMenu.SetActive(true);
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }
    }
}