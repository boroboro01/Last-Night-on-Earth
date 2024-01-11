using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    AudioSource sparkAudioSource;

    void Start() {
        sparkAudioSource = GetComponent<AudioSource>();
    }
    public void AudioPlay() {
        sparkAudioSource.PlayOneShot(crash);
    }
    public void AudioStop() {
        sparkAudioSource.Stop();
    }
}
