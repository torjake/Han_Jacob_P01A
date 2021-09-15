using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioHelper
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        //create
        GameObject audioObject = new GameObject("Audio2d");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //config
        audioSource.clip = clip;
        audioSource.volume = volume;
        //active
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);
        //return in case other things need it
        return audioSource;
    }
}
