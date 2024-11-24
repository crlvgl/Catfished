using UnityEngine;
using TMPro;

public class UpdateFish : MonoBehaviour
{
    public TMP_Text fishText;
    private int pets;

    void Start()
    {

    }
    void Update()
    {

    }

    public void AddFish()
    {
        pets++;
        fishText.text = "Pets: " + pets;
    }
}
