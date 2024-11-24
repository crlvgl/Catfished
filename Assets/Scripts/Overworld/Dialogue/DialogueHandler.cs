using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    [HideInInspector]public string[] dialogue;
    [Tooltip("the trigger for the dialogue; only needed, when multiple dialogues are present")]
    public bool hasMultiple = false;
    public string[] triggers;
    [HideInInspector]public string trigger;
    private int index = 0;
    public string pathToTextBox = "Chatter/Canvas/Text (TMP)";
    private TMP_Text textBox;
    private Queue<string> sentences = new Queue<string>();
    private bool beforeFirstFrame = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Awake()
    {
        if (hasMultiple && triggers.Length <= 0)
        {
            Debug.LogError("Multiple dialogues are present, but no triggers are set");
        }
        if (hasMultiple)
        {
            trigger = triggers[index];
            index++;
            // Debug.Log("Trigger is " + trigger);
        }
        textBox = this.transform.Find(pathToTextBox).GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        // Debug.Log("DialogueHandler is awake");
        sentences.Clear();
        // Debug.Log(dialogue.Length);
        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }
        // Debug.Log(sentences.Count);
        // Debug.Log(sentences);
        if (beforeFirstFrame)
        {
            beforeFirstFrame = false;
            return;
        }
        // StartCoroutine(WaitForDialogue());
        DoTalk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTalk()
    {
        if (sentences.Count == 0)
        {
            if (hasMultiple)
            {
                if (index < triggers.Length)
                {
                    trigger = triggers[index];
                    index++;
                    // Debug.Log("Trigger is " + trigger);
                }
                else if (index >= triggers.Length)
                {
                    index = 0;
                    trigger = triggers[index];
                    index++;
                    // Debug.Log("Trigger is " + trigger);
                }
            }
            // Debug.Log(trigger);
            // Debug.Log("Dialogue ended");
            this.gameObject.SetActive(false);
            return;
        }
        textBox.text = sentences.Dequeue();
    }

    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(0.1f);
        DoTalk();
    }
}
