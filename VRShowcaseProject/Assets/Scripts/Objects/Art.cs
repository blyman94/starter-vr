using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art : MonoBehaviour
{
    public Quest Quest;
    public List<int> ObjectiveIndexes;

    public void OnPickUp()
    {
        Quest.UpdateObjective(ObjectiveIndexes[0], true);
    }
    public void OnDrop()
    {
        Quest.UpdateObjective(ObjectiveIndexes[0], false);
    }
    public void OnHang()
    {
        Quest.UpdateObjective(ObjectiveIndexes[0], true);
        Quest.UpdateObjective(ObjectiveIndexes[1], true);
    }
}
