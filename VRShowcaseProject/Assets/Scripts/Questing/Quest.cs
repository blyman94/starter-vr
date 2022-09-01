using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collection of tasks a player must complete.
/// </summary>
[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public ValueUpdated QuestUpdated;
    public string Name = "New Quest";
    public string Description = "Example Quest Description...";
    public List<Objective> Objectives;

    public bool Completed()
    {
        foreach (Objective objective in Objectives)
        {
            if (!objective.Completed)
            {
                return false;
            }
        }
        return true;
    }

    public void UpdateObjective(int objectiveIndex, bool newStatus)
    {
        Objectives[objectiveIndex].Completed = newStatus;
        QuestUpdated?.Invoke();
    }

    public void ResetObjectiveStatusAll()
    {
        foreach (Objective objective in Objectives)
        {
            objective.Completed = false;
        }
    }
}
