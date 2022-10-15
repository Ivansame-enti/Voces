using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerController : MonoBehaviour
{
    public Sound[] audios;

    void Awake()
    {
        foreach (Sound a in audios)
        {

            a.source = gameObject.AddComponent<AudioSource>();
            a.source.outputAudioMixerGroup = a.audioMixer;

            a.source.clip = a.clip;

            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;

        }

    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MainMenu" || sceneName == "Options" || sceneName == "LevelSelector")
        {
            AudioPlay("MenuTheme");
        }
        else if(sceneName != "Puzzle2_2")
        {
            AudioPlay("MainTheme");
        }
        //Musica de fondo  

    }

    public void AudioPlay(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.Play();
    }

    public void ChangePitch(string name, float p)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.pitch = p;
    }

    public float GetVolume(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return 0;
        }
        return a.source.volume;
    }

    public void ChangeVolume(string name, float p)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.volume = p;
    }

    public void AudioPause(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.Pause();
    }

    public bool GetAudioPlaying(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return false;
        }
        if (a.source.isPlaying) return true;
        else return false;
    }

    public void AudioStop(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.Stop();
    }
}
