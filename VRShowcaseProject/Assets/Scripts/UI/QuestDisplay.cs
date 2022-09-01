using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    [Header("UI Componenet References")]
    [SerializeField] private TextMeshProUGUI _questNameText;
    [SerializeField] private TextMeshProUGUI _questDescriptionText;
    [SerializeField] private RectTransform _objectiveDisplayParent;

    [Header("Colors")]
    [SerializeField] private Color _incompleteColor = Color.white;
    [SerializeField] private Color _completeColor = Color.cyan;

    [Header("Prefabs")]
    [SerializeField] private GameObject _objectiveDisplayPrefab;

    private Quest _quest;

    public Quest Quest
    {
        get
        {
            return _quest;
        }
        set
        {
            if (_quest != null)
            {
                _quest.QuestUpdated -= UpdateUI;
            }

            _quest = value;
            UpdateUI();

            if (_quest != null)
            {
                _quest.QuestUpdated += UpdateUI;
            }
        }
    }

    private ObjectPool<GameObject> _objectiveDisplayPool;
    private List<GameObject> _currentObjectiveDisplays;

    private void Awake()
    {
        _objectiveDisplayPool = new ObjectPool<GameObject>(
            createFunc: CreateObjectiveDisplay,
            actionOnGet: (obj) => obj.SetActive(true),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 10);

        _currentObjectiveDisplays = new List<GameObject>();   
    }

    private void UpdateUI()
    {
        if (_quest != null)
        {
            _questNameText.text = _quest.Name;
            _questDescriptionText.text = _quest.Description;

            _questNameText.color =
                _quest.Completed() ? _completeColor : _incompleteColor;
            _questDescriptionText.color =
                _quest.Completed() ? _completeColor : _incompleteColor;
        }
        ReloadQuestObjectives();
    }

    private void ReloadQuestObjectives()
    {
        // Unload existing quest objectives
        foreach (GameObject objectiveDisplayObject in _currentObjectiveDisplays)
        {
            _objectiveDisplayPool.Release(objectiveDisplayObject);
        }
        _currentObjectiveDisplays.Clear();

        // Load new quest objectives
        for (int i = 0; i < _quest.Objectives.Count; i++)
        {
            GameObject objectiveDisplayObject = _objectiveDisplayPool.Get();
            objectiveDisplayObject.transform.SetSiblingIndex(i);

            _currentObjectiveDisplays.Add(objectiveDisplayObject);

            ObjectiveDisplay objectiveDisplay =
                objectiveDisplayObject.GetComponent<ObjectiveDisplay>();
            objectiveDisplay.Objective = _quest.Objectives[i];
        }
    }

    private GameObject CreateObjectiveDisplay()
    {
        return Instantiate(_objectiveDisplayPrefab, _objectiveDisplayParent);
    }
}
