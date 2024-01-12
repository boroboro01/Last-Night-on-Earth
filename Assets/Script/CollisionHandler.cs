using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int durability = 2;
    // [SerializeField] AudioClip collisionSound;
    [SerializeField] AudioClip shipwreckSound;
    [SerializeField] AudioClip finishSound;
    [SerializeField] ParticleSystem finishParticle;
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] ParticleSystem shipwreckParticle;
    AudioSource audioSource;
    bool isTransitioning = false;
    bool isCollisionEnable = true;
    bool hasCollisionParticlePlaying = false;
    GameObject sparksEffect;
    GameObject crashEffect;
    GameObject HP;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sparksEffect = GameObject.Find("SparksEffect");
        crashEffect = GameObject.Find("Rocket");
        HP = GameObject.Find("HP");
        HP.GetComponent<RawImage>().material.color = Color.white;
    }
    void Update()
    {
        CollisionEffectEvent();
    }



    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
        else if (isCollisionEnable)
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Friendly Thing!");
                    break;
                case "Finish":
                    FinishEnvet();
                    break;
                default:
                    CollisionEvent();
                    break;

            }
        }
    }
    private void CollisionEffectEvent()
    {
        if (durability <= 1)
        {
            if (!hasCollisionParticlePlaying)
            {
                collisionParticle.Play();
                sparksEffect.GetComponent<Spark>().AudioPlay();
                hasCollisionParticlePlaying = true;
            }
        }
        else
        {
            if (hasCollisionParticlePlaying)
            {
                collisionParticle.Pause();
                sparksEffect.GetComponent<Spark>().AudioStop();
                hasCollisionParticlePlaying = false;
            }
        }
    }
    private void CollisionEvent()
    {
        durability -= 1;
        float waitTime = 2.5f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        IEnumerator StartLoadCurrentSence()
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(currentSceneIndex);
        }
        if (durability <= 0) // Rocket be destoyed explicitly
        {
            HP.GetComponent<RawImage>().material.color = Color.red;
            isTransitioning = true;
            GetComponent<Movement>().enabled = false;
            ShipwreckEffect();
            StartCoroutine(StartLoadCurrentSence());
        }
        else // Rocket got the damage
        {
            HP.GetComponent<RawImage>().material.color = Color.yellow;
            
            crashEffect.GetComponent<Crash>().AudioPlay();
        }
    }

    private void ShipwreckEffect()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(shipwreckSound);
        shipwreckParticle.Play();
    }

    private void FinishEnvet()
    {
        float waitTime = 2.5f;
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        FinishEffect();

        int nextSceneIndex = SetSceneIndex();
        StartLoadNextScene(waitTime, nextSceneIndex);
    }

    private void FinishEffect()
    {
        audioSource.Stop();
        collisionParticle.Pause();
        sparksEffect.GetComponent<Spark>().AudioStop();
        finishParticle.Play();
        audioSource.PlayOneShot(finishSound);
    }

    int SetSceneIndex()
    {
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == lastSceneIndex)
        {
            nextSceneIndex = 0;
        }

        return nextSceneIndex;
    }

    void StartLoadNextScene(float waitTime, int nextSceneIndex)
    {
        IEnumerator LoadNextLevel()
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(nextSceneIndex);
        }
        StartCoroutine(LoadNextLevel());
    }
    public void CollisionHandlerControl() {
        isCollisionEnable = !isCollisionEnable;
        Debug.Log("CollisionHandler " + isCollisionEnable);
    }
}
