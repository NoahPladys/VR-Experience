using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    public List<AudioClip> SoundsPool;
    public uint MinimumTimeBetweenSounds;
    public uint MaximumTimeBetweenSounds;

    private AudioSource audioSource;
    private float timeSinceLastAudio;
    private static System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        timeSinceLastAudio = 0;
        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastAudio <= 0)
        {
            AudioClip clip = SoundsPool[random.Next(0, SoundsPool.Count)];
            timeSinceLastAudio = random.Next((int)MinimumTimeBetweenSounds, (int)MaximumTimeBetweenSounds) + clip.length;

            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            timeSinceLastAudio -= Time.deltaTime;
        }
    }
}
