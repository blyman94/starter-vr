using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordSocket : MonoBehaviour
{
    [SerializeField] private float _recordRotationSpeed = 10.0f;
    [SerializeField] private AudioSource _recordAudioSource;

    private bool _recordActive = false;

    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.onSelectEntered.AddListener(PlayNewSong);
        socket.onSelectExited.AddListener(StopSong);
    }

    private void Update()
    {
        if (_recordActive)
        {
            transform.Rotate(new Vector3(0.0f, _recordRotationSpeed * Time.deltaTime, 0.0f));
        }
    }

    private void OnDisable()
    {
        socket.onSelectEntered.RemoveListener(PlayNewSong);
        socket.onSelectExited.RemoveListener(StopSong);
    }

    private void PlayNewSong(XRBaseInteractable obj)
    {
        Record record = obj.gameObject.GetComponent<Record>();

        if (record != null)
        {
            _recordAudioSource.clip = record.SongClip;
            _recordAudioSource.Play();
            _recordActive = true;
        }
    }

    private void StopSong(XRBaseInteractable obj)
    {
        _recordAudioSource.Stop();
        _recordAudioSource.clip = null;
        _recordActive = false;
    }
}
