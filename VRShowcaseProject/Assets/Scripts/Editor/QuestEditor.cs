using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Quest), editorForChildClasses: true)]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Quest targetQuest = target as Quest;
        if (GUILayout.Button("Reset Objectives"))
            targetQuest.ResetObjectiveStatusAll();
    }
}
