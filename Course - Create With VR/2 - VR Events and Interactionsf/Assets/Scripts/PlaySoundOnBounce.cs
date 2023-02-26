using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnBounce : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip impact;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        impact = audioSource.clip;
    }

    void OnCollisionEnter()
    {
        audioSource.PlayOneShot(impact, 0.75F);
    }
}
