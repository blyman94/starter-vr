using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTVMat : MonoBehaviour
{
    public Quest Quest;

    public int ObjectiveIndex;

    public void OnTeleport()
    {
        Quest.UpdateObjective(ObjectiveIndex, true);
    }
}
