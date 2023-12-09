using UnityEngine;
using DG.Tweening;

public class ChestKey : MonoBehaviour ,IInteractable
{
    public bool IsInteractable { get; private set; } = true;


    private void OnEnable()
    {
        ChestKeyAnimation();
    }

    public void InteractionHandle(IInteractor interactor)
    {
        var player = (PlayerController)interactor;
        player.Items.ChestKeyInteractionHandle();
        IsInteractable = false;
        player.Items.KeySprite.transform.DOScale(1f, .5f);
        KeyToPlayerAnimation();
    }

    private void KeyToPlayerAnimation()
    {
        transform.DOJump(transform.position + Vector3.up * 2f, 2f, 1, .5f).OnComplete(() =>
          transform.DOScale(Vector3.zero, .5f));
    }

    private void ChestKeyAnimation()
    {
        transform.DORotate(Vector3.up * 360, 1f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
    }

}
