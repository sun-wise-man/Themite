using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null) instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }

        // Allow audio to be played when change scene
        DontDestroyOnLoad(gameObject);

        // Add audiosource to array of sound
        foreach(Sound s in sounds)        
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Play audio by referencing its name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }
}
