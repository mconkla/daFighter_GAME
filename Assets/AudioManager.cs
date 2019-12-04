using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Audio;

public class AudioManager : MonoBehaviour
{
    float timeStamp;
    public Sound[] sounds;

    

    void Awake()
    {
        
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.playOnAwake = false;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
        
    }
    private void Update()
    {
        if(Time.time - timeStamp > 0.5f)
        {
            foreach (Sound sound in sounds)
            {
                sound.isPlaying = false;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = null;
        Debug.Log("Play " + name);
        for (int i = 0; i < sounds.Length;i++)
        {
            if (sounds[i].name == name)
            {
                s = sounds[i];
            }
        }

        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        if (!s.isPlaying)
        {
            timeStamp = Time.time;
            s.source.Play();
            s.isPlaying = true;
        }
    }
}
