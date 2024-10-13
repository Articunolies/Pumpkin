using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip[] regularSteps;
    public AudioClip[] sprintSteps;
    public AudioClip[] chatter;
    public AudioClip[] nervous;
    public AudioClip[] reaction;

    Rigidbody2D rb;
    AudioSource audioSource;
    PlayerMovement playerMovement;

    public int stepLength = 10;
    public int talkMin = 200;
    public int talkMax = 400;

    int stepFrame = 0;
    int chatterFrame = 0;
    int chatterLength;
    int nervousFrame = 0;
    int nervousLength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        chatterLength = Random.Range(talkMin, talkMax);
        nervousLength = Random.Range(talkMin, talkMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Steps();
        Chatter();
        Nervous();
    }

    void Steps() {
        if (rb.velocity.magnitude > 0) {
            if (stepFrame == stepLength) {
                if (!playerMovement.issprinting) {
                    int randomIndex = Random.Range(0, regularSteps.Length);
                    audioSource.clip = regularSteps[randomIndex];
                    audioSource.Play();
                } else {
                    int randomIndex = Random.Range(0, sprintSteps.Length);
                    audioSource.clip = sprintSteps[randomIndex];
                    audioSource.Play();
                }
                stepFrame = 0;
            } else {stepFrame++;}
        } else {stepFrame = 0;}
    }

    void Chatter() {
        if (!playerMovement.ishiding) {
            if (chatterFrame == chatterLength) {
                int randomIndex = Random.Range(0, chatter.Length);
                audioSource.clip = chatter[randomIndex];
                audioSource.Play();
                chatterFrame = 0;
                chatterLength = Random.Range(talkMin, talkMax);
            } else {chatterFrame++;}
        } else {chatterFrame = 0;}
    }

    void Nervous() {
        if (playerMovement.ishiding) {
            if (nervousFrame == nervousLength) {
                int randomIndex = Random.Range(0, nervous.Length);
                audioSource.clip = nervous[randomIndex];
                audioSource.Play();
                nervousFrame = 0;
                nervousLength = Random.Range(talkMin, talkMax);
            } else {nervousFrame++;}
        } else {nervousFrame = 0;}
    }

    public void Reaction() {
        int randomIndex = Random.Range(0, reaction.Length);
        audioSource.clip = reaction[randomIndex];
        audioSource.PlayOneShot(audioSource.clip);
    }
    
}