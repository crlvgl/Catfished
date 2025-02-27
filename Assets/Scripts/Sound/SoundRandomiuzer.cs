using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomiser : MonoBehaviour
{   
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f,0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f,0.5f)]
    public float pitchChangeMultiplier = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
          
        }
    }
    public void RandomiseFootstep()
    {
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
        source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
        source.PlayOneShot(source.clip);
    }
}
