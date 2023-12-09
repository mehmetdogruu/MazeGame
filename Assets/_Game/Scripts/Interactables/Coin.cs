
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour , IInteractable
{
    private Collider coinCollider;

    public bool IsInteractable { get; private set; } = true;

    private void Awake()
    {
        coinCollider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        transform.DORotate(Vector3.up * 360, 1f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
    }

    public void InteractionHandle(IInteractor interactor)
    {
        Debug.Log("girdi");
        var character = (PlayerController)interactor;
        EconomyManager.Instance.IncreaseCoin();
        IsInteractable = false;
        CoinAnimation();
    }

    private void CoinAnimation()
    {
        transform.DOJump(transform.position + Vector3.up * 2f, 2f, 1, .5f).OnStart(() =>
          transform.DOScale(Vector3.zero, .5f)).OnComplete(() =>
          {
              Destroy(gameObject);
          });
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
