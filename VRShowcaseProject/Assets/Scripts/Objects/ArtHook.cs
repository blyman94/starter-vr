using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArtHook : MonoBehaviour
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
        Art art = obj.gameObject.GetComponent<Art>();

        if (art != null)
        {
            art.OnHang();
        }
    }
}
