using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour 
{
    public bool canBePressed;
    public KeyCode keyToPress;

    private bool obtained = false;

    void Update() {
        if(Input.GetKeyDown(keyToPress)) {
            if(canBePressed) {
                obtained = true;
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
                obtained = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Activator") {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Activator") {
            canBePressed = false;
            if(!obtained) {
                GameManager.instance.NoteMissed();
            }
        }
    }
}
