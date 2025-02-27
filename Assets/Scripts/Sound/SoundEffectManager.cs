using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;

    private static AudioSource audioSource;
    private static AudioSource randomPitchAudioSource;
    private static SoundEffectLibrary soundEffectLibrary;
    //[SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSource = audioSources[0];
            randomPitchAudioSource = audioSources[1];
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName, bool randomPitch = false, float delay = 0f)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if(audioClip != null)
        {
            if (delay > 0f)
            {
                Instance.StartCoroutine(PlayDelayed(audioClip, randomPitch, delay));
            }
            else
            {
                PlayImmediately(audioClip, randomPitch);
            }
            
        }
    }

    private static IEnumerator PlayDelayed(AudioClip audioClip, bool randomPitch, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayImmediately(audioClip, randomPitch);
    }

    private static void PlayImmediately(AudioClip audioClip, bool randomPitch)
    {
        if(randomPitch)
        {
            randomPitchAudioSource.pitch = Random.Range(1f, 1.5f);
            randomPitchAudioSource.PlayOneShot(audioClip);
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame

}
