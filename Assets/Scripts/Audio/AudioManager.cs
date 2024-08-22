using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AssetsSound[] sounds;

    private void Awake()
    {
        foreach (AssetsSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BackGround");
    }

    public void Play(string name)
    {
        AssetsSound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + s.name + " not found!");
            return;
        }


        s.source.Play();
    }

}
