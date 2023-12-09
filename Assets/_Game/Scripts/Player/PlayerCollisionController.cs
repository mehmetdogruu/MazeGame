
using UnityEngine;
using DG.Tweening;

public class PlayerCollisionController : MonoBehaviour
{
    private PlayerController _controller;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tag)) return;
        var hasInteractable = other.TryGetComponent<IInteractable>(out var interactable);
        if (hasInteractable && interactable.IsInteractable) interactable.InteractionHandle(_controller);
    }
}
