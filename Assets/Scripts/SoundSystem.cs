using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
    }

    public static SoundSystem Instance;

    public AudioSource Source;
    public Sound[] Sounds;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Play(string name)
    {
        Source.Stop();
        Source.clip = null;

        var clip = Sounds.FirstOrDefault(x => x.Name.Equals(name));
        if (clip == null)
        {
            Debug.LogError("Sound clip with name " + name + "not found");
            return;
        }

        Source.clip = clip.Clip;
        Source.Play();
    }

    public void PlayOneShot(string name)
    {
        Source.Stop();

        var clip = Sounds.FirstOrDefault(x => x.Name.Equals(name));
        if (clip == null)
        {
            Debug.LogError("Sound clip with name " + name + "not found");
            return;
        }

        Source.PlayOneShot(clip.Clip);
    }
}
