using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public Quest Quest;
    public List<int> ObjectiveIndexes;
    public void OnHeadPlacement()
    {
        Quest.UpdateObjective(ObjectiveIndexes[0], true);
    }
}
