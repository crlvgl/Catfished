using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonController : MonoBehaviour {
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    void Start() {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if(Input.GetKeyDown(keyToPress)) {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress)) {
            theSR.sprite = defaultImage;
        }
    }
}

