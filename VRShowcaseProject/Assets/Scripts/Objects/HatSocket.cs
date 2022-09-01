using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HatSocket : MonoBehaviour
{
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.onSelectEntered.AddListener(UpdateObjective);
    }

    private void OnDisable()
    {
        socket.onSelectEntered.RemoveListener(UpdateObjective);
    }

    private void UpdateObjective(XRBaseInteractable obj)
    {
        Hat hat = obj.gameObject.GetComponent<Hat>();

        if (hat != null)
        {
            hat.OnHeadPlacement();
        }
    }
}
