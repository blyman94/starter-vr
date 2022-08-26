using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    [SerializeField] private AudioSource _tennisBallAudioSource;
    [SerializeField] private AudioClip _tennisBallAudioClip;
    [SerializeField] private Rigidbody _rigidBody;

    private void OnCollisionEnter(Collision other)
    {
        _tennisBallAudioSource.PlayOneShot(_tennisBallAudioClip);
    }
}
