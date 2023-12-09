
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject chestCover;
    [SerializeField] private GameObject cheese;
    [SerializeField] private BoxCollider chestCollider;
    [SerializeField] private ParticleSystem particle;

    public bool IsInteractable { get; private set; } = true;

    public void InteractionHandle(IInteractor interactor)
    {
        var player = (PlayerController)interactor;
        if (!player.Items.HasChestKey) return;
        IsInteractable = false;
        StatesController.Instance.SetState(StatesController.Instance.WinState);
        player.Movement.StopPlayer();
        OpenChestTween();
    }


    private void OpenChestTween()
    {
        transform.DOShakeRotation(3f, 5f, 10, 90f);
        transform.DOJump(transform.position, 0.1f, 5, 2);
        transform.DOJump(transform.position, .3f, 1, .5f).SetDelay(1.5f);
        chestCover.transform.DOLocalRotate(new Vector3(-120, 0, 0), 1f, RotateMode.Fast)
            .SetDelay(1f)
            .OnComplete(() =>
            {
                if (particle != null)
                    particle.Play();
                chestCollider.size = Vector3.zero;
            }).OnComplete(() =>
            {
                cheese.transform.DOMoveY(cheese.transform.localPosition.y + 2f, 2f);
                cheese.transform.DORotate(Vector3.up * 360, 2f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
            });
    }
}
