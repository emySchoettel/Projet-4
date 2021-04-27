using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioListener))]

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public void setAudio(AudioClip audio)
    {
        audioSource.clip = audio; 
    }

    public void addAudioSource()
    {
        gameObject.AddComponent<AudioSource>();
    }

    public List<AudioSource> getListOfAudioSource()
    {
        List<AudioSource> audioSources = new List<AudioSource>();
        AudioSource[] audios = GetComponents<AudioSource>();
        for (int i = 0; i < audios.Length; i++)
        {
            audioSources.Add(audios[i]);
        }
        return audioSources; 
    }

    public  void playAudio()
    {
        audioSource.Play();
    }

    public  void pauseAudio()
    {
        audioSource.Pause();
    }

    public  void stopAudio()
    {
        audioSource.Stop(); 
    }

    public  void unpauseAudio()
    {
        audioSource.UnPause(); 
    }

    public  void loopAudio(bool loop)
    {
        audioSource.loop = loop; 
    }

    public  bool isPlaying()
    {
        return audioSource.isPlaying; 
    }
}
