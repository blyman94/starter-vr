using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecord : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private Transform _recordTransform;

    private void Update()
    {
        _recordTransform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }
}
