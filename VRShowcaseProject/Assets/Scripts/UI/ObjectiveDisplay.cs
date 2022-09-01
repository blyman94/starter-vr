using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveDisplay : MonoBehaviour
{
    [Header("UI Component References")]
    [SerializeField] private Image _checkboxImage;
    [SerializeField] private Image _checkImage;
    [SerializeField] private TextMeshProUGUI _objectiveDescriptionText;

    [Header("Colors")]
    [SerializeField] private Color _incompleteColor = Color.white;
    [SerializeField] private Color _completeColor = Color.cyan;

    private Objective _objective;

    public Objective Objective
    {
        get
        {
            return _objective;
        }
        set
        {
            if (_objective != null)
            {
                _objective.ObjectiveUpdated -= UpdateUI;
            }

            _objective = value;
            UpdateUI();

            if (_objective != null)
            {
                _objective.ObjectiveUpdated += UpdateUI;
            }
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    private void OnDisable()
    {
        if (_objective != null)
        {
            _objective.ObjectiveUpdated -= UpdateUI;
        }
    }

    private void UpdateUI()
    {
        if (_objective != null)
        {
            _objectiveDescriptionText.text = _objective.Description;

            if (_objective.Completed)
            {
                _checkImage.gameObject.SetActive(true);
                _checkImage.color = _completeColor;

                _checkboxImage.color = _completeColor;

                _objectiveDescriptionText.color = _completeColor;
            }
            else
            {
                _checkImage.gameObject.SetActive(false);
                _checkImage.color = _incompleteColor;

                _checkboxImage.color = _incompleteColor;

                _objectiveDescriptionText.color = _incompleteColor;
            }
        }
    }

}
