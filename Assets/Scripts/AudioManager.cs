using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioSources;

    public List<AudioClip> bruitPas = new List<AudioClip>(); 

    private void Awake() 
    {
        // AudioSource compo; 
        // for (int i = 0; i < audioSources.Count; i++)
        // {
        //     compo = gameObject.AddComponent<AudioSource>();
        //     audioSources[i] = compo;
        // }
    }

    public void setAudio(AudioClip audio, int indice)
    {
        audioSources[indice].clip = audio; 
    }

    public void setAudioVolume(int indice, float volume)
    {
        audioSources[indice].volume = volume;
    }

    public int addAudioSource()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audioSources.Add(audio);
        return audioSources.IndexOf(audio);
    }

    // public int getAudioSourceIndex(AudioSource audio)
    // {
    //     if(audioSources.Contains(audio))
    //     {
    //         return audioSources.IndexOf(audio);
    //     }
    //     else
    //     {
    //         throw new System.Exception("Audio introuvable");
    //     }
    // }

    public List<AudioSource> getListOfAudioSource()
    {
        return audioSources; 
    }

    public AudioSource GetAudioSource(int index)
    {
        if(audioSources[index] != null)
        {
            return audioSources[index];
        }
        else
        {
            throw new System.Exception("Mauvais index");
        }
    }

    public AudioClip GetAudioClip(int index)
    {
        // if(index <= bruitPas.Count)
        // {
        //     return bruitPas[index];
        // }
        // else
        // {
        //     throw new System.Exception("AudioClip introuvable");
        // }
        return null;
    }

    public void playAudio(int indice)
    {
        audioSources[indice].Play();
    }

    public  void pauseAudio(int indice)
    {
        audioSources[indice].Pause();
    }

    public  void stopAudio(int indice)
    {
        audioSources[indice].Stop(); 
    }

    public  void unpauseAudio(int indice)
    {
        audioSources[indice].UnPause(); 
    }

    public  void loopAudio(bool loop, int indice)
    {
        audioSources[indice].loop = loop; 
    }

    public void muteAudio(bool mute, int indice)
    {
        audioSources[indice].mute = mute; 
    }

    public  bool isPlaying(int indice)
    {
        return audioSources[indice].isPlaying; 
    }
}
