using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    [SerializeField] AudioClip spark;
    AudioSource sparkAudioSource;

    void Start() {
        sparkAudioSource = GetComponent<AudioSource>();
    }
    public void AudioPlay() {
        sparkAudioSource.PlayOneShot(spark);
    }
    public void AudioStop() {
        sparkAudioSource.Stop();
    }
}
