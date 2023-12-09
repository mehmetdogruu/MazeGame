using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    private Vector3 gateInitialPos;
    // private Vector3 gateOpenedPos;
    private void Start()
    {
        gateInitialPos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out var player))
        {
            OpenGateTween();
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out var player))
        {
            CloseGateTween();
        }

    }
    private void OpenGateTween()
    {
        this.transform.DOMoveY(gateInitialPos.y+3f, .5f);
    } 
    private void CloseGateTween()
    {
        this.transform.DOMoveY(gateInitialPos.y, .5f);

    }
}
