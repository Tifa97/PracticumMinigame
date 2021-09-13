using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public AudioMixer outputt;
    public ScriptableValue musicVol;
    public ScriptableValue soundsVol;
    public ScriptableValue masterVol;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumen;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMusicVolumen(musicVol.value);
        SetMusicVfx(soundsVol.value);
        Play(AudioList.MenuMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Play(AudioList.Walking);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Stop(AudioList.Walking);
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void SetMusicVolumen(float volume)
    {
        outputt.SetFloat("VolumeMusic", volume);
        musicVol.value = (int)volume;
    }

    public void SetMusicVfx(float volume)
    {
        outputt.SetFloat("VolumeVFX", volume);
        float v = volume;
        soundsVol.value = (int)volume;
    }

    public void TurnOffSound(float volume)
    {
        //AudioManager.instance.Play("BtnClickSound");
        outputt.SetFloat("VolumeMaster", -80);
        volume = -80f;
        masterVol.value = -80;
    }

    public void TurnOnSound(float volume)
    {
        //AudioManager.instance.Play("BtnClickSound");
        outputt.SetFloat("VolumeMaster", 0);
        volume = 0f;
        masterVol.value = 0;
    }
}
