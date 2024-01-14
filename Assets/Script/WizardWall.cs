using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardWall : MonoBehaviour
{
    [SerializeField] float wallSpeed = 1000f;
     [SerializeField] AudioClip wizardTouch;
    [SerializeField] AudioClip dragging;
    Rigidbody WallRigidBody;
    AudioSource audioSource;
    bool WizardOn;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        WallRigidBody = GetComponent<Rigidbody>();
        WizardOn = false;
    }
    void Update()
    {
        if (WizardOn)
        {
            MovingWall();
        }
    }
    void MovingWall()
    {
        WallRigidBody.AddRelativeForce(Vector3.forward * wallSpeed * Time.deltaTime);
    }
    public void Wizard()
    {
        WizardOn = true;
        audioSource.PlayOneShot(wizardTouch);
    }
}
