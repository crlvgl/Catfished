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

    }

    void Awake()
    {
        if (!multipleDefault)
        {
            this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
        }
    }

    void OnEnable()
    {
        if (!multipleDefault)
        {
            this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (multipleDefault)
        {
            if (!copied && this.gameObject.GetComponent<DialogueHandler>().trigger == trigger)
            {
                this.gameObject.GetComponent<DialogueHandler>().dialogue = dialogue;
                copied = true;
            }
            else if(copied && this.gameObject.GetComponent<DialogueHandler>().trigger != trigger)
            {
                copied = false;
            }
        }
    }
}
