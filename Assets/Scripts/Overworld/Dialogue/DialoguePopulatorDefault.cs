using UnityEngine;

public class DialoguePopulatorDefault : MonoBehaviour
{
    [Tooltip("the trigger for the dialogue")]
    public string trigger;
    [Tooltip("If character has multiple default dialogues, set true")]
    public bool multipleDefault = false;

    [Tooltip("the dialogue to be displayed, only for default dialogue")]
    [TextArea(3, 10)]
    public string[] dialogue;
    private bool copied = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Debug.Log("DialoguePopulatorDefault is awake through start");
        if (!multipleDefault)
        {
            this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
        }
        else if (multipleDefault)
        {
            // Debug.Log(this.gameObject.GetComponent<DialogueHandler>().trigger == trigger);
            // Debug.Log("copied is " + copied);
            // Debug.Log("Multiple default dialogues are present");
            if (!copied && this.gameObject.GetComponent<DialogueHandler>().trigger == trigger)
            {
                // Debug.Log("Dialogue copied");
                this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
                copied = true;
            }
            else if(copied && this.gameObject.GetComponent<DialogueHandler>().trigger != trigger)
            {
                copied = false;
            }
        }
        // this.gameObject.SetActive(false);
    }

    void Awake()
    {

    }

    void OnEnable()
    {
        // Debug.Log("DialoguePopulatorDefault is awake");
        if (!multipleDefault)
        {
            this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
        }
        else if (multipleDefault)
        {
            // Debug.Log(this.gameObject.GetComponent<DialogueHandler>().trigger);
            // Debug.Log("copied is " + copied);
            // Debug.Log("Multiple default dialogues are present");
            if (!copied && this.gameObject.GetComponent<DialogueHandler>().trigger == trigger)
            {
                // Debug.Log("Dialogue copied");
                this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
                copied = true;
            }
            else if(copied && this.gameObject.GetComponent<DialogueHandler>().trigger != trigger)
            {
                copied = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
