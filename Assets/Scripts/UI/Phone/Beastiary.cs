using UnityEngine;
using TMPro;
using System.Reflection;

public class Beastiary : MonoBehaviour
{
    public GameObject fishPrefab;
    public TMP_Text fishName;
    public string fishNameString;
    public TMP_Text latinName;
    public string latinNameString;
    public TMP_Text fishDescription;
    public string fishDescriptionString;

    void OnEnable()
    {
        if (GetBoolByName(fishPrefab.name) || SaveLoad.GetBool(fishPrefab.name))
        {
            fishName.text = fishNameString;
            latinName.text = latinNameString;
            fishDescription.text = fishDescriptionString;
            fishPrefab.transform.Find("Fish").gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            fishPrefab.transform.Find("Frame").gameObject.SetActive(true);
            fishPrefab.transform.Find("Frame").gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            fishName.text = "???";
            latinName.text = " ";
            fishDescription.text = " ";
            fishPrefab.transform.Find("Fish").gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            fishPrefab.transform.Find("Frame").gameObject.SetActive(false);
        }
    }

    bool GetBoolByName(string name)
    {
        FieldInfo field = typeof(Inventory).GetField(name, BindingFlags.Public | BindingFlags.Static);

        if (field != null && field.FieldType == typeof(bool))
        {
            return (bool)field.GetValue(null);
        }
        else
        {
            Debug.LogWarning($"No matching boolean found for {name} in Inventory");
            return false; // Default return value if the field is not found
        }
    }
}