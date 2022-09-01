using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCycler : MonoBehaviour
{
    [SerializeField] private QuestList _questList;
    [SerializeField] private QuestDisplay _questDisplay;

    private int _questIndex = 0;

    private void Start()
    {
        _questDisplay.Quest = _questList.CurrentQuests[_questIndex];
    }

    public void ShowNextQuest()
    {
        if (_questIndex + 1 >= _questList.CurrentQuests.Count)
        {
            _questIndex = 0;
        }
        else
        {
            _questIndex++;
        }

        _questDisplay.Quest = _questList.CurrentQuests[_questIndex];
    }

    public void ShowPreviousQuest()
    {
        if (_questIndex - 1 < 0)
        {
            _questIndex = _questList.CurrentQuests.Count - 1;
        }
        else
        {
            _questIndex--;
        }

        _questDisplay.Quest = _questList.CurrentQuests[_questIndex];
    }
}
