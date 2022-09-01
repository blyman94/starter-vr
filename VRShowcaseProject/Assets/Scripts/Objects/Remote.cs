using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public Quest Quest;

    public int PickupObjectiveIndex;
    public int ActivateObjectiveIndex;

    public void OnPickup()
    {
        Quest.UpdateObjective(PickupObjectiveIndex, true);
    }

    public void OnActivate()
    {
        Quest.UpdateObjective(ActivateObjectiveIndex, true);
    }
}
