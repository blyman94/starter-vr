using System;
using UnityEngine;

public enum AnalogClockStyle { Continuous, Discrete }

/// <summary>
/// Models the behaviour of an analog clock by rotating the second hand 6
/// degrees clockwise every second, [...];
/// </summary>
public class AnalogClock : MonoBehaviour
{
    [Header("Clock Settings")]
    [SerializeField] private AnalogClockStyle _style;

    [Header("Transform References")]
    [SerializeField] private Transform _hourHand;
    [SerializeField] private Transform _minuteHand;
    [SerializeField] private Transform _secondHand;

    private const float startRotation = 90.0f;
    private const float degreesPerHour = 30.0f;
    private const float degreesPerMinute = 6.0f;
    private const float degreesPerSecond = 6.0f;

    private float secondTimer = 1.0f;

    #region MonoBehaviour Methods
    private void Start()
    {
        SetClockHandRotations();
    }

    private void Update()
    {
        if (_style == AnalogClockStyle.Continuous)
        {
            SetClockHandRotations();
        }
        else if (_style == AnalogClockStyle.Discrete)
        {
            secondTimer -= Time.deltaTime;
            if (secondTimer <= 0.0f)
            {
                SetClockHandRotations();
                secondTimer = 1.0f;
            }
        }
    }

    /// <summary>
    /// Sets the rotations for each hand on the clock based on the current time.
    /// </summary>
    private void SetClockHandRotations()
    {
        SetHourHandRotation();
        SetMinuteHandRotation();
        SetSecondHandRotation();
    }
    #endregion

    /// <summary>
    /// Sets the local X rotation of the hour hand based on the current time.
    /// </summary>
    private void SetHourHandRotation()
    {
        float totalHours =
            Mathf.Round((float)DateTime.Now.TimeOfDay.TotalHours * 100.0f) / 100.0f;
        float rotationAngle = totalHours * degreesPerHour;
        _hourHand.localRotation = Quaternion.Euler(startRotation + rotationAngle, 0.0f, -90.0f);
    }

    /// <summary>
    /// Sets the local X rotation of the minute hand based on the current time.
    /// </summary>
    private void SetMinuteHandRotation()
    {
        float totalMinutes =
            Mathf.Round((float)DateTime.Now.TimeOfDay.TotalMinutes * 100.0f) / 100.0f;
        float rotationAngle = totalMinutes * degreesPerMinute;
        _minuteHand.localRotation = Quaternion.Euler(startRotation + rotationAngle, 0.0f, -90.0f);
    }

    /// <summary>
    /// Sets the local X rotation of the second hand based on the current time.
    /// </summary>
    private void SetSecondHandRotation()
    {
        float totalSeconds =
            Mathf.Round((float)DateTime.Now.TimeOfDay.TotalSeconds * 100.0f) / 100.0f;
        float rotationAngle = totalSeconds * degreesPerSecond;
        _secondHand.localRotation = Quaternion.Euler(startRotation + rotationAngle, 0.0f, -90.0f);
    }
}
