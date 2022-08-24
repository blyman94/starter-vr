using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play from a list of sounds using next, previous, and random
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PlaySoundsFromList : MonoBehaviour
{
    [Tooltip("Loop the currently playing sound")]
    public bool shouldLoop = false;

    [Tooltip("The list of audio clips to play from")]
    public List<AudioClip> audioClips = new List<AudioClip>();

    public float minTimeBetweenSounds = 3.0f;
    public float maxTimeBetweenSounds = 10.0f;

    private AudioSource audioSource = null;
    private int index = 0;

    private float soundTimer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        soundTimer -= Time.deltaTime;
        if (soundTimer <= 0)
        {
            RandomClip();
            soundTimer = Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
        }
    }

    public void NextClip()
    {
        index = ++index % audioClips.Count;
        PlayClip();
    }

    public void PreviousClip()
    {
        index = --index % audioClips.Count;
        PlayClip();
    }

    public void RandomClip()
    {
        index = Random.Range(0, audioClips.Count);
        PlayClip();
    }

    public void PlayAtIndex(int value)
    {
        index = Mathf.Clamp(value, 0, audioClips.Count);
        PlayClip();
    }

    public void PauseClip()
    {
        audioSource.Pause();
    }

    public void StopClip()
    {
        audioSource.Stop();
    }

    public void PlayCurrentClip()
    {
        PlayClip();
    }

    private void PlayClip()
    {
        audioSource.clip = audioClips[Mathf.Abs(index)];
        audioSource.Play();
    }

    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = shouldLoop;
    }
}
