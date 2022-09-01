using System;
using UnityEngine;

/// <summary>
/// A task the player must complete to progress in a quest.
/// </summary>
[Serializable]
public class Objective
{
    public ValueUpdated ObjectiveUpdated;
    public string Description = "Example objective description...";
    [SerializeField] private bool _completed = false;
    public bool Completed
    {
        get
        {
            return _completed;
        }
        set
        {
            _completed = value;
            ObjectiveUpdated?.Invoke();
        }
    }
}
