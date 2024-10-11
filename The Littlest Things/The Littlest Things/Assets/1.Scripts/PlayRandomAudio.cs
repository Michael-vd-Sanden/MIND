using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;

    public void playRandom()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(randomClip);
    }
}
