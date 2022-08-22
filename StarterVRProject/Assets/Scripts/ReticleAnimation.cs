using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows for the animation of a reticle by dictating its size over the life
/// time of a serialized animation curve.
/// </summary>
public class ReticleAnimation : MonoBehaviour
{
    [SerializeField] private Transform _reticle;
    [SerializeField] private AnimationCurve _reticleSizeCurve;

    private float time = 0.0f;

    #region MonoBehaviour Methods
    private void Update()
    {
        AnimateReticle();
    }
    #endregion

    /// <summary>
    /// Evaluates the serialized animation curve to update the local scale of 
    /// the reticle.
    /// </summary>
    private void AnimateReticle()
    {
        if (time >= _reticleSizeCurve.keys[_reticleSizeCurve.keys.Length - 1].time)
        {
            time = 0.0f;
        }

        _reticle.localScale =
            new Vector3(_reticleSizeCurve.Evaluate(time), 1.0f,
            _reticleSizeCurve.Evaluate(time));

        time += Time.deltaTime;
    }
}
