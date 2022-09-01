using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    [SerializeField] AudioClip[] audioClips; 

    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;

    private void Awake()
    {
        if (instance == null) instance = this;
        
    }
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlaySound(0);
        }
    }
    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
        print("sound");
    }

    public void PlaySoundInOtherSource(AudioSource source)
    {
        source.PlayOneShot(source.clip);
    }public void PlaySoundInOtherSource(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }public void PlaySoundInOtherSource(AudioSource source, AudioClip clip, float volume)
    {
        source.volume = volume;
        source.PlayOneShot(clip, volume);
    }public void PlaySoundInOtherSource(AudioSource source, AudioClip clip, float volume, float pitch)
    {
        source.pitch = pitch;
    }
}
