
using UnityEngine;
using DG.Tweening;
public class Obstacle : MonoBehaviour,IInteractable
{
    public bool IsInteractable { get; private set; } = true;

    private void OnEnable()
    {
        ObstacleTween();
    }

    public void InteractionHandle(IInteractor interactor)
    {
        var player = (PlayerController)interactor;
        StatesController.Instance.SetState(StatesController.Instance.FailState);
        player.Movement.StopPlayer();
    }

    private void ObstacleTween()
    {
        Tween tween = transform.DOMoveY(.29f, .2f).SetEase(Ease.InOutSine).SetDelay(Random.Range(.5f, 1.5f));
        Sequence sequence = DOTween.Sequence();
        sequence.Append(tween);
        sequence.Play().SetLoops(-1, LoopType.Yoyo);
    }
}
