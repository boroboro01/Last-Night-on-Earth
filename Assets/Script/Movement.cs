using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1000f;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] ParticleSystem thrustParticle;
    Rigidbody RocketRigidbody;
    AudioSource audioSoruce;
    bool isThrustSoundPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        RocketRigidbody = GetComponent<Rigidbody>();
        audioSoruce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        StartThrusting();
    }

    private void StartThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RocketRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSoruce.isPlaying)
            {
                audioSoruce.PlayOneShot(thrustSound);
                thrustParticle.Play();
                isThrustSoundPlaying = true;
            }
        }
        else
        {
            if (isThrustSoundPlaying)
            {
                audioSoruce.Stop();
                thrustParticle.Stop();
                isThrustSoundPlaying = false;
            }

        }
    }

    void ProcessRotation()
    {
        StartRotationing();
    }

    private void StartRotationing()
    {
        
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     MoveBackAndForth(-rotationThrust);
        // }
        // else if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     MoveBackAndForth(rotationThrust);
        // }else 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveBothSide(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveBothSide(-rotationThrust);
        }
    }

    // private void MoveBackAndForth(float rotationThisFrame)
    // {
    //     RocketRigidbody.freezeRotation = true;
    //     transform.Rotate(Vector3.right * rotationThisFrame * Time.deltaTime);
    //     RocketRigidbody.freezeRotation = false;
    // }

    private void MoveBothSide(float rotationThisFrame)
    {
        RocketRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        RocketRigidbody.freezeRotation = false;
    }
}
